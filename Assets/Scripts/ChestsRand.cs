using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestsRand : MonoBehaviour
{
    PlayerHealth playerHealth;
    [SerializeField] GameObject player;
    public int PlayerRandomizer;
    public int WeaponRandomizer;
    public int HealthRandomizer;
    public int HealthRand;

    void OnTriggerEnter2D(Collider2D collider)
    {
        Randomizer();
    }

    void Awake()
    {
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    void Randomizer()
    {

        PlayerRandomizer = Random.Range(0, 3);
        WeaponRandomizer = Random.Range(0, 3);
        HealthRandomizer = Random.Range(1, 7);

        HealthRand = HealthRandomizer * 20;

        playerHealth.health = HealthRand;

        Debug.Log(HealthRand);

    }
}
