using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool endGame;
    public GameObject gameOver;
    public GameObject GameWon;
    // Start is called before the first frame update
    void Start()
    {
        endGame = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(endGame)
        {
            return;
        }
        if(Input.GetKeyDown("e"))
        {
            EndGame();
        }
        if(PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }
    void EndGame()
    {
        endGame = true;
        gameOver.SetActive(true);
    }
    public void WinLevel ()
    {
        endGame = true;
        GameWon.SetActive(true);
    }
}
