using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    public float destroyTime = 10f;
    public float verticalMovement = 0.08f;
    public GameObject enemyMissile;

    private int lives = 3;

    void Start()
    {
        Destroy(gameObject, destroyTime);
        InvokeRepeating("ShootMissile", 1.0f, 1.5f);
    }


    void Update()
    {
        var position = gameObject.transform.position;
        position.x += -0.06f;
        position.y += verticalMovement;
        if(position.y >= 4)
        {
            //Move down now
            verticalMovement = -0.08f;
        }
        else if(position.y <= -4.1)
        {
            //Move up now
            verticalMovement = 0.08f;
        }
        gameObject.transform.position = position;
        if (lives == 0)
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

    void ShootMissile()
    {
        GameObject missileInstance = Instantiate(enemyMissile, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.Euler(0, 0, 90));
    }
}
