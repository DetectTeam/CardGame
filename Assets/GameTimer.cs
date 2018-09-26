using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour 
{

	[SerializeField] private TextMeshProUGUI timerText;

	private void OnEnable()
	{
		Messenger.AddListener( "StartTimer", StartTimer );
		Messenger.AddListener( "StopTimer", StopTimer );
	}
	private void OnDisable()
	{
		Messenger.RemoveListener( "StartTimer", StartTimer );
		Messenger.RemoveListener( "StopTimer", StopTimer );
	}
	
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	private void StartTimer()
	{
		Debug.Log( "Starting Timer" );
		timerText.gameObject.SetActive( true );
	}

	private void StopTimer()
	{
		Debug.Log( "Stopping Timer" );
		timerText.gameObject.SetActive( false );
	}
}
