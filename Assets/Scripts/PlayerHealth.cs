using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public bool healthDecrease = false;
    public float health = 100f;

    void FixedUpdate()
    {
        if (healthDecrease && health >= 0.5f)
        {
            health -= 0.5f;
        }
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        healthDecrease = true;
    }

    public void OnTriggerExit2D(Collider2D collider)
    {
        healthDecrease = false;
    }
}
