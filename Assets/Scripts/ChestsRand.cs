using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestsRand : MonoBehaviour
{
    PlayerHealth playerHealth;
    [SerializeField] GameObject player;
    [SerializeField] GameObject chest;
    public GameObject medBox;
    private InputActions controls;
    public int PreSet;
    public bool enter = false;

    void OnTriggerEnter2D(Collider2D collider)
    {
        enter = true;
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        enter = false;
    }

    void Start()
    {
        controls = new InputActions();
            controls.Enable();
            controls.Player.PickUp.performed += _ => Randomizer();
    }

    void Awake()
    {
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    void FixedUpdate()
    {
        Randomizer();
    }


    void Randomizer()
    {
        if (!enter) { return; }
        chest.GetComponent<BoxCollider2D>().enabled = false;
        PreSet = Random.Range(1, 4);

        if(PreSet == 1)
        {
            SpawnAmmo();
        } 

        else if(PreSet == 2)
        {
            SpawnHealth();
        }

        else if(PreSet == 3)
        {
            SpawnGun();
        }

        else if(PreSet == 4)
        {
            SpawnAmmo();
            SpawnHealth();
        }
    }

    void SpawnAmmo()
    {

    }

    void SpawnGun()
    {

    }

    void SpawnHealth()
    {
        Instantiate(medBox, new Vector3(4, 4, 0), Quaternion.identity);
    }
}
