using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed, dashSpeed;
    private Rigidbody2D rb;
    private InputActions controls;
    private bool dash = false;
    private Vector2 dashDirection;
    private float dashTimer = 0;
    Animator animator;

    // Dash sprites
    public float timeTransparent = 0;
    SpriteRenderer sprite;
    public GameObject shadow;

    // Shoot Variables
    public Transform firePoint;
    public GameObject primaryProjectile;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        controls = new InputActions();
        controls.Enable();
        controls.Player.Dash.performed += _ => Dash();
        controls.Player.Shoot.performed += _ => FireSingle(firePoint, primaryProjectile);
        sprite = GetComponent<SpriteRenderer>();
        //animator = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        if (dash)
        {
            
            dashTimer += Time.deltaTime;
            if (dashTimer > 0.2)
            {
                dash = false;
                sprite.color = new Color(1f, 1f, 1f, 1f);
                dashTimer = 0;
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
        }
        else
        {
            rb.velocity = dashDirection * dashSpeed;
            Instantiate(shadow, transform.position, transform.rotation);

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

    private void Dash()
    {
        Vector3 _mousePosition = Camera.main.ScreenToWorldPoint(controls.Player.Aim.ReadValue<Vector2>());
        dashDirection = _mousePosition - transform.position;
        dashDirection.Normalize();
        sprite.color = new Color(1f, 1f, 1f, 0.8f);
        dash = true;
    }

    private void FireSingle(Transform _firepoint, GameObject _projectile)
    {
        Vector3 _mousePosition = Camera.main.ScreenToWorldPoint(controls.Player.Aim.ReadValue<Vector2>());
        Vector2 _direction = _mousePosition - _firepoint.position;
        _direction.Normalize();
        Debug.Log(_direction);
        GameObject _newProjectile = Instantiate(_projectile, _firepoint.position, _firepoint.rotation);
        //newLaser.GetComponent<Rigidbody2D>().AddForce(_direction * 5, ForceMode2D.Impulse);
        _newProjectile.GetComponent<Rigidbody2D>().velocity = _direction * 10;
    }
}
