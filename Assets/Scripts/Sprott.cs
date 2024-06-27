using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Sprott : MonoBehaviour
{
    [SerializeField] LineRenderer line;
    [SerializeField] TMP_InputField[] colourInputs;
    public GameObject esfera;
    float[] colourValues = new float[6];
    float nextStep = 0.0f;
    public float stepRate = 0.01f;
    public float a = 1.07f;
    public float b = 1.79f;
    public float c = 1.6f;
    float x = 0.1f;
    float y = 0.1f;
    float z = 0f;

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

            float dt = 0.01f;
            float dx = (y) * dt;
            float dy = (z) * dt;
            float dz = (-x+y*y-z) * dt;
            x += dx;
            y += dy;
            z += dz;

            line.positionCount++;
            line.SetPosition(line.positionCount - 1, new Vector3(x, y, z));
            esfera.transform.Translate( new Vector3(dx, dy, dz));
        }
    }

 

    
}
