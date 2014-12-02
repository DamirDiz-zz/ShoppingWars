using UnityEngine;
using System.Collections;

public class ItemFactory : MonoBehaviour {
	
	public float respawnRate = 2f;        // The time between each shot.

	float timer; // A timer to determine when to fire.


	/*
	 * 1) get amount of items
	 * 2) counter
	 * 3) wenn anzahl der items unter 9 und timer abgelaufen erzeuge item
	 */

//	// Use this for initialization
//	void Start () {
//		
//	}
//	
//	// Update is called once per frame
//	void Update () {
//
//	}
//
//
//	void Update ()
//    {
//        timer += Time.deltaTime;
//
//
//
//		if(timer >= respawnRate)
//        {
//            // ... disable the effects.
//            DisableEffects ();
//        }
//    }
}