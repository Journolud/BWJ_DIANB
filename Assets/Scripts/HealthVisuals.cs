using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthVisuals : MonoBehaviour
{
    public float SharedHealth, movingSpeed, dashingSpeed;
    public float alphaOff = 0f;
    public float alphaOn = 1f;
    PlayerHealth playerHealth;
    PlayerController playerController;
    [SerializeField] GameObject player;
    [SerializeField] GameObject h1;
    [SerializeField] GameObject h2;
    [SerializeField] GameObject h3;
    [SerializeField] GameObject h4;
    [SerializeField] GameObject h5;
    [SerializeField] GameObject h6;
    [SerializeField] GameObject h7;


    void Awake()
    {
        playerHealth = player.GetComponent<PlayerHealth>();
        playerController = player.GetComponent<PlayerController>();
        
    }

    void FixedUpdate()
    {
        SharedHealth = playerHealth.health;

        if (SharedHealth >= 121)
        {
            h7.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaOn);
            h6.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaOn);
            h5.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaOn);
            h4.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaOn);
            h3.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaOn);
            h2.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaOn);
            h1.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaOn);
            return;
        }

        else if(SharedHealth >= 101)
        {
            h7.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaOff);

            h6.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaOn);
            h5.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaOn);
            h4.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaOn);
            h3.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaOn);
            h2.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaOn);
            h1.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaOn);
            return;
        }

        else if(SharedHealth >= 81)
        {
            h6.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaOff);
            h7.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaOff);

            h5.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaOn);
            h4.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaOn);
            h3.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaOn);
            h2.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaOn);
            h1.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaOn);
            return;
        }

        else if(SharedHealth >= 61)
        {
            h5.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaOff);
            h6.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaOff);
            h7.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaOff);

            h4.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaOn);
            h3.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaOn);
            h2.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaOn);
            h1.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaOn);
            return;
        }

        else if (SharedHealth >= 41)
        {
            h4.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaOff);
            h5.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaOff);
            h6.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaOff);
            h7.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaOff);

            h3.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaOn);
            h2.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaOn);
            h1.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaOn);
            return;
        }

        else if (SharedHealth >= 21)
        {
            h3.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaOff);
            h4.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaOff);
            h5.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaOff);
            h6.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaOff);
            h7.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaOff);

            h2.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaOn);
            h1.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaOn);
            return;
        }

        else if (SharedHealth >= 1)
        {
            h2.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaOff);
            h3.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaOff);
            h4.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaOff);
            h5.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaOff);
            h6.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaOff);
            h7.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaOff);

            h1.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaOn);
            return;
        }

        else if (SharedHealth == 0)
        {
            h1.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaOff);
            h2.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaOff);
            h3.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaOff);
            h4.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaOff);
            h5.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaOff);
            h6.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaOff);
            h7.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaOff);
            playerController.moveSpeed = 0f;
            playerController.dashSpeed = 0f;
            return;
        }
    } 
}
