using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteBullet : MonoBehaviour
{
    private Vector3 startPosition;
    void Start()
    {
        startPosition = this.GetComponent<Rigidbody>().transform.position;
    }

    void Update()
    {
        float distance = Vector3.Distance(startPosition, this.GetComponent<Rigidbody>().transform.position);
        if (distance > 100)
        {
            Destroy(this.gameObject);
        }
    }
}
