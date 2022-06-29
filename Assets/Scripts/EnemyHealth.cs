using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health;
    public RoomManager roomManager;
    public GameObject deathEffect;
    private PlayerController player;
    public GameObject winUI;
    public bool boss;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    public void TakeDamage(int _damage)
    {
        health -= _damage;
        if (health < 0)
        {
            if (!boss)
            {
                roomManager.EnemyKilled();
            }
            if (deathEffect)
            {
                Instantiate(deathEffect, transform.position, Quaternion.identity);
            }
            if (GetComponent<DropOnDeath>())
            {
                GetComponent<DropOnDeath>().dropPickUp();
            }
            player.IncreaseStat();
            if (boss)
            {
                Time.timeScale = 0;
                //winUI.active = true;
            }
            Destroy(gameObject);
        }
    }
}
