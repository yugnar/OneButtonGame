using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public float destroyTime = 10f;
    private int lives = 5;

    void Start()
    {
        Destroy(gameObject, destroyTime);
    }


    void Update()
    {
        var position = gameObject.transform.position;
        position.x += -0.12f;
        gameObject.transform.position = position;

        if(lives == 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collisionObject)
    {
        if (collisionObject.gameObject.CompareTag("PlayerShip"))
        {
            Destroy(gameObject);
        }
        if (collisionObject.gameObject.CompareTag("Bullet"))
        {
            lives = lives - 1;
        }
    }
}
