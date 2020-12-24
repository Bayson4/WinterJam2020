using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public bool isInverted;
    public float timerValue;
    void Start()
    {
        isInverted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsDeath())
            TriggerLoseScreen();
        if (IsWon())
            TriggerVictoryScreen();
    }
    public void ChangeToInverted()
    {
        isInverted = true;
    }
    private bool IsDeath()
    {
        if (timerValue <= 0)
            return true;
        else return false;
    }
    private bool IsWon()
    {
        return false;
    }
    private void TriggerLoseScreen()
    {
        Time.timeScale = 0;
        //
    }
    private void TriggerVictoryScreen()
    {
        //Time.timeScale = 0;
        //
    }
}
