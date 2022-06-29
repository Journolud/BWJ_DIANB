using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerProjectile : MonoBehaviour
{
    public int damage;
    public GameObject bulletImpact;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
        }

        Instantiate(bulletImpact, transform.position, Quaternion.identity);
    }

    
}
