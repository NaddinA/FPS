using System.Reflection.Emit;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float playerHP = 100f;

    public void GetDamaged(float damage)
    {
        playerHP -= damage;
        if (playerHP <= 0)
        {
            GetComponent<DeathHandler>().HandleDeath();
        }
    }
}
