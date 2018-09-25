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

		float waitTime = 1.0f;
		float degrees  =  180.0f;
		

		yield return StartCoroutine( baseVal );

		yield return new WaitForSeconds( waitTime );

		Messenger<float,float>.Broadcast( "RotateCard", waitTime , 0 );

		yield return new WaitForSeconds( waitTime * 3 );

		Messenger<float,float>.Broadcast( "RotateCard", waitTime , 0 );
		
	
	
	
		
	

	

		//Messenger.Broadcast( "ShowPrompt" );

	}
	
}
