using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGameManager : BaseGameManager 
{
	[SerializeField] private Rotate rotator;
	[SerializeField] private float transitionTime = 0.9f; // The Amout ot time to flip the card
	[SerializeField] private float timeToMemorize = 2.0f; // The Amount of time to memorize the shapes on the card
	[SerializeField] private float guessTime = 5.0f; // The Amount of time to guess if shapes match or not
	[SerializeField] private SwipeManager swipeManager; //Script that manages all swipe input

	[SerializeField] private int userDecision;
	


	private void OnEnable()
	{
		Messenger<int, bool>.AddListener( "UserDecision" , UserDecision );
	}

	private void OnDisable()
	{
		Messenger<int, bool>.RemoveListener( "UserDecision" , UserDecision );
	}

    public override void Start()
    {
        base.Start();

		rotator = GameObject.Find( "Card" ).GetComponent<Rotate>();

		swipeManager = GetComponent<SwipeManager>();
		swipeManager.enabled = false;
    }

    public override IEnumerator StartLevelRoutine()
	{
		var baseVal = base.StartLevelRoutine();
    
		yield return StartCoroutine( baseVal );
	}

	public override IEnumerator PlayLevelRoutine()
	{
		var baseVal = base.PlayLevelRoutine();
		int levelCount = 0 ;
		float waitTime = 1.0f;
		float degrees  =  180.0f;
		float counter = 0.0f;

		while( levelCount < 2 )
		{
			userDecision = 0;

			yield return StartCoroutine( baseVal );

			Messenger<string>.Broadcast( "SetMessage" , "New Level" ); //Test Message
			
			yield return new WaitForSeconds( waitTime );

			Debug.Log( "Entering Memory Phase." );
			Messenger<string>.Broadcast( "SetMessage" , "Memory Phase" ); //Test Messages
			
			//Memory phase . Show user card face for 2 seconds
			Messenger<float,float>.Broadcast( "RotateCard", ( waitTime * 0.5f ) , 0 );

			yield return new WaitForSeconds( waitTime * 0.1f );
			Messenger<int>.Broadcast( "LoadCard" ,  levelCount );
			//Messenger<string>.Broadcast( "SetTitle" , "Level " + levelCount );
			yield return new WaitForSeconds( waitTime * 0.4f );

			yield return new WaitForSeconds( timeToMemorize ); // 2 seconds to memorize the shapes

			//Memory Phase Ends


			//Rotate 0.9 seconds
			Messenger<float,float>.Broadcast( "RotateCard", 0.45f , 0 );

			yield return new WaitForSeconds( 0.55f );  //Flip the card in 0.9 seconds

			Debug.Log( "Entering Guess Phase" );
			
			Messenger<string>.Broadcast( "SetMessage" , "Guess Phase" ); //Test Messages
			Messenger<float,float>.Broadcast( "RotateCard", 0.35f , 0 );
			
			
			yield return new WaitForSeconds( 0.05f );

			Messenger<int>.Broadcast( "LoadMatchCard" , levelCount ); //Load the Match card
			
			yield return new WaitForSeconds( 0.3f );

			

			
			
			//Guess Phase
		
			Messenger.Broadcast( "StartTimer" ); //Start Count Down

			//yield return new WaitForSeconds( guessTime );  //Guess time 5 seconds.
			//Wait for user to make decision . 5 seconds by default
			
			swipeManager.enabled = true; // Enable Touch Controls
			while( counter <= guessTime )
			{
				
				if( userDecision > 0 ) //User has made a decision and swiped
				{
					Messenger.Broadcast( "StopTimer" );

					if( userDecision == 1 )  //User is incorrect
					{
						
						Messenger<string>.Broadcast( "SetMessage" , "WRONG!" ); //Test Messages
					
					}
					else if( userDecision == 2 ) //User is Correct
					{
						Messenger<string>.Broadcast( "SetMessage" , "CORRECT!!" ); //Test Messages
					}

				    Messenger.Broadcast( "StopTimer" );  //Stop the timer 
					yield return new WaitForSeconds( 1.0f ); //wait for the card movement action to complete
					
					//Reset Card Position
					Messenger.Broadcast( "ResetCard" );
					
					break;
					
				}
				
				counter += Time.deltaTime;  //Increment time counter 
				yield return null;
			}

			swipeManager.enabled = false; // Disable Touch Controls

			counter = 0;

			if( userDecision == 0 ) //if the user made no decision . Automatically Wrong. Lose points 
			{
	
				Messenger<string>.Broadcast( "SetMessage" , "Times Up" ); //Test Messages
				Messenger.Broadcast( "StopTimer" ); //Stop the countdown timer
			}

		
			Messenger<float,float>.Broadcast( "RotateCard", 0.45f , 0 );

			Messenger<string>.Broadcast( "SetMessage" , "New Level" ); //Test Messages

			yield return new WaitForSeconds( 3.0f );

			levelCount ++;

		}

		Messenger<string>.Broadcast( "SetMessage" , "Completed All Tasks" );


		//Messenger.Broadcast( "ShowPrompt" );

	}

	private void UserDecision( int b , bool isMatch )
	{
		if( b == 1 && !isMatch )
			userDecision = 2;
		else if( b == 1 && isMatch )
			userDecision = 1;
		else if( b == 2 && isMatch )
			userDecision = 2;
		else if( b == 2 && !isMatch )
			userDecision = 1;
		else
			userDecision = 0;
	}
	
}
