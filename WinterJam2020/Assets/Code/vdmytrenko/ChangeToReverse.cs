using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeToReverse : MonoBehaviour
{
    [SerializeField]
    private SceneController controller;
    [SerializeField]
    private GameObject wall;
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
            controller.ChangeToInverted();
            controller.BeginCounting();
            wall.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
