using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerItems : MonoBehaviour {

	List<GameObject> collectedItems;
	public string name = "";
	public Text text;
	int score = 0;

	// Use this for initialization
	void Start () {
		collectedItems = new List<GameObject>();
		text.text = name + "\nScore: 0";
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.tag == "Item")
		{
			collectedItems.Add(col.gameObject);
			score = score + 1;
			text.text =  name + "\nScore: " + collectedItems.Count;
			Destroy(col.gameObject);
			Debug.Log (collectedItems.Count);
		}
	}
}