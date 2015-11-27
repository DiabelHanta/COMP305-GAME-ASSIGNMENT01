/*
 * NAME:	Khandker Hussain
 * ID:		300773610
 * DATE:	11/26/2015
 * CODE:	"Survival Shooter Tutorial"
 */
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
	//PUBLIC INSTANCE VARIABLES
    public int damagePerShot = 20;
    public float timeBetweenBullets = 0.15f;
    public float range = 100f;

	//PRIVATE INSTANCE VARIABLES
	private float _timer;
	private Ray _shootRay; //here bullets hit
	private RaycastHit _shootHit; //
	private int _shootableMask; //restricting to ONLY shoot "Shootable" objects
	private ParticleSystem _gunParticles; 
	private LineRenderer _gunLine; 
	private AudioSource _gunAudio; 
	private Light _gunLight; 
	private float _effectsDisplayTime = 0.2f; //length of effects duration

	//
    void Awake ()
    {
        _shootableMask = LayerMask.GetMask ("Shootable"); //number of shootable layer
		//REFERENCES
        _gunParticles = GetComponent<ParticleSystem> ();
        _gunLine = GetComponent <LineRenderer> ();
        _gunAudio = GetComponent<AudioSource> ();
        _gunLight = GetComponent<Light> ();
    }

	//
    void Update ()
    {
        _timer += Time.deltaTime; //refers to the time to shoot. (rate of fire)

		//conditional: ("Fire1") refers to left click of mouse
		if(Input.GetButton ("Fire1") && _timer >= timeBetweenBullets && Time.timeScale != 0)
        {
            Shoot ();
        }

        if(_timer >= timeBetweenBullets * _effectsDisplayTime)
        {
            DisableEffects (); //method call
        }
    }

	//METHOD: turn light and line rendering off after being shot
    public void DisableEffects ()
    {
        _gunLine.enabled = false;
        _gunLight.enabled = false;
    }

	//METHOD: Shoot...
    void Shoot ()
    {
        _timer = 0f; //resets timer to 0
        _gunAudio.Play (); 
        _gunLight.enabled = true; //turning light on

        _gunParticles.Stop (); //if particles are playing then stop
        _gunParticles.Play (); //if not playing then play once fired again

		//note: a line has two points SetPosition(FIRST POINT (start), SECOND POINT(end))
        _gunLine.enabled = true; //turn on line render
        _gunLine.SetPosition (0, transform.position); //

        _shootRay.origin = transform.position; //starts at tip of the gun
        _shootRay.direction = transform.forward; //shoots in front of the player's gun (forward)

		//note: Physics.Raycast() creates a ray against all coliders. Parameters(origin, direction, range, layermask)
        if(Physics.Raycast (_shootRay, out _shootHit, range, _shootableMask))
        {
			//Receive enemy health in the script and stores it
            EnemyHealth enemyHealth = _shootHit.collider.GetComponent <EnemyHealth> ();

			//note: If hits something that doesn't have an enemyHealth, then receives value of null (ie. hit legos or wall)

			//conditional: whatever player hits and has a reference to enemyHealth that doesn't equal to null, then follow this "if statement"
            if(enemyHealth != null)
            {
				//Calling method: TakeDamage from enemyHealth script. 
					//ie. TakeDamage (int amount, Vector3 hitPoint)
                enemyHealth.TakeDamage (damagePerShot, _shootHit.point);
            }
			//following the line SetPosition(start, end)
            _gunLine.SetPosition (1, _shootHit.point); //if hits something then end at the point at which where the ray hits
        }

		//don't hit anything then do this
        else
        {
			//the line will stop at the end of this calculation. Refer to variable "range" (100f)
            _gunLine.SetPosition (1, _shootRay.origin + _shootRay.direction * range); //used to still show the bullets even if you don't hit anything
        }
    }
}
