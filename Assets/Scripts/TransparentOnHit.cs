using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparentOnHit : MonoBehaviour
{
    public float timeTransparent = 0;
    SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeTransparent > 0)
        {
            timeTransparent -= Time.deltaTime;
            if (timeTransparent <= 0)
            {
                sprite.color = new Color(1f, 1f, 1f, 1f);
            }
        }
    }

    public void RegisterHit()
    {
        timeTransparent = 0.2f;
        sprite.color = new Color(1f, 1f, 1f, 0.2f);
    }
}
