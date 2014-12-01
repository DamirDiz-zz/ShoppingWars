using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
	public Transform player1;            // The position that that camera will be following.
	public Transform player2;            // The position that that camera will be following.
	public Transform player3;            // The position that that camera will be following.
	public Transform player4;            // The position that that camera will be following.
	public float smoothing = 5f;        // The speed with which the camera will be following.
	
	Vector3 offset;                     // The initial offset from the target.
	Vector3 avgPosition;


	void Start ()
	{
		updateAvg ();

		// Calculate the initial offset.
		offset = transform.position - avgPosition;
	}
	
	void FixedUpdate ()
	{
		updateAvg ();
		// Create a postion the camera is aiming for based on the offset from the target.
		Vector3 targetCamPos = avgPosition + offset;
		
		// Smoothly interpolate between the camera's current position and it's target position.
		transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing * Time.deltaTime);
	}

	private void updateAvg()
	{
		avgPosition.x = (player1.position.x + player2.position.x + player3.position.x + player4.position.x) / 4;
		avgPosition.y = (player1.position.y + player2.position.y + player3.position.y + player4.position.y) / 4;
		avgPosition.z = (player1.position.z + player2.position.z + player3.position.z + player4.position.z) / 4;
	}
}

//
//using UnityEngine;
//using System.Collections;
//
//public class CameraFollow : MonoBehaviour
//{
//	public Transform player1;            // The position that that camera will be following.
//	public Transform player2;            // The position that that camera will be following.
//	public Transform player3;            // The position that that camera will be following.
//	public Transform player4;            // The position that that camera will be following.
//	public float smoothing = 5f;        // The speed with which the camera will be following.
//	
//	Vector3 offset;                     // The initial offset from the target.
//	Vector3 avgPosition;
//	
//	void Start ()
//	{
//		// Calculate the initial offset.
//		
//		avgPosition.x = (player1.position.x + player2.position.x + player3.position.x + player4.position.x) / 4;
//		avgPosition.y = (player1.position.y + player2.position.y + player3.position.y + player4.position.y) / 4;
//		avgPosition.z = (player1.position.z + player2.position.z + player3.position.z + player4.position.z) / 4;
//		
//		Debug.Log (avgPosition);
//		offset = transform.position - avgPosition;
//	}
//	
//	void FixedUpdate ()
//	{
//		// Create a postion the camera is aiming for based on the offset from the target.
//		Vector3 targetCamPos = avgPosition + offset;
//		
//		// Smoothly interpolate between the camera's current position and it's target position.
//		transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing * Time.deltaTime);
//	}
//}