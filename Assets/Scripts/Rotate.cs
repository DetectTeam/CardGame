using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour 
{

	private float x;
    private float z;

	private float y;
    private bool rotateX;
    private float rotationSpeed;

    void Start()
    {
        x = 0.0f;
        z = 0.0f;
		y = 0.0f;
        rotateX = true;
        rotationSpeed = 100.0f;
    }

    void FixedUpdate()
    {
        y += Time.deltaTime * rotationSpeed;

        if (y > 360.0f)
        {
            y = 0.0f;
           
        }
       
        transform.localRotation = Quaternion.Euler(0, y, 0);
    }

}
