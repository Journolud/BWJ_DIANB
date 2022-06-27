using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurrowingEnemy : MonoBehaviour
{
    public TileMapManager tileMapManager;
    TileMapNode currentNode;
    public float timeSinceRelocation, timeSinceBurrowed, timeSinceShot;
    public bool active, burrowed, canShoot;
    Transform playerTransform;
    public GameObject projectile;
    public Transform firePoint;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        timeSinceShot = 0;
        timeSinceBurrowed = 0;
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        animator = GetComponent<Animator>();
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!active) { return; }
        
        if (burrowed)
        {
            timeSinceBurrowed += Time.deltaTime;
        }
        else
        {
            timeSinceRelocation += Time.deltaTime;
        }
        if (canShoot)
        {
            timeSinceShot += Time.deltaTime;
        }
        if (timeSinceRelocation > 4.3)
        {
            animator.SetBool("Burrowed", true);
            canShoot = false;
        }
        if (timeSinceRelocation > 5)
        {
            burrowed = true;
            timeSinceRelocation = 0;
            GetComponent<Collider2D>().enabled = true;
        }
        if (timeSinceBurrowed > 1.5)
        {
            Relocate();
            burrowed = false;
            animator.SetBool("Burrowed", false);
            GetComponent<Collider2D>().enabled = true;
            timeSinceBurrowed = 0;
        }
        if (timeSinceRelocation > 0.5)
        {
            canShoot = true;
        }
        if (timeSinceRelocation > 0.5f)
        {
            if (timeSinceShot > 0.2f)
            {

                Vector2 direction = new Vector2(playerTransform.position.x, playerTransform.position.y) - new Vector2(firePoint.position.x, firePoint.position.y);
                GameObject _newProjectile = Instantiate(projectile, firePoint.position, Quaternion.identity);
                _newProjectile.GetComponent<Rigidbody2D>().AddForce(direction.normalized * 6, ForceMode2D.Impulse);
                timeSinceShot = 0;
            }
        }
    }

    void Relocate()
    {
        if (currentNode != null)
        {
            currentNode.SetTileTypeToBase();
        }
        currentNode = tileMapManager.GetClearNode();
        transform.position = currentNode.worldPosition;

    }
}
