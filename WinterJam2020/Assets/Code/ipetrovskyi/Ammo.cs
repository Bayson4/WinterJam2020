using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public int max;
    private int current;
    public GameObject bullets;
    public GameObject bulletIcon;

    void Start()
    {
        current = max;
        for (int i = 0; i < max; i++)
        {
            if (bullets.transform.childCount > 0)
            {
                var lastChild = bullets.transform.GetChild(bullets.transform.childCount - 1);
                var position = new Vector3(lastChild.position.x, lastChild.position.y + 25f, lastChild.position.z);
                GameObject newSelected = Instantiate(bulletIcon, position, Quaternion.Euler(new Vector3(0, 0, -52.647f))) as GameObject;
                newSelected.transform.parent = bullets.transform;
                newSelected.transform.localScale = new Vector3(1, 1, 1);

            }
            else
            {
                GameObject newSelected = Instantiate(bulletIcon, bullets.transform.position, Quaternion.Euler(new Vector3(0, 0, -52.647f))) as GameObject;
                newSelected.transform.parent = bullets.transform;
                newSelected.transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }

    void Update()
    {

    }

    public int GetCurrentAmount()
    {
        return current;
    }

    public bool Decrease()
    {

        if (current > 0)
        {
            Destroy(bullets.transform.GetChild(bullets.transform.childCount - 1).gameObject);
            current--;
            return true;
        }
        return false;
    }

    public bool Increase()
    {
        if (current < max)
        {
            current++;
            if (bullets.transform.childCount > 0)
            {
                var lastChild = bullets.transform.GetChild(bullets.transform.childCount - 1);
                var position = new Vector3(lastChild.position.x, lastChild.position.y + 25f, lastChild.position.z);
                GameObject newSelected = Instantiate(bulletIcon, position, Quaternion.Euler(new Vector3(0, 0, -52.647f))) as GameObject;
                newSelected.transform.parent = bullets.transform;
                newSelected.transform.localScale = new Vector3(1, 1, 1);

            }
            else
            {
                GameObject newSelected = Instantiate(bulletIcon, bullets.transform.position, Quaternion.Euler(new Vector3(0, 0, -52.647f))) as GameObject;
                newSelected.transform.parent = bullets.transform;
                newSelected.transform.localScale = new Vector3(1, 1, 1);
            }
            return true;
        }
        return false;
    }
}
