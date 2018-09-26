using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGameManager : BaseGameManager 
{

	[SerializeField] private Rotate rotator;
	[SerializeField] private float transitionTime = 0.9f; // The Amout ot time to flip the card
	[SerializeField] private float timeToMemorize = 2.0f; // The Amount of time to memorize the shapes on the card

	[SerializeField] private float guessTime = 5.0f; // The Amount of time to guess if shapes match or not

    public override void Start()
    {
        base.Start();

		rotator = GameObject.Find( "Card" ).GetComponent<Rotate>();
    }

    public override IEnumerator StartLevelRoutine()
	{
		var baseVal = base.StartLevelRoutine();
    
		yield return StartCoroutine( baseVal );

	}

	public override IEnumerator PlayLevelRoutine()
	{
		var baseVal = base.PlayLevelRoutine();
		float levelCount = 1;
		float waitTime = 1.0f;
		float degrees  =  180.0f;

		while( levelCount < 11 )
		{
			
			yield return StartCoroutine( baseVal );

			Messenger<string>.Broadcast( "SetMessage" , "New Level" );
			
			yield return new WaitForSeconds( waitTime );

		

			Debug.Log( "Entering Memory Phase." );
			Messenger<string>.Broadcast( "SetMessage" , "Memory Phase" ); //Test Messages
			Messenger<float,float>.Broadcast( "RotateCard", (waitTime * 0.5f) , 0 );

			yield return new WaitForSeconds( waitTime * 0.1f );
			Messenger<string>.Broadcast( "SetTitle" , "Level " + levelCount );
			yield return new WaitForSeconds( waitTime * 0.4f );

		

			yield return new WaitForSeconds( timeToMemorize ); // 2 seconds to memorize the shapes

			Messenger<float,float>.Broadcast( "RotateCard", 0.45f , 0 );

			yield return new WaitForSeconds( 0.55f );  //Flip the card in 0.9 seconds

			Debug.Log( "Entering Guess Phase" );
			Messenger<string>.Broadcast( "SetMessage" , "Guess Phase" ); //Test Messages
			Messenger<float,float>.Broadcast( "RotateCard", 0.35f , 0 );
			
			yield return new WaitForSeconds( 0.35f );

			Messenger.Broadcast( "StartTimer" ); //Start Count Down

			yield return new WaitForSeconds( guessTime );  //Guess time 5 seconds.
			
			Messenger<string>.Broadcast( "SetMessage" , "Times Up" ); //Test Messages

			Messenger.Broadcast( "StopTimer" );

			Messenger<float,float>.Broadcast( "RotateCard", 0.45f , 0 );

			yield return new WaitForSeconds( 3.0f );

			levelCount ++;

		}

		Messenger<string>.Broadcast( "SetMessage" , "Completed All Tasks" );


		//Messenger.Broadcast( "ShowPrompt" );

	}
	
}
