using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearProjectile : MonoBehaviour
{
    public int damage;
    public GameObject bulletImpact;
    public bool enchanted;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
        }
        else if (col.gameObject.name == "Player")
        {
            col.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
        FMODUnity.RuntimeManager.PlayOneShot("event:/impact");
        Instantiate(bulletImpact, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
