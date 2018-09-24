using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardFace : MonoBehaviour 
{

	[SerializeField] private Image shapeOne; 
	[SerializeField] private Image shapeTwo; 
	[SerializeField] private Color shapeOneColour;
	[SerializeField] private Color shapeTwoColour;

	[SerializeField] private int randomNum;

	[SerializeField] private Sprite[] shapes;

	// Use this for initialization
	void Start()
	{
		randomNum = Random.Range( 0, shapes.Length );
		shapeOne.sprite = shapes[ randomNum ];

		randomNum = Random.Range( 0, shapes.Length );
		shapeTwo.sprite = shapes[ randomNum ];
	}

	void OnEnable()
	{
		Debug.Log( "CardFace Enable Called" );

		RandomShapes();

		shapeOne.color = Random.ColorHSV( 0f, 1f, 0f,1f ,0f ,1f );
		shapeTwo.color = Random.ColorHSV( 0f, 1f, 0f,1f ,0f ,1f );
	}

	void RandomShapes()
	{
		Debug.Log( "Random Shapes...Called" );
		randomNum = Random.Range( 0, shapes.Length );
		shapeOne.sprite = shapes[ randomNum ];

		randomNum = Random.Range( 0, shapes.Length );
		shapeTwo.sprite = shapes[ randomNum ];
	}
	
	
	
}
