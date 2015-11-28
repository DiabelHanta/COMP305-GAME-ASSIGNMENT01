/*
 * NAME:	Khandker Hussain
 * ID:		300773610
 * DATE:	11/26/2015
 * CODE:	Demonstrated in class
 */
using UnityEngine;
using System.Collections;

public class PlayerCollider : MonoBehaviour 
{
	//PRIVATE INSTANCE VARIABLES
	private AudioSource[] _audioSources; //array of audio sources
	private AudioSource _pickupSound;


	// Use this for initialization
	void Start () 
	{
		this._audioSources = this.GetComponents<AudioSource> ();
		this._pickupSound = this._audioSources[1];
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	//Collision Trigger Method
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Pickup")
		{
			this._pickupSound.Play ();
			Destroy (other.gameObject);
		}

		if(other.tag == "Enemy")
		{
			Debug.Log("Enemy Attacked!");
		}
	}
}
