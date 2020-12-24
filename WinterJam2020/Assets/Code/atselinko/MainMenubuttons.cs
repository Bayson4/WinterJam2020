using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenubuttons : MonoBehaviour
{
   
    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }


    public void Exit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
