using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100f;

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if(health >= 1)
        {
            health -= 5;
        }
    }
}
