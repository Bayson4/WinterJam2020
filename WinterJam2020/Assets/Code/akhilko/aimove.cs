using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aimove : MonoBehaviour
{
    private Vector3 posA;
    private Vector3 aim;
    private float distance;
    private Vector3 playerPos;
    private float distToTarget;
    GameObject Dummy;
    RaycastHit hit;
    [SerializeField]
    GameObject bullet;
    float fireRate;
    float nextFire;
    bool direction = true;

    public Vector3 posB;
    public Vector3 posC;
    public Vector3 posD;
    public float speed;
    public float engageRange;

    //[SerializeField] private Transform pfBullet;
    // Start is called before the first frame update
    void Start()
    {
        posA = this.transform.position;
        this.transform.LookAt(posB);
        aim = posB;
        Dummy = GameObject.FindGameObjectWithTag("Player");
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
            else if (aim == posB && direction)
                aim = posC;
            else if (aim == posC && direction)
            {
                aim = posD;
                direction = false;
            }
            else if (aim == posD)
                aim = posC;
            else if (aim == posC && !direction)
                aim = posB;
            else if (aim == posB && !direction)
            {
                aim = posA;
                direction = true;
            }
        }
        playerPos = Dummy.transform.position;
        distToTarget = Vector3.Distance(this.transform.position, playerPos);
    }

    void Behaviour()
    {
        GetDistance();
        if (distToTarget <= engageRange)
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
        this.transform.Translate(Vector3.forward * Time.deltaTime * speed);
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
            Instantiate(bullet, this.transform.position, this.transform.rotation).GetComponent<Bullet>().Move();
            nextFire = Time.time + fireRate;
        }
    }
}
