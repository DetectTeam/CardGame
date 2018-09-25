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

	[SerializeField] private TextMeshProUGUI userPrompt; //Display Memorize prompt to user.


	void OnEnable()
	{
		Debug.Log( "CardFace Enable Called" );

		CardSetup();

		cardCount ++;

		Messenger.AddListener( "ShowPrompt" , ShowPrompt );

	}

	void OnDisable()
	{
		Messenger.RemoveListener( "ShowPrompt" , ShowPrompt );
	}

	private void CardSetup()
	{
		
		if( cardCount < cards.Length )
		{
		    Card card = cards[ cardCount ];

			Debug.Log( card.name );
			title.text = card.name;
			Debug.Log( card.match );
			Debug.Log( card.shapes.Length );


			for( int x = 0; x < card.shapes.Length; x++ )
			{
				Debug.Log( "Shape Name: " + card.shapes[x].name );
				Debug.Log( "Shape sprite: " + card.shapes[x].sprite );
				Debug.Log( "Shape colour: " + card.shapes[x].color );
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
	
	
	
}
