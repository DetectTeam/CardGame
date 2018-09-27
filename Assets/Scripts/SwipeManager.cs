using UnityEngine;
using System.Collections;

public enum SwipeDirection
{
	None = 0,
	Left = 1,
	Right = 2,
	Up = 4,
	Down = 8,
}

public class SwipeManager : MonoBehaviour 
{

	[SerializeField] private Vector3 touchPosition;
	[SerializeField] private float swipeResistanceX = 50.0f;
	[SerializeField] private float swipeResistanceY = 100.0f;

	public SwipeDirection Direction { get; set; }
	
	
	// Update is called once per frame
	void Update () 
	{
		Direction = SwipeDirection.None;

		if( Input.GetMouseButtonDown (0) )
		{
			touchPosition = Input.mousePosition;
		}

		if( Input.GetMouseButtonUp (0) )
		{
			Vector2 deltaSwipe = touchPosition - Input.mousePosition;

			if( Mathf.Abs( deltaSwipe.x ) > swipeResistanceX )
			{
				Debug.Log( "SWIIIIIIPPPPEEEEEE" );

				//Swipe on the x axis
				Direction |= (deltaSwipe.x < 0) ? SwipeDirection.Right : SwipeDirection.Left;

				Debug.Log( "Swipe Direction : " + Direction );

				Messenger<string>.Broadcast( "SwipeDirection" , Direction.ToString() );
				//Dont forget to check the direction of the swipe
			}
		}
	}
}
