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
    // Start is called before the first frame update
    void Start()
    {
        posA = this.transform.position;
        this.transform.LookAt(posB);
        aim = posB;
    }

    // Update is called once per frame
    void Update()
    {
            this.GetDistance();
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(aim - this.transform.position), 5 * Time.deltaTime);
            this.transform.Translate(Vector3.forward * Time.deltaTime);
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
    }
}
