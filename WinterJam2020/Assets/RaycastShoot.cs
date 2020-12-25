using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastShoot : MonoBehaviour
{
    public int gunDamage = 1;
    public float fireRate = .25f;
    public float weaponRange = 50f;
    public float hitForce = 100f;
    public Transform gunEnd;
    public GameObject bulletDestination;
    public ParticleSystem muzzleFlash;
    public Transform bulletPrefab;

    private Camera fpsCam;
    private WaitForSeconds shotDuration = new WaitForSeconds(.07f);
    private LineRenderer laserLine;
    private float nextFire;
    private AudioSource gunFired;

    void Start()
    {
        laserLine = GetComponent<LineRenderer>();
        fpsCam = GetComponentInParent<Camera>();
        gunFired = GetComponent<AudioSource>();
        gunFired.volume = .03f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            StartCoroutine(ShotEffect());

            Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;

            laserLine.SetPosition(0, gunEnd.position);

            Instantiate(bulletPrefab, gunEnd.position, this.transform.rotation).GetComponent<Bullet>().Move();
            if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, weaponRange))
            {
                laserLine.SetPosition(1, hit.point);
                Instantiate(bulletDestination, hit.point, Quaternion.LookRotation(hit.normal));
            }
            else
            {
                laserLine.SetPosition(1, rayOrigin + (fpsCam.transform.forward * weaponRange));
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse1) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            StartCoroutine(ShotEffect());

            Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;

            laserLine.SetPosition(0, gunEnd.position);

            //Instantiate(bulletPrefab, gunEnd.position, this.transform.rotation).GetComponent<Bullet>().Move();
            if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, weaponRange))
            {
                var closestBullet = FindClosestEnemy(hit.point);
                var bulletScript = closestBullet.GetComponent<Bullet>();
                //Debug.Log(gunEnd.position.ToString());
                bulletScript.TransformTowards(gunEnd.position);
                bulletScript.Move();
                //Destroy(closestBullet);
                //laserLine.SetPosition(1, hit.point);
                //Instantiate(bulletDestination, hit.point, Quaternion.LookRotation(hit.normal));
            }
            else
            {
                Debug.Log("CANT FIND THE BULLET");
                //laserLine.SetPosition(1, rayOrigin + (fpsCam.transform.forward * weaponRange));
            }
        }
    }

    private GameObject FindClosestEnemy(Vector3 position)
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("bullet");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }

    private IEnumerator ShotEffect()
    {
        gunFired.Play();
        muzzleFlash.Play();
        laserLine.enabled = true;
        yield return shotDuration;
        laserLine.enabled = false;
    }
}
