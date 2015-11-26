using UnityEngine;
using System.Collections;

//note: embed a class with sub properties w/i the inspector (ie. create new properties w/i a class)
[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}

public class Player : MonoBehaviour
{
	//PUBLIC INSTANCE VARIABLES
	public float speed = 6f; //f means floating point
	public Boundary boundary;
	
	//PRIVATE INSTANCE VARIABLES
	private Vector3 _movement;
	private Animator _anim;
	private Rigidbody _playerRigidbody;
	private int _floorMask; //layer mask
	//	float camRayLength = 100f; //O_O? UNNECESSARY? JUST TURNING PLAYER
	
	//METHODS
	//UPDATES EVERY FRAME FOR PHYSICS
	void FixedUpdate()
	{
		//User's input
		//note: GetAxisRaw immediately snap to full speed
		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical"); 
		
		//calling the methods:
		Move (h, v);
		Animating (h, v);

		GetComponent<Rigidbody>().position = new Vector3
		(
			//note: local variable "boundary" in main function refers to Serializable's embeded class's 7
			//global properties (xMin, xMax...)
			Mathf.Clamp (GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax), 
			0.0f, 
			Mathf.Clamp (GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
		);
	}

	//method ueed for references
	void Awake() //similar to Update(), but gets pulled even if script isn't read
	{
		_floorMask = LayerMask.GetMask ("Floor"); //LayerMask's property refers to tag: "Floor"
		_anim = GetComponent<Animator> ();
		_playerRigidbody = GetComponent<Rigidbody> ();
	}
	
	//METHODS FOR MOVING!
	//
	void Move(float h, float v)
	{
		_movement.Set (h, 0f, v); //setting movement positions
		
		//note: nomalized means it keeps the same direction but at length of 1
		_movement = _movement.normalized * speed * Time.deltaTime; //
		
		//note: MovePosition moves the player to position of transform in the inspector 
		_playerRigidbody.MovePosition (transform.position + _movement); //adding the input
	}
	
	//	//O_O? DO I NEED THIS FAIM FOR THE ASSIGNMENT?
	//	void Turning()
	//	{
	//
	//	}
	
	//method for animation
	void Animating(float h, float v)
	{
		//determine if user is inputting to move
		bool walking = h != 0f || v != 0f; //note: if h or v not have value of 0, then bool is TRUE
		_anim.SetBool ("IsWalking", walking); //setting anim to refer to state: "IsWalking" and bool: walking
	}
	
}
