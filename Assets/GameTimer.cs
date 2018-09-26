using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour 
{

	[SerializeField] private TextMeshProUGUI timerText;
	[SerializeField] private bool isTimerRunning;


	private float t;

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
	private IEnumerator IECountDown()
	{
		float count = 5; 

		while( count > 0 )
		{
			count -= Time.deltaTime;
			timerText.text = count.ToString( "F2" );
			yield return null;
		}
	}

	private void StartTimer()
	{
		Debug.Log( "Starting Timer" );
		timerText.gameObject.SetActive( true );
		isTimerRunning = true;
		StartCoroutine( IECountDown() );
	}

	private void StopTimer()
	{
		Debug.Log( "Stopping Timer" );
		timerText.gameObject.SetActive( false );
		isTimerRunning = false;
	}
}
