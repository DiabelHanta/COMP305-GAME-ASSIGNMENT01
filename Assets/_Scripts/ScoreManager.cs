/*
 * NAME:	Khandker Hussain
 * ID:		300773610
 * DATE:	11/26/2015
 * CODE:	"Survival Shooter Tutorial" & Demonstrations from class
 */
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
	//PUBLIC INSTANCE VARIABLE
	public static int score; //NOTE: static = belongs to the class and not an instance of the class

	//Text type to creat text object
	private Text _scoreText;
//	private Text _restart;
//	private Text _gameOver;

//	//Private Bools
//	private 

	//On set up
    void Awake ()
    {
		//
        _scoreText = GetComponent <Text> (); //local variable refers to Text component in our inspector for "ScoreText"
        score = 0; //resets score to 0
    }

	//
    void Update ()
    {
        _scoreText.text = "Score: " + score; //concatenating the text variable to set the string
    }
}
