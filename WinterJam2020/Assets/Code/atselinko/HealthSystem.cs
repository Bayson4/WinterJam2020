using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public int HP = 100;
    

    private void Death()
    {
        HP -= 100;
    }
}
