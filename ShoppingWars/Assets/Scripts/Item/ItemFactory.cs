using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemFactory : MonoBehaviour {
	
	public float respawnRate = 1f;
	public float itemMax = 8f;    

	public GameObject prefab1;
	public GameObject prefab2;
	public GameObject prefab3;
	public GameObject prefab4;
	public GameObject prefab5;
	public GameObject prefab6;
	public GameObject prefab7;

	public Transform spawn1;
	public Transform spawn2;
	public Transform spawn3;
	public Transform spawn4;
	public Transform spawn5;
	public Transform spawn6;
	public Transform spawn7;

	float timer; // A timer to determine when to fire.

	Transform location;
	GameObject item;

	// Use this for initialization
	void Start () {
	}

	void Update ()
    {
        timer += Time.deltaTime;

		GameObject[] itemsOnMap = GameObject.FindGameObjectsWithTag ("Item");

		//get the items with tag

		if(timer >= respawnRate && itemsOnMap.Length < itemMax)
        {
			spawn ();
        }
    }

	void spawn () 
	{
		timer = 0f;

		int randomPick = Mathf.Abs(Random.Range(1,7));

		if(randomPick == 1){
			location = spawn1;
			item = prefab1;
			Debug.Log("Chose pos 1");
		}
		else if(randomPick == 2){
			location = spawn2;
			item = prefab2;
			Debug.Log("Chose pos 2");
		}
		else if(randomPick == 3){
			location = spawn3;
			item = prefab3;
			Debug.Log("Chose pos 3");
		} 
		else if(randomPick == 4){
			location = spawn4;
			item = prefab4;
			Debug.Log("Chose pos 4");
		} 
		else if(randomPick == 5){
			location = spawn5;
			item = prefab5;
			Debug.Log("Chose pos 5");
		} 
		else if(randomPick == 6){
			location = spawn6;
			item = prefab6;
			Debug.Log("Chose pos 6");
		} 
		else if(randomPick == 7){
			location = spawn7;
			item = prefab7;
			Debug.Log("Chose pos 7");
		} 

		Instantiate(item, location.transform.position, Quaternion.identity);
	}
}