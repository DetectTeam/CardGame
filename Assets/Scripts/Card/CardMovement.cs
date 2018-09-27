using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class CardMovement : MonoBehaviour 
{

	[SerializeField] private string movementDirection;

	private void OnEnable()
	{
		Messenger<string>.AddListener( "SwipeDirection" , Move );
	}

	private void OnDisable()
	{
		Messenger<string>.RemoveListener( "SwipeDirection" , Move );
	}

	private void Move( string direction )
	{

	    float moveDistance = 5.0f;
		movementDirection = direction;
		

		if( direction.Equals( "Left" ) )
		{
			Debug.Log( "Moving Left" );
			TweenMove( -moveDistance );
		}
		else if( direction.Equals( "Right" ) )
		{
			Debug.Log( "Moving Right" );
			TweenMove( moveDistance );
			
			
		}
	}

	private void TweenMove( float xDirection )
	{
		iTween.MoveTo( gameObject, new Vector3( xDirection, gameObject.transform.position.y, gameObject.transform.position.z  ), 2.0f );
	
	}
	
	
}
