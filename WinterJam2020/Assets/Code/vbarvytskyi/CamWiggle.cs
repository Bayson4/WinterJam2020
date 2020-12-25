using UnityEngine;
using System.Collections;


public class CamWiggle : MonoBehaviour
{

    public float targetTime = 0.2f;
    public float Smooth = 10;
    public float AmplitudeHeight = 0.1f;
    public float AmplitudeRot = 1.5f; 

    private float Progress;
    private int PassedStep = 1;
    private float DefCamPos = 0;
    private float DefCamRot = 0;
    private Transform MyTransform;


    void Start()
    {
        MyTransform = transform;
        DefCamPos = MyTransform.localPosition.y;
        DefCamRot = MyTransform.localEulerAngles.z;
    }


    void Update()
    {
        float Pssd = Passed();

        
        Vector3 GoalPos = new Vector3(MyTransform.localPosition.x, Pssd * AmplitudeHeight + DefCamPos, MyTransform.localPosition.z);
        
        MyTransform.localPosition = Vector3.Lerp(MyTransform.localPosition, GoalPos, Time.deltaTime * Smooth);


        
        if (Mathf.Abs(Input.GetAxis("Horizontal")) == 1 && Mathf.Abs(Input.GetAxis("Vertical")) == 0)
        {
            Pssd = 0;
        }
        Vector3 GoalRot = new Vector3(MyTransform.localPosition.x, MyTransform.localPosition.y, Pssd * AmplitudeRot + DefCamRot);
        
        MyTransform.localEulerAngles = Vector3.Lerp(MyTransform.localPosition, GoalRot, Time.deltaTime * Smooth);
    }


    private float Passed()
    {

        
        
        if (Mathf.Abs(Input.GetAxis("Horizontal")) == 0 && Mathf.Abs(Input.GetAxis("Vertical")) == 0)
        {
            PassedStep = 1;
            return (Progress = 0);
        }

        
        
        
        Progress += (Time.deltaTime * (1f / targetTime)) * PassedStep;
        if (Mathf.Abs(Progress) >= 1)
        { 
            PassedStep *= -1;
        }

        
        return Progress;
    }
}