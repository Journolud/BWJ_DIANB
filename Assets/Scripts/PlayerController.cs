using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed, dashSpeed;
    private Rigidbody2D rb;
    private InputActions controls;
    private bool dash = false;
    private Vector2 dashDirection;
    private float dashTimer = 0;
    private float dashTime;
    public Animator animator;
    public TextMeshProUGUI dashText, speedValue;

    // Dash sprites
    public float timeTransparent = 0;
    SpriteRenderer sprite;
    public GameObject[] shadows;

    // Pick up logic
    public GameObject weapon;
    public GameObject projectile;

    public PlayerHealth playerhealth;

    // UI stuff
    public GameObject menuHolder;
    public int lives = 3;

    public SpriteRenderer livesIndicator;
    public Sprite lives2;
    public Sprite lives1;

    






    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        controls = new InputActions();
        controls.Enable();
        controls.Player.Dash.performed += _ => Dash();
        controls.Player.PickUp.performed += _ => PickUpItem();
        sprite = GetComponent<SpriteRenderer>();
        RandomiseStats();
        //animator = gameObject.GetComponent<Animator>();
        
    }

    private void Update()
    {
        if (dash)
        {        
            FMODUnity.RuntimeManager.PlayOneShot("event:/dash");    
            dashTimer += Time.deltaTime;
            if (dashTimer > dashTime)
            {
                dash = false;
                sprite.color = new Color(1f, 1f, 1f, 1f);
                dashTimer = 0;
                Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("EnemyProjectile"), false);
            }
        }
        
    }

    private void FixedUpdate()
    {
        if (!dash)
        {
            float xAxisMovement = controls.Player.Movement.ReadValue<Vector2>().x;
            float yAxisMovement = controls.Player.Movement.ReadValue<Vector2>().y;
            /* Animation
            if (yAxisMovement != 0 || xAxisMovement != 0)
            {
                animator.SetBool("Moving", true);
            }
            else
            {
                animator.SetBool("Moving",false);
            }
            */
            rb.velocity = new Vector2(xAxisMovement, yAxisMovement).normalized * moveSpeed;

            if (new Vector2(xAxisMovement, yAxisMovement).normalized.y > 0.5)
            {
                animator.SetInteger("Vertical", 1);
                animator.SetBool("Idle", false);
            }
            else if (new Vector2(xAxisMovement, yAxisMovement).normalized.y < -0.5)
            {
                animator.SetInteger("Vertical", -1);
                animator.SetBool("Idle", false);
            }
            else if (new Vector2(xAxisMovement, yAxisMovement).normalized.y == 0 && new Vector2(xAxisMovement, yAxisMovement).normalized.x == 0)
            {
                animator.SetBool("Idle", true);
            }
            else
            {
                animator.SetInteger("Vertical", 0);
                animator.SetBool("Idle", false);
            }
        }
        else
        {
            rb.velocity = dashDirection * moveSpeed * 2;
            Instantiate(shadows[Random.Range(0, shadows.Length)], transform.position, transform.rotation);

        }

        // Face correct direction
        Vector3 _mousePosition = Camera.main.ScreenToWorldPoint(controls.Player.Aim.ReadValue<Vector2>());
        Vector2 _direction = _mousePosition - transform.position;

        if (_direction.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private void RandomiseStats()
    {
        int _healthChoice = Random.Range(0, 4);
        int[] _healthChoices = new int[] { 80, 120, 120, 140 };
        playerhealth.SetMaxHealth(_healthChoices[_healthChoice]);

        moveSpeed = 4f;
        speedValue.text = moveSpeed.ToString();

        dashTime = 0.2f;
        dashText.text = dashTime.ToString();

    }

    public void IncreaseStat()
    {
        if (Random.Range(0, 100) > 30)
        {
            moveSpeed += 0.1f;
            if (moveSpeed > 8)
            {
                moveSpeed = 8;
            }
            speedValue.text = moveSpeed.ToString();
        }
        else
        {
            dashTime += 0.01f;
            if (dashTime > 0.5f)
            {
                dashTime = 0.5f;
            }
            dashText.text = dashTime.ToString();
        }
    }

    private void Dash()
    {
        Vector3 _mousePosition = Camera.main.ScreenToWorldPoint(controls.Player.Aim.ReadValue<Vector2>());
        dashDirection = _mousePosition - transform.position;
        dashDirection.Normalize();
        sprite.color = new Color(1f, 1f, 1f, 0.5f);
        dash = true;
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("EnemyProjectile"));
    }

    public bool getDash()
    {
        return dash;
    }

    private void PickUpItem()
    {
        Debug.Log("Looking for PickUps");
        int layerMask = LayerMask.GetMask("PickUps");
        Collider2D[] hitColliders = Physics2D.OverlapBoxAll(gameObject.transform.position, new Vector2(2, 2), 0, layerMask);
        if (hitColliders.Length > 0)
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/pickup");

            if (hitColliders[0].gameObject.GetComponent<PickUp>().type == "projectile")
            {
                projectile = hitColliders[0].gameObject.GetComponent<PickUp>().pickUpObject;
                weapon.GetComponent<Weapon>().primaryProjectile = projectile;
                Destroy(hitColliders[0].gameObject);
                int layer1 = LayerMask.NameToLayer("Projectile");
                int layer2 = LayerMask.NameToLayer("EnemyProjectile");
                if (projectile.name == "EnchantedBullet")
                {
                    Physics2D.IgnoreLayerCollision(layer1, layer2, false);
                }
                else
                {
                    Physics2D.IgnoreLayerCollision(layer1, layer2, false);
                }
            }
        }
    }

    public void HandleDeath()
    {
        lives -= 1;
        if (lives == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else if (lives == 1)
        {
            livesIndicator.sprite = lives1;
        }
        else if (lives == 2)
        {
            livesIndicator.sprite = lives2;
        }
        menuHolder.SetActive(true);
        Time.timeScale = 0;
    }

    public void Respawn()
    {
        RandomiseStats();
        Time.timeScale = 1;
        menuHolder.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ImproveWeapon()
    {
        weapon.GetComponent<Weapon>().primaryCoolDown -= 0.1f;
        if (weapon.GetComponent<Weapon>().primaryCoolDown < 0.1f)
        {
            weapon.GetComponent<Weapon>().primaryCoolDown = 0.1f;
        }
    }


}
