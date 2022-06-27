using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthVisuals : MonoBehaviour
{
    public float SharedHealth, movingSpeed, dashingSpeed;
    public float alphaLevel = 0f;
    PlayerHealth playerHealth;
    PlayerController playerController;
    [SerializeField] GameObject player;
    [SerializeField] GameObject h1;
    [SerializeField] GameObject h2;
    [SerializeField] GameObject h3;
    [SerializeField] GameObject h4;
    [SerializeField] GameObject h5;


    void Awake()
    {
        playerHealth = player.GetComponent<PlayerHealth>();
        playerController = player.GetComponent<PlayerController>();
        
    }

    void FixedUpdate()
    {
        SharedHealth = playerHealth.health;

        if(SharedHealth >= 81)
        {
            return;
        }

        else if(SharedHealth == 80)
        {
            h5.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaLevel);
            return;
        }

        else if (SharedHealth == 60)
        {
            h4.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaLevel);
            return;
        }

        else if (SharedHealth == 40)
        {
            h3.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaLevel);
            return;
        }

        else if (SharedHealth == 20)
        {
            h2.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaLevel);
            return;
        }

        else if (SharedHealth == 0)
        {
            h1.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaLevel);
            playerController.moveSpeed = 0f;
            playerController.dashSpeed = 0f;
            return;
        }
    }
}
