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
    [SerializeField] GameObject h1e;
    [SerializeField] GameObject h2e;
    [SerializeField] GameObject h3e;
    [SerializeField] GameObject h4e;
    [SerializeField] GameObject h5e;
    [SerializeField] GameObject h6e;
    [SerializeField] GameObject h7e;


    void Awake()
    {
        playerHealth = player.GetComponent<PlayerHealth>();
        playerController = player.GetComponent<PlayerController>();
        
    }

    void FixedUpdate()
    {
        SharedHealth = playerHealth.health;

        if (SharedHealth >= 140)
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

        if (SharedHealth >= 120)
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

        else if(SharedHealth >= 100)
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

        else if(SharedHealth >= 80)
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

        else if (SharedHealth >= 60)
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

        else if (SharedHealth >= 40)
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

        else if (SharedHealth >= 20)
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

        else if (SharedHealth >= 0)
        {
            h1.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaOff);
            h2.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaOff);
            h3.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaOff);
            h4.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaOff);
            h5.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaOff);
            h6.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaOff);
            h7.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaOff);
            return;
        }
    } 

    public void SetMaxHealthUI()
    {
        h1e.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaOn);
        h2e.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaOn);
        h3e.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaOn);
        h4e.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaOff);
        h5e.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaOff);
        h6e.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaOff);
        h7e.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaOff);
        if (playerHealth.maxHealth >= 79)
        {
            h4e.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaOn);
        }
        if (playerHealth.maxHealth >= 99)
        {
            h5e.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaOn);
        }
        if (playerHealth.maxHealth >= 119)
        {
            h6e.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaOn);
        }
        if (playerHealth.maxHealth >= 139)
        {
            h7e.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaOn);
        }

    }
}
