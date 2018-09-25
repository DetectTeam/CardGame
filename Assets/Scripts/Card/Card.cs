using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class Card 
{
	public string name;
	public bool match;
	public Shape[] shapes;

}


[System.Serializable]
public class Shape
{
	public string name;
	public Color color;

	public Sprite sprite;
}


