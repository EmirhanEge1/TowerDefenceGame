using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{

    public GameObject pauseUi;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            Toggle();
        }
    }
    public void Toggle()

    {
        pauseUi.SetActive(!pauseUi.activeSelf);

        if (pauseUi.activeSelf)
        {
            Time.timeScale = 0f;
            

        }
        else
        {
            Time.timeScale = 1f;
        }
    }
    public void Retry ()
    {
        Toggle();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 

    }
    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");


    }
}

