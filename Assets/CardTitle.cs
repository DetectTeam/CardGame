using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardTitle : MonoBehaviour 
{
	[SerializeField] private Text title;

	private void OnEnable()
	{
		Messenger<string>.AddListener( "SetTitle" , SetTitle );
	}
	

	private void OnDisable()
	{
		Messenger<string>.RemoveListener( "SetTitle" , SetTitle );
	}

	private void SetTitle( string message )
	{
		title.text = message;
	}
}
