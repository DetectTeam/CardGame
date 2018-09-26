using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStages : MonoBehaviour 
{

	[SerializeField] private TextMeshProUGUI messageText;

	private void OnEnable()
	{
		Messenger<string>.AddListener( "SetMessage" , SetMessage );
	}

	private void OnDisable()
	{
		Messenger<string>.RemoveListener( "SetMessage" , SetMessage );
	}

	private void SetMessage( string message )
	{
		messageText.text = message;
	}
}
