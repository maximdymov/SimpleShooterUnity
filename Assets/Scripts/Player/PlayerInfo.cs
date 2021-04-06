using System;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{ 
    [SerializeField] public static float playerHealth = 5;
    [SerializeField] private static float ammoCount = 20;

    public static event Action PlayerDead;

    public static void TakeDamage(float damage)
    {
        playerHealth -= damage;
        if (playerHealth == 0)
            PlayerDeadNotifying();
    }

    public static float GetPlayerHealth()
    {
        return playerHealth;
    }

    public static float GetAmmoCount()
    {
        return ammoCount;
    }

    public static void ReduceAmmo()
    {
        ammoCount -= 1;
    }

    private static void PlayerDeadNotifying()
    {
        PlayerDead?.Invoke();
    }

}
