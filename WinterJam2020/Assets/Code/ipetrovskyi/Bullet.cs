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
    public void TransformTowards(Vector3 gunEndPos)
    {
        var _direction = (gunEndPos - transform.position).normalized;
        var _lookRotation = Quaternion.LookRotation(_direction);
        this.GetComponent<Rigidbody>().transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, 100); ;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Finish")
            Destroy(this.gameObject);
    }
}
