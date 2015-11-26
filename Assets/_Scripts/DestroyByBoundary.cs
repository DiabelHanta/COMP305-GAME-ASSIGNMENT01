using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour 
{
	//as the objects (shots) collide on "other" then those objects are destryoed. 
	//note: destroying objects saves memory
	void OnTriggerExit(Collider other)
	{
		Destroy (other.gameObject);
	}
}