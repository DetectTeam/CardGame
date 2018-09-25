using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGameManager : BaseGameManager 
{

	private Rotate rotator;

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

		float waitTime = 0.70f;
		float counter = 0;

		yield return StartCoroutine( baseVal );

		rotator.StartRotation();
		//Messenger.Broadcast( "StartRotation" );

		 while( counter < waitTime )
		 {
	 	 	  counter += Time.deltaTime;
              yield return null; //Don't freeze Unity
		 }
		 
		counter = 0;

		rotator.StopRotation();
		//Messenger.Broadcast( "StopRotation" );

		//Messenger.Broadcast( "ShowPrompt" );

	}
	
}
