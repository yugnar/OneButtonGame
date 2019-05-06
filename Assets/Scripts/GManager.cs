using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GManager : MonoBehaviour
{
    public Text endgameText;
    public Text hpText;
    private bool gameoverTextStatus;
    private bool gameActive;

    public static GManager instance = null;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject); //So only one Game Manager can exist at a time.
        }
        gameoverTextStatus = false;
        gameActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !gameActive)
        {
            gameActive = true;
            hpText.gameObject.SetActive(true);
        }
    }

    public void protocolEndgame()
    {
        InvokeRepeating("GameOverText", 0.1f, 0.4f);
    }

    void GameOverText()
    {
        gameoverTextStatus = !gameoverTextStatus;
        endgameText.gameObject.SetActive(gameoverTextStatus);
    }

    public void updateHP(int lives)
    {
        hpText.text = "HP: " + lives;
    }
}
