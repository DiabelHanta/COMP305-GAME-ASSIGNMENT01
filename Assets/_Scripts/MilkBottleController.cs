/*
 * NAME:	Khandker Hussain
 * ID:		300773610
 * DATE:	11/26/2015
 * CODE:	Demonstration from class
 */
using UnityEngine;
using System.Collections;

public class MilkBottleController : MonoBehaviour 
{
	//PUBLIC INSTANCE VARIABLES
	public float speed;
	
	//METHODS
	void Start ()
	{
		this._Reset ();
	}
	
	void Update ()
	{
		Vector3 currentPosition = new Vector3 (0.0f, 0.0f, 0.0f);
		currentPosition = gameObject.GetComponent<Transform> ().position;
		currentPosition.x -= speed;

		//moves the game object to current position
		gameObject.GetComponent<Transform> ().position = currentPosition;

		//boundary check to call reset method
		if(currentPosition.x <= -14)
		{
			this._Reset();
		}
	}

	//PRIVATE METHDOS
	private void _Reset()
	{
		Vector3 resetPostion = new Vector3 (24f, 0.5f, Random.Range(-11, 11f));
		gameObject.GetComponent<Transform> ().position = resetPostion;
	}
}