using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenubuttons : MonoBehaviour
{
   
    public void NewGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void Exit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
