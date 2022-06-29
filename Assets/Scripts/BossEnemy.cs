using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    public float timeSinceShot;
    public bool active;
    Transform playerTransform;
    public GameObject projectile;
    public Transform firePoint, firePointLeft, firePointRight;
    public Animator animator;
    private Rigidbody2D rb;
    public string shotType = "single";
    public float singleFireRate = 0.2f;
    public float spreadFireRate = 0.5f;
    public float fireSpeed = 5;

    float timeInMode = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        timeSinceShot = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!active) { return; }
        timeSinceShot += Time.deltaTime;
        timeInMode += Time.deltaTime;

        if (timeInMode > 7)
        {
            if (shotType == "single")
            {
                shotType = "spread";
            }
            else if (shotType == "spread")
            {
                shotType = "single";
            }
            timeInMode = 0;
        }

        Vector2 direction = (new Vector2(playerTransform.position.x, playerTransform.position.y) - new Vector2(firePoint.position.x, firePoint.position.y)).normalized;
        if (direction.x > 0)
        {
            Vector3 eulerRotation = transform.rotation.eulerAngles;
            //transform.rotation = Quaternion.Euler(eulerRotation.x, 0, eulerRotation.z);
            animator.SetInteger("Horizontal", 1);
            firePoint = firePointRight;
        }
        else
        {
            Vector3 eulerRotation = transform.rotation.eulerAngles;
            //transform.rotation = Quaternion.Euler(eulerRotation.x, 180, eulerRotation.z);
            animator.SetInteger("Horizontal", -1);
            firePoint = firePointLeft;
        }
        if (direction.x > -0.5f && direction.x < 0.5f)
        {
            if (direction.y > 0)
            {
                animator.SetInteger("Vertical", 1);
            }
            else
            {
                animator.SetInteger("Vertical", -1);
            }
        }
        else
        {
            animator.SetInteger("Vertical", 0);
        }
    }

    private void FixedUpdate()
    {
        if (!active) { return; }
        transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, Time.deltaTime);
        Vector2 direction = new Vector2(playerTransform.position.x, playerTransform.position.y) - new Vector2(firePoint.position.x, firePoint.position.y);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        firePoint.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        Debug.Log(timeInMode);

        if (shotType == "single")
        {
            if (timeSinceShot > singleFireRate)
            {
                FMODUnity.RuntimeManager.PlayOneShot("event:/bossproj");
                /*
                GameObject _newProjectile = Instantiate(projectile, firePoint.position, Quaternion.identity);
                _newProjectile.GetComponent<Rigidbody2D>().AddForce(direction.normalized * 6, ForceMode2D.Impulse);
                */
                GameObject _projectile = Instantiate(projectile, firePoint.position, firePoint.rotation);
                _projectile.GetComponent<Rigidbody2D>().AddForce(firePoint.right * fireSpeed, ForceMode2D.Impulse);
                timeSinceShot = 0;
            }
        }
        else if (shotType == "spread")
        {
            if (timeSinceShot > spreadFireRate)
            {
                FMODUnity.RuntimeManager.PlayOneShot("event:/bossspread");
                GameObject _projectile = Instantiate(projectile, firePoint.position, firePoint.rotation);
                _projectile.GetComponent<Rigidbody2D>().AddForce(firePoint.right * fireSpeed, ForceMode2D.Impulse);
                _projectile = Instantiate(projectile, firePoint.position, firePoint.rotation);
                _projectile.GetComponent<Rigidbody2D>().AddForce(Quaternion.AngleAxis(-50, Vector3.forward) * firePoint.right.normalized * fireSpeed, ForceMode2D.Impulse);
                _projectile = Instantiate(projectile, firePoint.position, firePoint.rotation);
                _projectile.GetComponent<Rigidbody2D>().AddForce(Quaternion.AngleAxis(-40, Vector3.forward) * firePoint.right.normalized * fireSpeed, ForceMode2D.Impulse);
                _projectile = Instantiate(projectile, firePoint.position, firePoint.rotation);
                _projectile.GetComponent<Rigidbody2D>().AddForce(Quaternion.AngleAxis(-30, Vector3.forward) * firePoint.right.normalized * fireSpeed, ForceMode2D.Impulse);
                _projectile = Instantiate(projectile, firePoint.position, firePoint.rotation);
                _projectile.GetComponent<Rigidbody2D>().AddForce(Quaternion.AngleAxis(-20, Vector3.forward) * firePoint.right.normalized * fireSpeed, ForceMode2D.Impulse);
                _projectile = Instantiate(projectile, firePoint.position, firePoint.rotation);
                _projectile.GetComponent<Rigidbody2D>().AddForce(Quaternion.AngleAxis(-10, Vector3.forward) * firePoint.right.normalized * fireSpeed, ForceMode2D.Impulse);
                _projectile = Instantiate(projectile, firePoint.position, firePoint.rotation);
                _projectile.GetComponent<Rigidbody2D>().AddForce(Quaternion.AngleAxis(10, Vector3.forward) * firePoint.right.normalized * fireSpeed, ForceMode2D.Impulse);
                _projectile = Instantiate(projectile, firePoint.position, firePoint.rotation);
                _projectile.GetComponent<Rigidbody2D>().AddForce(Quaternion.AngleAxis(20, Vector3.forward) * firePoint.right.normalized * fireSpeed, ForceMode2D.Impulse);
                _projectile = Instantiate(projectile, firePoint.position, firePoint.rotation);
                _projectile.GetComponent<Rigidbody2D>().AddForce(Quaternion.AngleAxis(30, Vector3.forward) * firePoint.right.normalized * fireSpeed, ForceMode2D.Impulse);
                _projectile = Instantiate(projectile, firePoint.position, firePoint.rotation);
                _projectile.GetComponent<Rigidbody2D>().AddForce(Quaternion.AngleAxis(40, Vector3.forward) * firePoint.right.normalized * fireSpeed, ForceMode2D.Impulse);
                _projectile = Instantiate(projectile, firePoint.position, firePoint.rotation);
                _projectile.GetComponent<Rigidbody2D>().AddForce(Quaternion.AngleAxis(50, Vector3.forward) * firePoint.right.normalized * fireSpeed, ForceMode2D.Impulse);

                timeSinceShot = 0;
            }
        }
        
    }
}
