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
	public GameObject particles;

	List<GameObject> collectedItems;
	Animator anim;
	int health = 100;
	Vector3 movement;
	Rigidbody playerRigidbody;
	int floorMask;
	float timeFreeze;
	bool isFreezed = false;


	void Awake ()
	{
		floorMask = LayerMask.GetMask ("Floor");
		anim = GetComponent <Animator> ();
		playerRigidbody = GetComponent <Rigidbody> ();
		particles.SetActive (false);
		
	}

	void FixedUpdate ()
	{
		if (GameController.isRunning) {
			if (!isFreezed) {
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
	}

	void Start () {
		collectedItems = new List<GameObject>();
		text.text = getText();
		anim = GetComponent <Animator> ();
	}

	void Update () {
		if (GameController.isRunning) {
			if (health <= 0 && !isFreezed) {
				isFreezed = true;
				timeFreeze = 5.0f;
				particles.SetActive (true);
			}

			if (isFreezed) {
				timeFreeze -= Mathf.Max(Time.deltaTime, 0f);
			}

			if (isFreezed && timeFreeze <= 0) {
				isFreezed = false;
				health = 100;
				particles.SetActive (false);
			}
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
			health = Mathf.Max(health - Random.Range(30, 60), 0);
		}
		text.text = getText();
	}
	
	string getText() {
		return name + "\nScore: " + collectedItems.Count + "\nHealth: " + health + "%";
	}

}