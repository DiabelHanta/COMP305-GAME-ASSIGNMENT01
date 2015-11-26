using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour 
{
	//INSTANCE VARIABLES
	Transform player; // Reference to the player's position.
	PlayerHealth playerHealth; // Reference to the player's health.
	EnemyHealth enemyHealth; // Reference to this enemy's health.
	NavMeshAgent nav;// Reference to the nav mesh agent.
//	public float speed;
	
	void Awake ()
	{
		// Set up the references.
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		playerHealth = player.GetComponent <PlayerHealth> ();
		enemyHealth = GetComponent <EnemyHealth> ();
		nav = GetComponent <NavMeshAgent> (); //refers to nav mesh component
	}
	
	void Update ()
	{

		// If the enemy and the player have health left...
		//note: checking the scripts for both enmey and players' healths
		if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
		{
			// ... set the destination of the nav mesh agent to the player.
			nav.SetDestination (player.position); //moves toward the player
		}
		// Otherwise...
		else
		{
			// ... disable the nav mesh agent.
			nav.enabled = false; //disabling the component 
		}
	} 
}