using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemFactory : MonoBehaviour {
	
	public float respawnRate = 3f;        // The time between each shot.

	float timer; // A timer to determine when to fire.


	/*
	 * 1) get amount of items
	 * 2) counter
	 * 3) wenn anzahl der items unter 9 und timer abgelaufen erzeuge item
	 */

	// Use this for initialization
	void Start () {
		
	}

	void Update ()
    {
        timer += Time.deltaTime;

		GameObject[] itemsOnMap = GameObject.FindGameObjectsWithTag ("Item");

		//get the items with tag

		if(timer >= respawnRate)
        {
			timer = 0f;
			Debug.Log (itemsOnMap.Length);
        }
    }
}