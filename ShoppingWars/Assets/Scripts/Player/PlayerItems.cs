using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerItems : MonoBehaviour {

	List<GameObject> collectedItems;

	// Use this for initialization
	void Start () {
		collectedItems = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.tag == "Item")
		{
			collectedItems.Add(col.gameObject);
			Destroy(col.gameObject);
			Debug.Log (collectedItems.Count);
		}
	}
}