using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float turnSpeed = 5f;
    float distanceToTarget = Mathf.Infinity;
    NavMeshAgent navMeshAgent;
    bool isProvoked = false;
    EnemyHealth health;
    Transform target;
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        health = GetComponent<EnemyHealth>();
        target = FindObjectOfType<PlayerHealth>().transform;
    }
    void Update()
    {
        if(health.isSoDead())
        {
            enabled = false;
            navMeshAgent.enabled = false;
        }
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if(isProvoked)
        {
            EngageTarget();
        }
        else if (distanceToTarget <= chaseRange)
        {
            isProvoked = true;
        }
    }

    void EngageTarget()
    {
        FaceTarget();
        if (distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }
        if (distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }

    public void OnDamageTake()
    {
        isProvoked = true;
    }

  private void ChaseTarget()
  {
        GetComponent<Animator>().SetBool("attack", false);
        GetComponent<Animator>().SetTrigger("move");
        navMeshAgent.SetDestination(target.position);
  }

    void AttackTarget()
    {
        GetComponent<Animator>().SetBool("attack", true);
        // Debug.Log("Player is getting attacked!");
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        //normalized means that we are not interested in the value of the magnitude of the vector as we wont be needing it anyway so it excludes it from calculation.
        Quaternion lookDirection = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookDirection, Time.deltaTime * turnSpeed);
    }
  void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
