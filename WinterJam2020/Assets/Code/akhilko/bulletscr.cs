using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletscr : MonoBehaviour
{
    Rigidbody rb;
    GameObject target;
    Vector3 moveDirection;
    float moveSpeed = 7f;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        target = GameObject.Find("DummyPlayer");
        moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
        rb.velocity = new Vector3(moveDirection.x, moveDirection.y, moveDirection.z);
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
