using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectiveEnemy : MonoBehaviour
{
    public GameObject projectile;
    public Transform firePoint;
    public float fireSpeed = 4;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            Debug.Log("Reflected Boi");
            GameObject _projectile = Instantiate(projectile, firePoint.position, firePoint.rotation);
            _projectile.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireSpeed, ForceMode2D.Impulse);
            _projectile = Instantiate(projectile, firePoint.position, firePoint.rotation);
            float rand = Random.Range(-7.5f, 7.5f);
            _projectile.GetComponent<Rigidbody2D>().AddForce(Quaternion.AngleAxis(-15 + rand, Vector3.forward) * firePoint.up.normalized * fireSpeed, ForceMode2D.Impulse);
            _projectile = Instantiate(projectile, firePoint.position, firePoint.rotation);
            rand = Random.Range(-7.5f, 7.5f);
            _projectile.GetComponent<Rigidbody2D>().AddForce(Quaternion.AngleAxis(15 + rand, Vector3.forward) * firePoint.up.normalized * fireSpeed, ForceMode2D.Impulse);
            _projectile = Instantiate(projectile, firePoint.position, firePoint.rotation);
            rand = Random.Range(-7.5f, 7.5f);
            _projectile.GetComponent<Rigidbody2D>().AddForce(Quaternion.AngleAxis(-30 + rand, Vector3.forward) * firePoint.up.normalized * fireSpeed, ForceMode2D.Impulse);
            _projectile = Instantiate(projectile, firePoint.position, firePoint.rotation);
            rand = Random.Range(-7.5f, 7.5f);
            _projectile.GetComponent<Rigidbody2D>().AddForce(Quaternion.AngleAxis(30 + rand, Vector3.forward) * firePoint.up.normalized * fireSpeed, ForceMode2D.Impulse);
            _projectile = Instantiate(projectile, firePoint.position, firePoint.rotation);
            rand = Random.Range(-7.5f, 7.5f);
            _projectile.GetComponent<Rigidbody2D>().AddForce(Quaternion.AngleAxis(-45 + rand, Vector3.forward) * firePoint.up.normalized * fireSpeed, ForceMode2D.Impulse);
            _projectile = Instantiate(projectile, firePoint.position, firePoint.rotation);
            rand = Random.Range(-7.5f, 7.5f);
            _projectile.GetComponent<Rigidbody2D>().AddForce(Quaternion.AngleAxis(45 + rand, Vector3.forward) * firePoint.up.normalized * fireSpeed, ForceMode2D.Impulse);
            _projectile = Instantiate(projectile, firePoint.position, firePoint.rotation);
            rand = Random.Range(-7.5f, 7.5f);
            _projectile.GetComponent<Rigidbody2D>().AddForce(Quaternion.AngleAxis(-60 + rand, Vector3.forward) * firePoint.up.normalized * fireSpeed, ForceMode2D.Impulse);
            _projectile = Instantiate(projectile, firePoint.position, firePoint.rotation);
            rand = Random.Range(-7.5f, 7.5f);
            _projectile.GetComponent<Rigidbody2D>().AddForce(Quaternion.AngleAxis(60 + rand, Vector3.forward) * firePoint.up.normalized * fireSpeed, ForceMode2D.Impulse);
            _projectile = Instantiate(projectile, firePoint.position, firePoint.rotation);
            rand = Random.Range(-7.5f, 7.5f);
            _projectile.GetComponent<Rigidbody2D>().AddForce(Quaternion.AngleAxis(-75 + rand, Vector3.forward) * firePoint.up.normalized * fireSpeed, ForceMode2D.Impulse);
            _projectile = Instantiate(projectile, firePoint.position, firePoint.rotation);
            rand = Random.Range(-7.5f, 7.5f);
            _projectile.GetComponent<Rigidbody2D>().AddForce(Quaternion.AngleAxis(75 + rand, Vector3.forward) * firePoint.up.normalized * fireSpeed, ForceMode2D.Impulse);
            _projectile = Instantiate(projectile, firePoint.position, firePoint.rotation);
            rand = Random.Range(-7.5f, 7.5f);
            _projectile.GetComponent<Rigidbody2D>().AddForce(Quaternion.AngleAxis(-90 + rand, Vector3.forward) * firePoint.up.normalized * fireSpeed, ForceMode2D.Impulse);
            _projectile = Instantiate(projectile, firePoint.position, firePoint.rotation);
            rand = Random.Range(-7.5f, 7.5f);
            _projectile.GetComponent<Rigidbody2D>().AddForce(Quaternion.AngleAxis(90 + rand, Vector3.forward) * firePoint.up.normalized * fireSpeed, ForceMode2D.Impulse);
        }
    }
}
