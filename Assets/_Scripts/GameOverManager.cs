/*
 * NAME:	Khandker Hussain
 * ID:		300773610
 * DATE:	11/26/2015
 * CODE:	"Survival Shooter Tutorial"
 */
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
	//PUBLIC INSTANCE VARIABLES
    public PlayerHealth playerHealth; //
	public float restartDelay = 5f; //wait time before player's able to click restart

	//PRIVATE
	private Animator _anim; //animator's component reference
	private float _restartTimer; // timer counts up to restarting the level

	//On set up
    void Awake()
    {
        _anim = GetComponent<Animator>(); //component reference to animator....
    }

	//
    void Update()
    {
		//conditional if player loses all of their health
        if (playerHealth.currentHealth <= 0)
        {
			_anim.SetTrigger("GameOver"); //calls the animator for "game over"
			_restartTimer += Time.deltaTime; //timer counts to restart

			//nested if: to reload the game level
			if(_restartTimer >= restartDelay)
			{
				Application.LoadLevel (Application.loadedLevel); //reloads the level
			}
        }
    }
}
