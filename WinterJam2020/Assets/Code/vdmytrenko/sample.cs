using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sample : MonoBehaviour
{
    [SerializeField]
    private float speed;
    public bool flag = true;
    void Start()
    {
        
    }
    
    void Update()
    {
        if (flag)
            this.transform.Translate(new Vector3(0,0, speed * Time.deltaTime));
    }
}
