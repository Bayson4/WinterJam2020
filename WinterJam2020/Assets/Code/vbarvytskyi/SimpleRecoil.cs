using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRecoil : MonoBehaviour
{
    public Vector3 upRecoil;
    Vector3 originalrotation;
    // Start is called before the first frame update
    void Start()
    {
        originalrotation = transform.localEulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            AddRecoil();
        else if (Input.GetKeyUp(KeyCode.Mouse0))
            StopRecoil();
    }

    private void AddRecoil()
    {
        transform.localEulerAngles += upRecoil;
    }

    private void StopRecoil()
    {
        transform.localEulerAngles = originalrotation;
    }
}