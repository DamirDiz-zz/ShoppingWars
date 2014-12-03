using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerItems : MonoBehaviour {

	List<GameObject> collectedItems;
	public string name = "";
	public Text text;
	Animator anim;

	// Use this for initialization
	void Start () {
		collectedItems = new List<GameObject>();
		text.text = name + "\nScore: 0";
		anim = GetComponent <Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.tag == "Item")
		{
			collectedItems.Add(col.gameObject);
			text.text =  name + "\nScore: " + collectedItems.Count;
			anim.SetTrigger("Punch");
			Destroy(col.gameObject);
			Debug.Log (collectedItems.Count);
		}
	}
}