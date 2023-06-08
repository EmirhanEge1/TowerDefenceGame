using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class GameOver : MonoBehaviour
{

    public SceneFader sceneFader;
    public Text roundsCount;
    void OnEnable ()
    {

        roundsCount.text = PlayerStats.rounds.ToString();
    }
    public void Retry() {
       
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Menu() {
        SceneManager.LoadScene("MainMenu");

    }
}
