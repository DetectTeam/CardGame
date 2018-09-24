using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;


public class BaseGameManager : MonoBehaviour 
{

    	//Unity Events
	public UnityEvent setupEvent;
	public UnityEvent startLevelEvent;
	public UnityEvent playLevelEvent;
	public UnityEvent endLevelEvent;

	public static BaseGameManager Instance = null;

	private bool m_hasLevelStarted = false;


	public virtual void Awake()
	{
		if( Instance == null )
		{
			Instance = this;
		}
		else if( Instance != this )
		{
			Destroy( gameObject );
		}

		//DontDestroyOnLoad( gameObject );
	}

	public virtual void Start()
	{
		Debug.Log("Stuff....");
		StartCoroutine( "RunGameLoop" );
		
	}

	public IEnumerator RunGameLoop()
	{
		yield return null;
		Debug.Log( "Running game loop...." );
		yield return StartCoroutine("StartLevelRoutine");
		yield return StartCoroutine("PlayLevelRoutine");
		yield return StartCoroutine("EndLevelRoutine");
	}

	public virtual IEnumerator StartLevelRoutine()
	{
		
		if (setupEvent != null)
        {
            setupEvent.Invoke();
        }
		
		while ( !m_hasLevelStarted )
        {
            //show start screen
            // user presses button to start
            // HasLevelStarted = true
            yield return null;
        }

		// trigger events when we press the StartButton
        if (startLevelEvent != null)
        {
            startLevelEvent.Invoke();
        }
	}

	//Game Loop
	public virtual IEnumerator PlayLevelRoutine()
	{
		Debug.Log( "Play Level Routine Called ...." );
		
		if ( playLevelEvent != null )
        {
            playLevelEvent.Invoke();
        }

		yield return null;
	}

	public virtual IEnumerator EndLevelRoutine()
	{
		yield return null;
		Debug.Log( "End Level loop...." );
	}

	public void StartGame()
	{
		Debug.Log( "Starting Game...." );
		m_hasLevelStarted = true;

		
	}

	//Pause Game
	public void Pause()
	{
		Time.timeScale = 0;
	}

	//Resume Game
	public void Resume()
	{
		Time.timeScale = 1;
	}


}
