/*
 * NAME:	Khandker Hussain
 * ID:		300773610
 * DATE:	11/26/2015
 * CODE:	Demonstration from class
 */
using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour 
{
	//time line for object's life
	public float lifeTime;
	
	void Start()
	{
		//note saves processing usage by destroying objects that explode and are off screen
		Destroy (gameObject, lifeTime); //the object will destroy tiself when the time is up
	}
}
