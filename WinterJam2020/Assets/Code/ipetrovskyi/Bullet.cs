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
    }
    public void StopMovement()
    {
        this.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
    public void Move()
    {
        this.GetComponent<Rigidbody>().AddForce(transform.forward * speed, ForceMode.Impulse);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Finish")
            Destroy(this.gameObject);
    }
}
