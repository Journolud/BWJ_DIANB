using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOnDeath : MonoBehaviour
{
    public GameObject[] drops;
    public int dropPercentage;
    public Transform second, third;
    
    public void dropPickUp()
    {
        if (Random.Range(1, 101) <= dropPercentage)
        {
            GameObject drop = drops[Random.Range(0, drops.Length)];
            Instantiate(drop, transform.position, Quaternion.identity);
            drop = drops[Random.Range(0, drops.Length)];
            Instantiate(drop, second.position, Quaternion.identity);
            drop = drops[Random.Range(0, drops.Length)];
            Instantiate(drop, third.position, Quaternion.identity);
        }
        
    }
}
