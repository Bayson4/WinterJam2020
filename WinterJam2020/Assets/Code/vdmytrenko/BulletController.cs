using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;

    GameObject bullet;
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    public void SpawnBullet(Vector3 position)
    {
        bullet = Instantiate(bulletPrefab, position, Quaternion.identity);
        bullet.GetComponent<Bullet>().inverted = true;
        bullet.GetComponent<Bullet>().spawned = true;
        Invoke("delay", 1f);
        //bullet.GetComponent<Bullet>().StopMovement();
    }

    private void delay()
    {
        bullet.GetComponent<Bullet>().spawned = false;
    }
}
