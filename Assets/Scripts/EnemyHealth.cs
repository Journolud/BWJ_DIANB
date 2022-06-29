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
        FMODUnity.RuntimeManager.PlayOneShot("event:/enemyhurt");
        health -= _damage;
        if (health < 0)
        {
            if (!boss)
            {
                FMODUnity.RuntimeManager.PlayOneShot("event:/enemydie");
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
                FMODUnity.RuntimeManager.PlayOneShot("event:/bossdie");
                Time.timeScale = 0;
                //winUI.active = true;
            }
            Destroy(gameObject);
        }
    }
}
