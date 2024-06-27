using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Thomas : MonoBehaviour
{
    [SerializeField] LineRenderer line;
    [SerializeField] TMP_InputField[] colourInputs;
    public GameObject esfera;
    float[] colourValues = new float[6];
    float nextStep = 0.0f;
    public float stepRate = 0.01f;
   public float a = 0.208f;
    public float b = 5.0f;
    public float c = 0.5f;
    public float d = 0.5f;
    float x = 0.01f;
    float y = 0;
    float z = 0;

    private void Update()
    {
        CameraMovement();
        LorenzCalculation();
        
    }

    private void CameraMovement()
    {
        Camera.main.transform.LookAt(new Vector3(0, 0, 25));

        if (Input.GetKey(KeyCode.A))
        {
            Camera.main.transform.RotateAround(new Vector3(0, 0, 25), Vector3.up, 40 * Time.deltaTime);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            Camera.main.transform.RotateAround(new Vector3(0, 0, 25), -Vector3.up, 40 * Time.deltaTime);
        }
       

        if (Input.GetKey(KeyCode.W))
        {
            Camera.main.transform.RotateAround(new Vector3(25, 25, 0), Vector3.up, 40 * Time.deltaTime);
        }

        else if (Input.GetKey(KeyCode.S))
        {
            Camera.main.transform.RotateAround(new Vector3(25, 25, 0), -Vector3.up, 40 * Time.deltaTime);
        }
    }

    private void LorenzCalculation()
    {
        if (Time.time > nextStep)
        {
            nextStep = Time.time + stepRate;

            float dt = 0.005f;
            float dx = (Mathf.Sin(a * y) - x) * dt;
            float dy = (Mathf.Sin(b * z) - y) * dt;
            float dz = (Mathf.Sin(c * x) - z) * dt;
            x += dx;
            y += dy;
            z += dz;

            line.positionCount++;
            line.SetPosition(line.positionCount - 1, new Vector3(x*50, 50*y, 50*z));
            esfera.transform.Translate( new Vector3(dx, dy, dz));
        }
    }

 

    
}
