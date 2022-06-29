using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public bool healthDecrease = false;
    public HealthVisuals ui;
    public float health = 100f;
    public float maxHealth = 100f;
    PlayerController playerController;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    void FixedUpdate()
    {
        if (healthDecrease && health >= 0.5f)
        {
            health -= 0.5f;
            if (health <= 0)
            {
                playerController.HandleDeath();
            }
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
        if (health <= 0)
        {
            playerController.HandleDeath();
        }
    }

    public void AddHealth(int _health)
    {
        health += _health;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    public void SetMaxHealth(int _maxHealth)
    {
        maxHealth = _maxHealth;
        health = maxHealth;
        ui.SetMaxHealthUI();
    }
}
