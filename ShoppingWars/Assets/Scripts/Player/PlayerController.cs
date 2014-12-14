using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {
	
	public string name = "";
	public Text text;
	public float speed;
	public string controlsHorizontal;
	public string controlsVertical;

	List<GameObject> collectedItems;
	Animator anim;
	int health = 100;
	Vector3 movement;
	Rigidbody playerRigidbody;
	int floorMask;


	void Awake ()
	{
		floorMask = LayerMask.GetMask ("Floor");
		anim = GetComponent <Animator> ();
		playerRigidbody = GetComponent <Rigidbody> ();
		
	}

	void FixedUpdate ()
	{
		if (GameController.isRunning) {
			// Store the input axes.
			float h = Input.GetAxisRaw (controlsHorizontal);
			float v = Input.GetAxisRaw (controlsVertical);
			
			Vector3 movement = new Vector3 (h, 0.0f, v) * speed;
			
			if (h != 0 || v != 0) {
				transform.rotation = Quaternion.LookRotation (movement);
			}
			
			anim.SetBool ("IsWalking", (h != 0 || v != 0));
			playerRigidbody.AddForce (movement * Time.deltaTime * 200, ForceMode.Acceleration);
		}
	}

	void Start () {
		collectedItems = new List<GameObject>();
		text.text = getText();
		anim = GetComponent <Animator> ();
	}

	void Update () {
	
		if (health <= 0) {

		}
	
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
			health = Mathf.Max(health - 10, 0);
		}
		text.text = getText();
	}
	
	string getText() {
		return name + "\nScore: " + collectedItems.Count + "\nHealth: " + health + "%";
	}

}