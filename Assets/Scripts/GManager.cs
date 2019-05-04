using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GManager : MonoBehaviour
{
    public Text endgameText; //WATCH AVENGERS ENDGAME ON 26/4/2019!!!! :)
    public Text hpText;
    private bool gameoverTextStatus;

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
    }

    // Update is called once per frame
    void Update()
    {
        
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
