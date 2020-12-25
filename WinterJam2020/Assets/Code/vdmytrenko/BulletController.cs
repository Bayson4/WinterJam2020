using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    public void SpawnBullet(Vector3 position)
    {
        var bullet = Instantiate(bulletPrefab, position, Quaternion.identity);
        //bullet.GetComponent<Bullet>().StopMovement();
    }
}
