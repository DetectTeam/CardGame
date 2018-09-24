using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGameManager : BaseGameManager {

	

    public override void Start()
    {
        base.Start();
       
    }

    public override IEnumerator StartLevelRoutine()
	{
		var baseVal = base.StartLevelRoutine();
    
		yield return StartCoroutine( baseVal );

	}

	public override IEnumerator PlayLevelRoutine()
	{
		var baseVal = base.PlayLevelRoutine();

		yield return StartCoroutine( baseVal );
	}


	
}
