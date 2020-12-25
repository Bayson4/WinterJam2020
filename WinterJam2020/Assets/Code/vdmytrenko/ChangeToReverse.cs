using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeToReverse : MonoBehaviour
{
    [SerializeField]
    private SceneController controller;
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("123");
            controller.ChangeToInverted();
            controller.BeginCounting();
            Destroy(this.gameObject);
        }
    }
}
