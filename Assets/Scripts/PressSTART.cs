using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressSTART : MonoBehaviour
{
    private SpriteRenderer text;
    private bool gameStartTextStatus;
    private bool blink;
    public GameObject instructions;
    // Start is called before the first frame update
    void Start()
    {
        gameStartTextStatus = true;
        blink = true;
        text = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (blink)
        {
            InvokeRepeating("StartGameText", 0.1f, 0.35f);
            blink = false;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(instructions);
            Destroy(gameObject);
        }
    }

    void StartGameText()
    {
        gameStartTextStatus = !gameStartTextStatus;
        text.enabled = gameStartTextStatus;
    }
}
