using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour {
	public AudioSource hitSound;
	public AudioSource freezeSound;
	public AudioSource pickupSound;

	public static SoundController instance;

	// Use this for initialization
	void Start () {
		instance = this;
	}
	
	public static void PlayHitSound() {
		instance.hitSound.Play ();
	}
	
	public static void PlayFreezeSound() {
		instance.freezeSound.Play ();
	}
	public static void PlayPickupSound() {
		instance.pickupSound.Play ();
	}
}
