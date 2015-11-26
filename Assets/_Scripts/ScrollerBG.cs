using UnityEngine;
using System.Collections;

public class ScrollerBG : MonoBehaviour 
{
	//PUBLIC INSTANCE VARIABLES
	public float scrollerSpeed;
	public float zTileSize; //note: 

	//PRIVATE INSTANCE VARIABLES
	private Vector3 _startPosition;

	//METHODS
	void Start ()
	{
		_startPosition = transform.position; //variable assigned to inspector's transform's position proeperty
	}
	
	void Update ()
	{
		Scrolling (); //calling Scrolling() method instead of putting code in here

//		//NOTE: Mathf.Repeat() loops time value so that it's never longer than 0 and the length (second parameter)
//		float newPosition = Mathf.Repeat(Time.time * scrollerSpeed, zTileSize);
//		//inspector's transform property assigned to first frame's position + vector3 (0,0,1) * the new position's loop
//		transform.position = startPosition + Vector3.right * newPosition;
	}

	//Scrolling method
	public void Scrolling()
	{
		//NOTE: Mathf.Repeat() loops time value so that it's never longer than 0 and the length (second parameter)
		float newPosition = Mathf.Repeat(Time.time * scrollerSpeed, zTileSize);
		//inspector's transform property assigned to first frame's position + vector3 (0,0,1) * the new position's loop
		transform.position = _startPosition + Vector3.right * newPosition;
	}

	//IMPLEMENT LATER?
//	//Disable Scrolling
//	public void DisableScroll()
//	{
//		Scrolling () = false;
//	}
}
