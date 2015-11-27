/*
 * NAME:	Khandker Hussain
 * ID:		300773610
 * DATE:	11/26/2015
 * CODE:	Demonstration from class
 */
using UnityEngine;
using System.Collections;

[System.Serializable]
public class Speed
{
	public float minSpeed, maxSpeed;
}

[System.Serializable]
public class Drift
{
	public float minDrift, maxDrift;
}

//note: embed a class with sub properties w/i the inspector (ie. create new properties w/i a class)
[System.Serializable]
public class EnemyBoundary
{
	public float xMin, xMax, zMin, zMax;
}

public class EnemyBunnyController : MonoBehaviour 
{
	//PUBLIC INSTANCE VARIABLES
	public Speed speed;
	public Drift drift;
	public EnemyBoundary boundary;

	//PRIVATE INSTANCE VARIABLES
	private float _CurrentSpeed;
	private float _CurrentDrift;
	
	//METHODS
	void Start ()
	{
		this._Reset ();
	}
	
	void Update ()
	{
		Vector3 currentPosition = new Vector3 (0.0f, 0.0f, 0.0f);
		currentPosition = gameObject.GetComponent<Transform> ().position;
		currentPosition.x -= this._CurrentSpeed;
		currentPosition.z += this._CurrentDrift;
		
		//moves the game object to current position
		gameObject.GetComponent<Transform> ().position = currentPosition;
		
		//boundary check to call reset method
		if(currentPosition.x <= boundary.xMin)//-15
		{
			this._Reset();
		}
	}

//	void FixedUpdate()
//	{
//		GetComponent<Rigidbody>().position = new Vector3
//		(
//			//note: local variable "boundary" in main function refers to Serializable's embeded class's 7
//			//global properties (xMin, xMax...)
//			Mathf.Clamp (GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax), 
//			0.0f, 
//			Mathf.Clamp (GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
//		);
//	}
	
	//PRIVATE METHDOS
	private void _Reset()
	{
		this._CurrentSpeed = Random.Range (speed.minSpeed, speed.maxSpeed);
		this._CurrentDrift = Random.Range (drift.minDrift, drift.maxDrift); 
		//REFERENCE: (24f, 0.0f, Random.Range(-11, 11f)) 
		Vector3 resetPostion = new Vector3 (boundary.xMax, 0.0f, Random.Range(boundary.zMin, boundary.zMax));
		gameObject.GetComponent<Transform> ().position = resetPostion;
	}
}