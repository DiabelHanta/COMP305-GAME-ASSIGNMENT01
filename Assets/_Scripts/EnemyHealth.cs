/*
 * NAME:	Khandker Hussain
 * ID:		300773610
 * DATE:	11/26/2015
 * CODE:	"Survival Shooter Tutorial"
 */
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
	//PUBLIC INSTANCE VARIABLES
    public int startingHealth = 100;
    public int currentHealth;
    public float sinkSpeed = 2.5f; //sinks through the floor
    public int scoreValue = 10; //increases player's score
    public AudioClip deathClip;

	//PRIVATE INSTANCE VARIABLES (REFERENCES)
    private Animator _anim;
	private AudioSource _enemyAudio;
	private ParticleSystem _hitParticles;
	private CapsuleCollider _capsuleCollider;
	//bools
	private bool _isDead;
	private bool _isSinking;

	//Set up Method
    void Awake ()
    {
        _anim = GetComponent <Animator> ();
        _enemyAudio = GetComponent <AudioSource> ();
        _hitParticles = GetComponentInChildren <ParticleSystem> ();//find component in all child objects to find the component
        _capsuleCollider = GetComponent <CapsuleCollider> ();

        currentHealth = startingHealth; //will enemy sink or not.
    }

	//
    void Update ()
    {
		//moves persecond with Time.deltaTime rather than every frame
        if(_isSinking)
        {
            transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }

	//PUBLIC METHOD (CALLED FROM OTHER SCRIPTS
    public void TakeDamage (int amount, Vector3 hitPoint) //(how much damage, where you get hit)
    {
        if (_isDead) 
		{
			return;
		}

		//audio plays
        _enemyAudio.Play ();

        currentHealth -= amount;
            
		//show "fluff" come out
        _hitParticles.transform.position = hitPoint;
        _hitParticles.Play();

        if(currentHealth <= 0)
        {
            Death (); //calls this method
        }
    }


    void Death ()
    {
        _isDead = true;

        _capsuleCollider.isTrigger = true;

        _anim.SetTrigger ("Dead");

		//plays death sound
        _enemyAudio.clip = deathClip;
        _enemyAudio.Play ();
    }

	// NOTE: PUBLIC BECAUSE IT'S AN ANIMATION METHOD! (CALLS: StartSinking animation event)
    public void StartSinking ()
    {
        GetComponent <NavMeshAgent> ().enabled = false; //disables NavMeshAgent
        GetComponent <Rigidbody> ().isKinematic = true; //checks Kinimatic in Rigidbody component. note: using this, so unity ignores the objects when it's "dead"
        _isSinking = true;
		//incrementing the score from ScoreManger with the loval variable of scoreValue (ememy = 10 .'. += 10 points)
        ScoreManager.score += scoreValue; 
		Destroy (gameObject, 2f); //finally destroys the zombie object
    }
}
