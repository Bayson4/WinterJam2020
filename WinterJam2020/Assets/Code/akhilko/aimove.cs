using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aimove : MonoBehaviour
{
    public Vector3 posA;
    public Vector3 posB;
    public Vector3 aim;
    public float speed;
    public float distance;

    public float distToTarget;
    GameObject Dummy;
    RaycastHit hit;
    public Vector3 playerPos;

    [SerializeField]
    GameObject bullet;
    float fireRate;
    float nextFire;


    //[SerializeField] private Transform pfBullet;
    // Start is called before the first frame update
    void Start()
    {
        posA = this.transform.position;
        this.transform.LookAt(posB);
        aim = posB;
        Dummy = GameObject.Find("DummyPlayer");
        playerPos = Dummy.transform.position;
        fireRate = 1f;
        nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        Behaviour();
    }

    void GetDistance()
    {
        distance = Vector3.Distance(this.transform.position, aim);
        if (distance <= 0.5)
        {
            if (aim == posA)
                aim = posB;
            else aim = posA;
        }
        playerPos = Dummy.transform.position;
        distToTarget = Vector3.Distance(this.transform.position, playerPos);
    }

    void Behaviour()
    {
        GetDistance();
        if (distToTarget <= 5.5)
        {
            Physics.Linecast(this.transform.position, playerPos, out hit);
            if (hit.collider.CompareTag("Player"))
            {
                Engage();
            }
            else
                Patrol();
        }
        else
            Patrol();
    }

    void Patrol()
    {
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(aim - this.transform.position), 5 * Time.deltaTime);
        this.transform.Translate(Vector3.forward * Time.deltaTime);
    }

    void Engage()
    {
        this.transform.LookAt(playerPos);
        this.transform.Translate(Vector3.forward * Time.deltaTime);
        Terminate();
    }

    void Terminate()
    {
        if(Time.time > nextFire)
        {
            Instantiate(bullet, this.transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }
}
