using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestsRand : MonoBehaviour
{
    [SerializeField] Sprite OpenedChest1;
    [SerializeField] Sprite OpenedChest2;
    [SerializeField] GameObject medBox;
    [SerializeField] GameObject AmmoType;
    [SerializeField] GameObject MC;
    public int SpriteRand;
    public float x_pos;
    public float object_x;
    public float y_pos;
    public float object_y;
    private InputActions controls;
    public int PreSet;
    public bool enter = false;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Player")
        {
            enter = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Player")
        {
            enter = false;
        }
    }

    void Start()
    {
        controls = new InputActions();
            controls.Enable();
            controls.Player.PickUp.performed += _ => Open();

    }

    void RandomPos()
    {
        x_pos = transform.position.x;
        y_pos = transform.position.y;

        if (x_pos >= 0.1f)
        {
            object_x = x_pos - Random.Range(1.5f, 3f);
            object_y = y_pos + Random.Range(0f, 1f);
        }

        else if (x_pos <= -0.1f)
        {
            object_x = x_pos + Random.Range(1.5f, 3f);
            object_y = y_pos + Random.Range(0f, 1f);
        }
    }

    void Open()
    {
        if (enter)
        {
            Randomizer();
        }
    }

    void Randomizer()
    {
        SpriteRand = Random.Range(1, 4);

        GetComponent<BoxCollider2D>().enabled = false;
        
        if(SpriteRand == 2 || SpriteRand == 4)
        {
            GetComponent<SpriteRenderer>().sprite = OpenedChest1;
        }
         
        else if (SpriteRand == 1 || SpriteRand == 3)
        {
            GetComponent<SpriteRenderer>().sprite = OpenedChest2;
        }

        PreSet = Random.Range(1, 4);

        RandomPos();

        if (PreSet == 1)
        {
            SpawnAmmo();
        } 

        else if(PreSet == 2)
        {
            SpawnHealth();
        }

        else if(PreSet == 3)
        {
            SpawnAmmo();
            RandomPos();
            SpawnHealth();
        }

        else if(PreSet == 4)
        {
            RandomMc();
        }
    }

    void SpawnAmmo()
    {
        Instantiate(AmmoType, new Vector3(object_x, object_y, 0), Quaternion.identity);
    }

    void RandomMc()
    {
        Instantiate(MC, new Vector3(object_x, object_y, 0), Quaternion.identity);
    }

    void SpawnHealth()
    {
        Instantiate(medBox, new Vector3(object_x, object_y, 0), Quaternion.identity);
    }
}
