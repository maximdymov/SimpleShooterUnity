using System;
using UnityEngine;

public class EnemyInfo : MonoBehaviour
{
    public event Action EnemyTakesDamage;
    public static event Action EnemyDead;
    [SerializeField] private float enemyHealth = 3;

    private void OnEnable()
    {
        EnemyTakesDamage += EnemyDeath;
    }

    private void EnemyDeath()
    {
        if (enemyHealth == 0)
        {
            Destroy(gameObject);
            EnemyDead?.Invoke();
        }
    }

    public void TakeDamage(float damage)
    {
        enemyHealth -= damage;
        EnemyTakesDamage?.Invoke();
    }
}
