using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    [SerializeField]
    HealthSystem health;
    [SerializeField]
    GameObject deathScreen;
    [SerializeField]
    RawImage HP;
    public bool isInverted;

    private float step;
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
        HP.rectTransform.localScale = new Vector3(HP.rectTransform.localScale.x, HP.rectTransform.localScale.y - step, HP.rectTransform.localScale.z);  
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
        step = 1f / (float)duration;
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
        if (timeRemaining <= 0 || health.HP == 0)
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
        deathScreen.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    private void TriggerVictoryScreen()
    {
        //Time.timeScale = 0;
        //
    }
}
