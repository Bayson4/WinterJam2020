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
    private AudioSource gunReFired;
    private Ammo ammoController;

    [SerializeField]
    SceneController controller;

    void Start()
    {
        laserLine = GetComponent<LineRenderer>();
        fpsCam = GetComponentInParent<Camera>();
        gunFired = GetComponents<AudioSource>()[0];
        gunReFired = GetComponents<AudioSource>()[1];
        ammoController = GetComponent<Ammo>();
        gunFired.volume = .03f;
    }

    void Update()
    {
        if (Time.timeScale != 0)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time > nextFire && !controller.isInverted && ammoController.GetCurrentAmount() > 0)
            {
                nextFire = Time.time + fireRate;
                StartCoroutine(ShotEffect());

                Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
                RaycastHit hit;

                laserLine.SetPosition(0, gunEnd.position);

                ammoController.Decrease();
                Instantiate(bulletPrefab, gunEnd.position, this.transform.rotation).GetComponent<Bullet>().Move();

                if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, weaponRange))
                {
                    laserLine.SetPosition(1, hit.point);
                    //Debug.Log(hit.point.ToString());
                    //Debug.Log(hit.normal.ToString());
                    Instantiate(bulletDestination, hit.point, Quaternion.LookRotation(hit.normal));
                }
                else
                {
                    laserLine.SetPosition(1, rayOrigin + (fpsCam.transform.forward * weaponRange));
                }
            }
            if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time > nextFire && controller.isInverted
                && ammoController.GetCurrentAmount() < ammoController.max)
            {
                nextFire = Time.time + fireRate;

                Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
                RaycastHit hit;

                laserLine.SetPosition(0, gunEnd.position);

                if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, weaponRange))
                {
                    Debug.Log(hit.point.ToString());
                    var closestBullet = FindClosestEnemy(hit.point);
                    if (closestBullet != null)
                    {
                        var bulletScript = closestBullet.GetComponent<Bullet>();
                        bulletScript.TransformTowards(gunEnd.position);
                        bulletScript.Move();
                        StartCoroutine(ShotEffect());
                        ammoController.Increase();
                    }
                }
                //else
                //{
                //    var closestBullet = FindClosestEnemy(gunEnd.position);
                //    var bulletScript = closestBullet.GetComponent<Bullet>();
                //    bulletScript.TransformTowards(gunEnd.position);
                //    bulletScript.Move();
                //}
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
            //Vector3 diff = go.transform.position - position;
            //float curDistance = diff.sqrMagnitude;
            float curDistance = Vector3.Distance(go.transform.position, position);
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        if (distance < 2f)
            return closest;
        else return null;
    }
    private IEnumerator ShotEffect()
    {
        if (controller.isInverted)
        {
            gunReFired.Play();
        }
        else
        {
            gunFired.Play();
        }
        muzzleFlash.Play();
        laserLine.enabled = true;
        yield return shotDuration;
        laserLine.enabled = false;
    }



}
