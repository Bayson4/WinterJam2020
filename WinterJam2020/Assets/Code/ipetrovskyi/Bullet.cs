using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour

{
    public float speed = 8f;
    public bool inverted = false;
    public bool spawned = false;
    public bool enemyBullet = false;
    public GameObject impactEffect;
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
        if (collision.gameObject.tag == "Enemy" && !enemyBullet)
        {
            collision.gameObject.GetComponent<aimove>().Death();
            Destroy(collision.gameObject, 2f);
            Destroy(this.gameObject, 2f);
        }
        if (collision.gameObject.tag == "Player" && enemyBullet)
        {
            collision.gameObject.GetComponent<HealthSystem>().Death();
            Destroy(this.gameObject);
        }
        if (inverted && !spawned)
        {
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "Finish")
        {
            Destroy(this.gameObject);
        }
        else 
        {
            if(!enemyBullet)
                Instantiate(impactEffect, this.GetComponent<Rigidbody>().transform.position, transform.localRotation);
        }
    }
}
