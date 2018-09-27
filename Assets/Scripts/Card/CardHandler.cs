using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardHandler : MonoBehaviour 
{

	[SerializeField] private Image[] images; //Images on face side of card

	[SerializeField] private Card[] cards;

	[SerializeField] private int cardCount = 0;

	[SerializeField] private Text title;

	[SerializeField] private bool isMatch;

	[SerializeField] private TextMeshProUGUI userPrompt; //Display Memorize prompt to user.


	void OnEnable()
	{
		Debug.Log( "CardFace Enable Called" );

		//CardSetup();

		cardCount ++;
		
		Messenger<int>.AddListener( "LoadCard", LoadCard );
		Messenger<int>.AddListener( "LoadMatchCard", LoadMatchCard );
		Messenger.AddListener( "ShowPrompt" , ShowPrompt );
		Messenger<string>.AddListener( "SwipeDirection" , CheckSwipeDirection );

	}

	void OnDisable()
	{
		Messenger<int>.RemoveListener( "LoadCard", LoadCard );
		Messenger<int>.RemoveListener( "LoadMatchCard", LoadMatchCard );
		Messenger.RemoveListener( "ShowPrompt" , ShowPrompt );
		Messenger<string>.RemoveListener( "SwipeDirection" , CheckSwipeDirection );
	}

	private void CardSetup()
	{
		
		if( cardCount < cards.Length )
		{
		    Card card = cards[ cardCount ];
			
			//Debug.Log( card.name );
			title.text = card.name;
			isMatch = card.match;
			//Debug.Log( card.shapes.Length );


			for( int x = 0; x < card.shapes.Length; x++ )
			{
				//Debug.Log( "Shape Name: " + card.shapes[x].name );
				//Debug.Log( "Shape sprite: " + card.shapes[x].sprite );
				//Debug.Log( "Shape colour: " + card.shapes[x].color );
				images[ x ].sprite = card.shapes[x].sprite;
				images[ x ].color = card.shapes[x].color;
			}
		}
	}

	private void ShowPrompt()
	{
		Debug.Log( "Showing Prompt..." );
		userPrompt.gameObject.SetActive( true );
	}

	private void HidePrompt()
	{
		userPrompt.gameObject.SetActive( false );
	}

	private void CheckSwipeDirection( string swipeDirection )
	{
		int isUserRight = 0;
		
		Debug.Log( "Direction :: " + swipeDirection );

		if( swipeDirection.Equals( "Right" ) )
		{
			
			//Right = yes
			//Check if match is set to true
			//If it is then the user is correct
			//else user is wrong
			isUserRight = 2;
			Debug.Log( "MATCH:::: " + isMatch );
		}
		else if( swipeDirection.Equals( "Left" ) )
		{
			//Left = no
			//if match is set to false then user is correct
			//else user is wrong
			isUserRight = 1;
			Debug.Log( "MATCH:::: " + isMatch );
		}

		Messenger<int, bool>.Broadcast( "UserDecision" , isUserRight, isMatch );
	}

	private void LoadCard( int cardCount )
	{
		Debug.Log( "Loading Card" );

		if( cardCount < cards.Length )
		{
			Card card = cards[ cardCount ];
			
			title.text = card.name;
			isMatch = card.match;

			for( int x = 0; x < card.shapes.Length; x++ )
			{
				//Debug.Log( "Shape Name: " + card.shapes[x].name );
				//Debug.Log( "Shape sprite: " + card.shapes[x].sprite );
				//Debug.Log( "Shape colour: " + card.shapes[x].color );
				images[ x ].sprite = card.shapes[x].sprite;
				images[ x ].color = card.shapes[x].color;
			}
		}
	}

	private void LoadMatchCard( int cardCount )
	{
		
		if( cardCount < cards.Length )
		{
			Card card = cards[ cardCount ];

			Debug.Log( "Ok shapes match so lets randomize the positions of the existing shapes" );
			for( int x = 0; x < card.matchShapes.Length; x ++ )
			{
				images[ x ].sprite = card.matchShapes[ x ].sprite;
				images[ x ].color = card.matchShapes[ x ].color;
			}
			
		}

	}	
	
}
