using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Rossler1 : MonoBehaviour
{
    [SerializeField] LineRenderer line;
    [SerializeField] TMP_InputField[] colourInputs;
    public GameObject esfera;
    
    float nextStep = 0.0f;
    public float stepRate = 0.01f;
    public float a = 0.2f;
    public float b = 0.2f;
    public float c = 5.7f;
    float x = 0.01f;
    float y = 0;
    float z = 0;

    private void Update()
    {
        CameraMovement();
        Rossler1CalculationCalculation();
        
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

    private void Rossler1CalculationCalculation()
    {
        if (Time.time > nextStep)
        {
            nextStep = Time.time + stepRate;

            float dt = 0.01f;
            float dx = ((-1)*y-z) * dt;
            float dy = (x+a*y) * dt;
            float dz = (b+z*(x-c)) * dt;
            x += dx;
            y += dy;
            z += dz;

            line.positionCount++;
            line.SetPosition(line.positionCount - 1, new Vector3(x, y, z));
            esfera.transform.Translate( new Vector3(dx, dy, dz));
        }
    }

 

    
}
