using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public bool healthDecrease = false;
    public float health = 100f;
    public float maxHealth = 100f;

    void FixedUpdate()
    {
        if (healthDecrease && health >= 0.5f)
        {
            health -= 0.5f;
        }
    }

    public void OnTriggerEnter2D(Collider2D collider)
    { 
        if (collider.gameObject.GetComponent<Enemy>())
        {
            healthDecrease = true;
        }
        
    }

    public void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent<Enemy>())
        {
            healthDecrease = false;
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    public void AddHealth(int _health)
    {
        health += _health;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }
}
