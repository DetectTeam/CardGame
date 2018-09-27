using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// This script should be attached to the card game object to display card`s rotation correctly.
/// </summary>

[ExecuteInEditMode]
public class CardRotation : MonoBehaviour 
{

	 // parent game object for all the card face graphics
    [SerializeField] private RectTransform cardFront;

    // parent game object for all the card back graphics
    [SerializeField] private RectTransform cardBack;

    // an empty game object that is placed a bit above the face of the card, in the center of the card
    [SerializeField] private Transform targetFacePoint;

    // 3d collider attached to the card (2d colliders like BoxCollider2D won`t work in this case)
    [SerializeField] private Collider col;

    // if this is true, our players currently see the card Back
    private bool showingFront = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		bool passedThroughColliderOnCard = false;
		
		// Raycast from Camera to a target point on the face of the card
        // If it passes through the card`s collider, we should show the back of the card
	
		RaycastHit[] hits;

		hits = Physics.RaycastAll( origin: Camera.main.transform.position, 
                                   direction: ( -Camera.main.transform.position + targetFacePoint.position ).normalized, 
            					   maxDistance: ( -Camera.main.transform.position + targetFacePoint.position ).magnitude );
		

		foreach ( RaycastHit h in hits )
        {
            if ( h.collider == col )
                passedThroughColliderOnCard = true;
        }

	
        if (passedThroughColliderOnCard!= showingFront)
        {
			
            // something changed
            showingFront = passedThroughColliderOnCard;
			Debug.Log( "Showing Front " + showingFront );
            if (showingFront)
            {
                // show the front side
				cardBack.gameObject.SetActive(false);
				cardFront.transform.localRotation = Quaternion.Euler(0, 180.0f, 0);
                cardFront.gameObject.SetActive(true);
              
            }
            else
            {
                // show the back side
			
                cardBack.gameObject.SetActive(true);
                cardFront.gameObject.SetActive(false);
            }

        }
	}
}
