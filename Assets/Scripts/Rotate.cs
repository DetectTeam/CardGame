using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour 
{

	private float x;
    private float z;

	private float y;
    private bool rotateY;
    [SerializeField] private float rotationSpeed;

    void Start()
    {
        x = 0.0f;
        z = 0.0f;
		y = 0.0f;
        rotateY = false;
        rotationSpeed = 250.0f;

    }

    void FixedUpdate()
    {

        if( rotateY ) 
        {
            y += Time.deltaTime * rotationSpeed;
            transform.localRotation = Quaternion.Euler(0, y, 0);
        }
       
        
    }

    public void StartRotation()
    {
        Debug.Log( "Starting Rotation" );
        rotateY = true;
    }

    public void StopRotation()
    {
         Debug.Log( "Stopping Rotation " + y );

        rotateY = false;
    }

   

}
