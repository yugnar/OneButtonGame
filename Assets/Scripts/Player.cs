using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float thrust;
    public Rigidbody2D rb;

    public GameObject bullet;
    private SpriteRenderer shipRenderer;

    private int lives = 5;
    private bool gameActive = false;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        shipRenderer = gameObject.GetComponent<SpriteRenderer>();
        InvokeRepeating("Shoot", 1f, 0.3f);
    }

    void FixedUpdate()
    {
        //var position = gameObject.transform.position;
        //gameObject.transform.position = position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !gameActive)
        {
            gameActive = true;
            shipRenderer.enabled = true;
        }
        if (gameActive)
        {
            rb.gravityScale = 1f;
        }
        if (Input.GetKeyDown(KeyCode.Space) && gameActive)
        {
            rb.AddForce(new Vector2(0, thrust), ForceMode2D.Impulse);
        }
        if(lives == 0)
        {
            GManager.instance.protocolEndgame();
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collisionObject)
    {
        if (collisionObject.gameObject.CompareTag("Missile") || collisionObject.gameObject.CompareTag("Meteor") || collisionObject.gameObject.CompareTag("EnemyShip") || collisionObject.gameObject.CompareTag("Planet"))
        {
            lives = lives - 1;
            GManager.instance.updateHP(lives);
            damageDisplay();
        }
        else if (collisionObject.gameObject.CompareTag("DeathZone"))
        {
            lives = 0;
            GManager.instance.updateHP(lives);
            damageDisplay();
        }
    }

    void damageDisplay()
    {
        shipRenderer.color = new Color(0.8509804f, 0.1882353f, 0.1882353f);
        Invoke("colorNormalize", 1.0f);
    }

    void colorNormalize()
    {
        shipRenderer.color = Color.white;
    }

    void Shoot()
    {
        if (gameActive)
        {
            GameObject bulletInstance = Instantiate(bullet, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.Euler(0, 0, -90));
        }
    }
}
