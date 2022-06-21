using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieAfterSetTime : MonoBehaviour
{
    private float timeElapsed = 0;
    public float lifespan;

    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed > lifespan)
        {
            Destroy(gameObject);
        }
    }
}
