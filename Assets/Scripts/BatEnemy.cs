using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatEnemy : MonoBehaviour
{
    public TileMapManager tileMapManager;
    TileMapNode currentNode;
    public float timeSinceRelocation, timeSinceShot;
    public bool active;
    public GameObject projectile;
    public Transform firePoint;
    Vector2 destination;
    public float fireSpeed;

    // Start is called before the first frame update
    void Start()
    {
        firePoint = transform;
        Relocate();
    }

    void Update()
    {
        if (!active) { return; }
        timeSinceShot += Time.deltaTime;
        timeSinceRelocation += Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, destination, Time.deltaTime * 3);
        if (timeSinceShot > 2.5)
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/enemyspread");
            GameObject _projectile = Instantiate(projectile, firePoint.position, firePoint.rotation);
            _projectile.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireSpeed, ForceMode2D.Impulse);
            _projectile = Instantiate(projectile, firePoint.position, firePoint.rotation);
            _projectile.GetComponent<Rigidbody2D>().AddForce(Quaternion.AngleAxis(-30, Vector3.forward) * firePoint.up.normalized * fireSpeed, ForceMode2D.Impulse);
            _projectile = Instantiate(projectile, firePoint.position, firePoint.rotation);
            _projectile.GetComponent<Rigidbody2D>().AddForce(Quaternion.AngleAxis(30, Vector3.forward) * firePoint.up.normalized * fireSpeed, ForceMode2D.Impulse);
            _projectile = Instantiate(projectile, firePoint.position, firePoint.rotation);
            _projectile.GetComponent<Rigidbody2D>().AddForce(Quaternion.AngleAxis(-60, Vector3.forward) * firePoint.up.normalized * fireSpeed, ForceMode2D.Impulse);
            _projectile = Instantiate(projectile, firePoint.position, firePoint.rotation);
            _projectile.GetComponent<Rigidbody2D>().AddForce(Quaternion.AngleAxis(60, Vector3.forward) * firePoint.up.normalized * fireSpeed, ForceMode2D.Impulse);
            _projectile = Instantiate(projectile, firePoint.position, firePoint.rotation);
            _projectile.GetComponent<Rigidbody2D>().AddForce(Quaternion.AngleAxis(-90, Vector3.forward) * firePoint.up.normalized * fireSpeed, ForceMode2D.Impulse);
            _projectile = Instantiate(projectile, firePoint.position, firePoint.rotation);
            _projectile.GetComponent<Rigidbody2D>().AddForce(Quaternion.AngleAxis(90, Vector3.forward) * firePoint.up.normalized * fireSpeed, ForceMode2D.Impulse);
            _projectile = Instantiate(projectile, firePoint.position, firePoint.rotation);
            _projectile.GetComponent<Rigidbody2D>().AddForce(Quaternion.AngleAxis(-120, Vector3.forward) * firePoint.up.normalized * fireSpeed, ForceMode2D.Impulse);
            _projectile = Instantiate(projectile, firePoint.position, firePoint.rotation);
            _projectile.GetComponent<Rigidbody2D>().AddForce(Quaternion.AngleAxis(120, Vector3.forward) * firePoint.up.normalized * fireSpeed, ForceMode2D.Impulse);
            _projectile = Instantiate(projectile, firePoint.position, firePoint.rotation);
            _projectile.GetComponent<Rigidbody2D>().AddForce(Quaternion.AngleAxis(-150, Vector3.forward) * firePoint.up.normalized * fireSpeed, ForceMode2D.Impulse);
            _projectile = Instantiate(projectile, firePoint.position, firePoint.rotation);
            _projectile.GetComponent<Rigidbody2D>().AddForce(Quaternion.AngleAxis(150, Vector3.forward) * firePoint.up.normalized * fireSpeed, ForceMode2D.Impulse);
            _projectile = Instantiate(projectile, firePoint.position, firePoint.rotation);
            _projectile.GetComponent<Rigidbody2D>().AddForce(Quaternion.AngleAxis(180, Vector3.forward) * firePoint.up.normalized * fireSpeed, ForceMode2D.Impulse);
            timeSinceShot = 0;
        }
        if (timeSinceRelocation > 7)
        {
            Relocate();
            timeSinceRelocation = 0;
        }
    }


    void Relocate()
    {
        if (currentNode != null)
        {
            currentNode.SetTileTypeToBase();
        }
        currentNode = tileMapManager.GetClearNode();
        destination = currentNode.worldPosition;

    }

}
