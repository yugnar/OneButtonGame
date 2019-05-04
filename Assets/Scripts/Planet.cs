using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public float destroyTime = 12f;

    void Start()
    {
        Destroy(gameObject, destroyTime);
    }


    void Update()
    {
        var position = gameObject.transform.position;
        position.x += -0.055f;
        gameObject.transform.position = position;
    }
}
