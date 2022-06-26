using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearProjectile : MonoBehaviour
{
    public int damage;
    public GameObject bulletImpact;
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
        }
        Instantiate(bulletImpact, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
