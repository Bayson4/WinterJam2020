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
    float defaultSpeed;

    public Vector3 posB;
    public Vector3 posC;
    public Vector3 posD;
    public float speed;
    public float engageRange;
    public float shootingRange;

    static Animator anim;

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
        anim = GetComponent<Animator>();
        defaultSpeed = speed;
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
            else if ((aim == posB && direction) || (aim == posD))
                aim = posC;
            else if ((aim == posC && direction && posD!=Vector3.zero) || (aim == posB && direction && posC == Vector3.zero))
            {
                aim = posD;
                direction = false;
            }
            else if ((aim == posC && direction && posD == Vector3.zero) || (aim == posC && !direction))
            {
                aim = posB;
                direction = false;
            }
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
                if (distToTarget >= shootingRange)
                    Engage();
                else
                    ShootTarget();
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
        this.speed = defaultSpeed;
        anim.SetBool("isEngaged", false);
        anim.SetBool("isAtRange", false);
    }

    void Engage()
    {
        this.transform.LookAt(new Vector3(playerPos.x, this.transform.position.y, playerPos.z));
        this.transform.Translate(Vector3.forward * Time.deltaTime * speed * 2);
        anim.SetBool("isEngaged", true);
        anim.SetBool("isAtRange", false);
    }

    void Terminate()
    {
        if(Time.time > nextFire)
        {
            var temp = Instantiate(bullet, this.transform.position, this.transform.rotation);
            temp.GetComponent<Bullet>().Move();
            temp.GetComponent<Bullet>().enemyBullet = true;
            temp.GetComponent<Bullet>().inverted = true;
            nextFire = Time.time + fireRate;
        }
    }

    void ShootTarget()
    {
        anim.SetBool("isAtRange", true);
        Terminate();
    }

    public void Death()
    {
        anim.SetBool("isDead", true);
    }
}
