using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform player;
    public Vector2 bossPrediction;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            player.position = new Vector2(bossPrediction.x, bossPrediction.y -4);
            Camera.main.transform.position = new Vector3(bossPrediction.x, 249, -1.12f);
        }
    }
}
