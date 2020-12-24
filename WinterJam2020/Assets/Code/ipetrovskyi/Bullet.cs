using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        this.GetComponent<Rigidbody>().AddForce(transform.forward * speed, ForceMode.Impulse);
    }
    public void StopMovement()
    {
        this.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
