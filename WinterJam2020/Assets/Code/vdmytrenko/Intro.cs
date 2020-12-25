using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{
    
    void Start()
    {
        Invoke("LoadMenu", 13f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            UnityEngine.SceneManagement.SceneManager.LoadScene("Main Menu");
    }
    private void LoadMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main Menu");
    }
}
