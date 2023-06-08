using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelLoad = "SampleScene";
  public void Play ()
    {
        SceneManager.LoadScene(levelLoad);
    }

    // Update is called once per frame
    public void Quit()
    {
        Application.Quit();

    }

}
