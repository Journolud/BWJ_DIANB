using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public string direction;
    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.gameObject.name);
        Debug.Log(direction);
        if (col.gameObject.name == "Player")
        {
            if (direction == "up")
            {
                col.transform.Translate(Vector2.up * 8, Space.World);
                Camera.main.transform.Translate(0, 13, 0);
            }
            else if (direction == "down")
            {
                col.transform.Translate(Vector2.up * -8, Space.World);
                Camera.main.transform.Translate(0, -13, 0);
            }
            else if (direction == "right")
            {
                col.transform.Translate(9, 0, 0, Space.World);
                Camera.main.transform.Translate(20, 0, 0);
            }
            else if (direction == "left")
            {
                col.transform.Translate(Vector2.right * -9, Space.World);
                Camera.main.transform.Translate(-20, 0, 0);
            }
        }
    }
}
