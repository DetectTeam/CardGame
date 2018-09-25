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

    void OnEnable()
    {
        Messenger<float, float>.AddListener( "RotateCard", RotateCard );
       
    }

    void OnDisable()
    {
        Messenger<float, float>.RemoveListener( "RotateCard", RotateCard );
        
    }

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

        // if( rotateY &&  y < 180 ) 
        // {
        //     y += Time.deltaTime * rotationSpeed;

        //     if( y >= 360 )
        //     {
        //         y = 0;
        //     }
            
        //     transform.localRotation = Quaternion.Euler(0, y, 0);
        // }

         //if( rotateY )
           // iTween.RotateTo( gameObject, new Vector3( 0, 180.0f, 0 ), 0.6f );
       
        
    }

    public void RotateCard( float time , float deg  )
    {
        Debug.Log( "ROTATING CARD..........." );
        iTween.RotateAdd( gameObject, new Vector3( 0, 180.0f, 0 ), time );
        rotateY = true;
    }

   

}
