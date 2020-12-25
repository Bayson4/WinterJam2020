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

    [SerializeField]
    GameObject victory;

    [SerializeField]
    private List<aimove> ais;

    private float step;
    public int duration = 60;
    public int timeRemaining;
    public bool isCountingDown;

    private bool isDead;
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
        isDead = false;
        isCountingDown = false;
        isInverted = false;
        timeRemaining = duration;
        step = 1f / (float)duration;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsDeath())
            TriggerLoseScreen();
        if (IsWon() && Time.timeScale != 0)
            TriggerVictoryScreen();
    }
    public void ChangeToInverted()
    {
        isInverted = true;
    }
    private bool IsDeath()
    {
        if (timeRemaining <= 0 || health.HP == 0)
        {
            return true;
        }
        else return false;
    }
    private bool IsWon()
    {
        for(int i = 0; i < ais.Count; i++)
            if(ais[i].alive)
                return false;
        return true;
    }
    private void TriggerLoseScreen()
    {
        if (!isDead)
        {
            Time.timeScale = 0;
            isDead = true;
        }
        deathScreen.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    private void TriggerVictoryScreen()
    {
            victory.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
    }
}
