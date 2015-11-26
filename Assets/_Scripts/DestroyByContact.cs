using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour 
{
	//INSTANCE VARIABLES
	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;

	private GameController _gameController; //object of type: "GameController"

	void Start()
	{
		//Referencing to object with tag: "GameController"
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController"); 
		
		//conditional used to ensure gameController is called
		if (gameControllerObject != null) 
		{
			_gameController = gameControllerObject.GetComponent<GameController>(); 
		}
		
		if (_gameController == null) 
		{
			Debug.Log("Cannot find 'GameController' script"); //insurance policy. hope this never gets called
		}
	}

	void OnTriggerEnter(Collider other) //other is an instance of Collider
	{
		//conditional used to ensure if other gameObject's tag is equal to Boundary tag, then return and explode the car
		if (other.tag == "Boundary") //note: use "" to refer to an object's tag
		{
			return; //note: return ends the execution of a function
		}
		
		Instantiate (explosion, other.transform.position, other.transform.rotation);
		Destroy (gameObject); //Destroys all of the child objects (car prefab) w/i the parent (car)

		//SEARCH ON ANIMATION DEATH F
		if (other.tag == "Player") 
		{
			//when collided then create the explosion material
			Instantiate (playerExplosion, transform.position, transform.rotation);
			_gameController.GameOver(); // gameController[s GameOver function calls and ends the game
			
			Destroy (other.gameObject); //DESTROYS PLAYER
		}
		//
		_gameController.AddScore (scoreValue); //calling AddScore method from GameController script using reference gameController
		
		//note: doesn't matter what the order is b/w these two.
		//			Destroy (other.gameObject);  //Moved from bottom to (if statement: other.tag)
		//			Destroy (gameObject); //Destroys all of the child objects w/i the parent
	}

}
