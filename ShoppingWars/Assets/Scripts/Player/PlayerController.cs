using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerItems : MonoBehaviour {

	List<GameObject> collectedItems;
	public string name = "";
	public Text text;
	Animator anim;
	int health = 100;

	// Use this for initialization
	void Start () {
		collectedItems = new List<GameObject>();
		text.text = getText();
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
			GameController.scores[name] = collectedItems.Count;
			anim.SetTrigger("Punch");
			Destroy(col.gameObject);
			Debug.Log (collectedItems.Count);
		}
		else if (col.gameObject.tag == "Cart")
		{
			health -= 10;
		}
		text.text = getText();
	}
	
	string getText() {
		return name + "\nScore: " + collectedItems.Count + "\nHealth: " + health + "%";
	}

}