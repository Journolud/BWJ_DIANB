using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class McPickup : MonoBehaviour
{
    public GameObject player;
    [SerializeField] Sprite MC1;
    [SerializeField] Sprite MC2;
    [SerializeField] Sprite MC3;
    public int MCRand;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.name == "Player")
        {
            MCRand = Random.Range(1, 3);

            if (MCRand == 1)
            {
                collider.gameObject.GetComponent<SpriteRenderer>().sprite = MC1;
            }

            else if (MCRand == 2) 
            {
                collider.gameObject.GetComponent<SpriteRenderer>().sprite = MC2;
            }

            else if (MCRand == 3)
            {
                collider.gameObject.GetComponent<SpriteRenderer>().sprite = MC3;
            }

            Destroy(gameObject);
        }
    }

}
