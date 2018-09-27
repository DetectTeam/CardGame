using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floater : MonoBehaviour 
{

	[SerializeField] private Vector3 floatY;
	[SerializeField] private float originalY;
	[SerializeField] private float originalX;

	[SerializeField] private float floatStrength;

	

	// Use this for initialization
	void Start () 
	{
		originalY = this.transform.position.y;
		originalX = this.transform.position.x;
	}
	
	// Update is called once per frame
	void Update () 
	{
		float yValue = originalY + ( Mathf.Sin( Time.time ) * floatStrength );
		//float xValue = originalX + (Mathf.Sin(Time.time) * floatStrength);

		transform.position = new Vector3( transform.position.x , yValue , transform.position.z );
	}
}
