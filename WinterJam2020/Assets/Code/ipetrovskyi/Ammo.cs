using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public int max;
    private int current;

    void Start()
    {
        current = max;
    }

    void Update()
    {

    }

    public int GetCurrentAmount()
    {
        return current;
    }

    public bool Decrease()
    {
        if (current > 0)
        {
            current--;
            return true;
        }
        return false;
    }

    public bool Increase()
    {
        if (current < max)
        {
            current++;
            return true;
        }
        return false;
    }
}
