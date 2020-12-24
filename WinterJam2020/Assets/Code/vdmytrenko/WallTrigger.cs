using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTrigger : MonoBehaviour
{
    [SerializeField]
    private BulletController controller;


    public void OnCollisionEnter(Collision collision)
    {
        var obj = collision.gameObject;
        if (obj.tag == "bullet")
        {
            controller.SpawnBullet(new Vector3(-obj.transform.position.x, obj.transform.position.y, obj.transform.position.z));
            obj.GetComponent<sample>().flag = false;
        }
    }
}