using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public bool isInverted;

    public int duration = 60;
    public int timeRemaining;
    public bool isCountingDown = false;
    public void BeginCounting()
    {
        if (!isCountingDown)
        {
            isCountingDown = true;
            Invoke("_tick", 1f);
        }
    }

    private void _tick()
    {
        timeRemaining--;
        if (timeRemaining > 0)
        {
            Invoke("_tick", 1f);
        }
        else
        {
            isCountingDown = false;
        }
    }
    void Start()
    {
        isInverted = false;
        timeRemaining = duration;
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
        if (timeRemaining <= 0)
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
