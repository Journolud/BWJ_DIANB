using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health;
    public RoomManager roomManager;
    public GameObject deathEffect;
    
    public void TakeDamage(int _damage)
    {
        health -= _damage;
        if (health < 0)
        {
            roomManager.EnemyKilled();
            if (deathEffect)
            {
                Instantiate(deathEffect, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
}
