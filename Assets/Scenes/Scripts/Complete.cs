using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Complete : MonoBehaviour

    
{
    public SceneFader sceneFader;

    public void Continue ()
    {
        SceneManager.LoadScene("Level Editor");


    }
    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
