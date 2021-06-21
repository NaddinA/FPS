using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitpoints = 100f;
    bool isDead = false;
    public bool isSoDead()
    {
        return isDead;
    }

    //create a public method that reduces hitpoints by the amount of damage coming from weapons
    public void TakeDamage(float weaponDMG)
    {
        BroadcastMessage("OnDamageTake");
        hitpoints -= weaponDMG;
        if (hitpoints <= 0)
        {   
            Die();
        }
    }
    private void Die()
    {
            if(isDead) return;
            isDead = true;
            GetComponent<Animator>().SetTrigger("death");
    }
}
