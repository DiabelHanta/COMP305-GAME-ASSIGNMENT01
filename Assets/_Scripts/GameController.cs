using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{
	//PUBLIC INSTANCE VARIABLES
	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	//TEXT AND SCORE VARIABLES
	public GUIText scoreText;
	public GUIText restartText; 
	public GUIText gameOverText;

	//PRIVATE INSTANCE VARIABLES
	private bool _gameover;
	private bool _restart;
	private int _score; //score will always be a whole number

	//UPDATE FIRST FRAME
	void Start()
	{
		//booleans to ensure variables won't be called
		_gameover = false;
		_restart = false;
		
		//lavels are turned off
		restartText.text = "";
		gameOverText.text = "";
		
		_score = 0;
		UpdateScore (); //calling this method
		
//		//Calling out the method: SpawnWaves() using Coroutine
		StartCoroutine (SpawnWaves ());
	}

	//UPDATES EVERY FRAME
	void Update()
	{
		//conditional to restart
		if (_restart) 
		{
			//nested conditional to get user's input key to restart
			if(Input.GetKeyDown (KeyCode.R))
			{
				//Refers to the app's inner properties. 
				//note: w.i parameters performs the property (LoadLevel)'s function
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}
	//METHODS:
	//method to spawn waves of asteroids
	IEnumerator SpawnWaves() //note: IEnumerator is...
	{
		//once game starts there will be a short pause until the following function proceeds
		yield return new WaitForSeconds (startWait);
		
		while(true)
		{
			for(int count = 0; count < hazardCount; count++)
			{
				//spawnValues for y-axis and z-axis
				//note: Random.Range is used for min and max for spawnValues.x values
				Vector3 spawnPosition = new Vector3 (Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity; 
				
				//
				Instantiate(hazard, spawnPosition, spawnRotation);
				
				//time delay in spawning asteroids
				yield return new WaitForSeconds (spawnWait);
			}
			//time delay in spawning next wave of asteroids
			yield return new WaitForSeconds(waveWait);
			
			//
			if(_gameover)
			{
				//calling restart text and flag
				//note: '' sets the restart label
				restartText.text = "Press 'R' to restart!";
				_restart = true;
				break; //breaks the loop
			}
		}
	}
	//method to update player's score
	public void AddScore(int newScoreValue)
	{
		_score += newScoreValue; //score which is 0 will increment by newScoreValue
		UpdateScore (); //display the new score
	}
	
	//method to display the score
	void UpdateScore()
	{
		scoreText.text = "Score: " + _score; //set the score text property to the string
	}
	
	//method to call game over
	public void GameOver() // no parameters just call this function
	{
		//calling game over text and flag
		gameOverText.text = "Game Over!";
		_gameover = true;
	}
}
