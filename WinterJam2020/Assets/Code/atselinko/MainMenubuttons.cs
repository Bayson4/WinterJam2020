using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenubuttons : MonoBehaviour
{

    [SerializeField]
    private GameObject cred;
    public void NewGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Final");
    }


    public void Exit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void OpenCreds()
    {
        cred.SetActive(true);
    }
    public void CloseCreds()
    {
        cred.SetActive(false);
    }
}
