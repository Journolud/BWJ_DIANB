using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public Transform player;
    public float angle;
    public bool facingRight = true;
    public float moveSpeed = 2f;
    private Rigidbody2D rb;
    private Vector2 movement;
    public bool active = false;
    private string mode = "seek";
    private float timeInDash = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!active) { return; }
        Vector3 direction = player.position - transform.position;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        direction.Normalize();
        movement = direction;

        // Logic for state switching
        if (mode == "dash")
        {
            timeInDash += Time.deltaTime;
            if (timeInDash > 2)
            {
                mode = "seek";
                timeInDash = 0;
            }
        }

    }

    void FixedUpdate()
    {
        moveEnemy(movement);
    }

    void moveEnemy(Vector2 direction)
    {
        if(angle >= 90f && angle >= -90f && facingRight)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = !gameObject.GetComponent<SpriteRenderer>().flipX;
            facingRight = false;
        }

        else if(angle <= 90f && angle >= -60 && !facingRight)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = !gameObject.GetComponent<SpriteRenderer>().flipX;
            facingRight = true;
        }

        if (mode == "dash")
        {
            rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime * 2));
        }
        
        else
        {
            rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            mode = "dash";
        }
    }


}
