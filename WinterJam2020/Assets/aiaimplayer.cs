using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aiaimplayer : MonoBehaviour
{
    public float distToTarget;
    GameObject Dummy;
    public Vector3 playerPos;
    // Start is called before the first frame update
    void Start()
    {
        Dummy = GameObject.Find("DummyPlayer");
        playerPos = Dummy.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        DistToTarget();
        //if (distToTarget <= 5.3)
        //{
        //    this.transform.LookAt(playerPos);
            
        //}
    }
    void DistToTarget()
    {
        playerPos = Dummy.transform.position;
        distToTarget = Vector3.Distance(this.transform.position, playerPos);
    }
}
