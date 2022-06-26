using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingProjectile : MonoBehaviour
{
    public int damage;
    public GameObject bulletImpact;
    public bool enchanted;
    private bool hasBounced = false;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
        }

        Instantiate(bulletImpact, transform.position, Quaternion.identity);
        if (hasBounced)
        {
            Destroy(gameObject);
        }
        hasBounced = true;
    }
}

