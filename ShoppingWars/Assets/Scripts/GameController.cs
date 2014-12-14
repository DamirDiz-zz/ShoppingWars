using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
	public float timeLeft = 120.0f;
	public Text timerText;
	public Text startText;
	public Text gameOverText;
	public static bool isRunning;
	public static Dictionary<string, int> scores;
	bool gameOver = false;
	string minutes;
	string seconds;

	void Start () {
		scores = new Dictionary<string, int> ();
	}

	void Awake ()
	{
		gameOverText.enabled = false;
		isRunning = false;
		UpdateTimerText ();
	}
	
	
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.R)) {  
			Application.LoadLevel (0);  
		} 

		if (!isRunning && Input.GetKeyDown(KeyCode.Space) && timeLeft > 0) {
			isRunning = true;
			startText.enabled = false;
		}

		if (timeLeft <= 0 && !gameOver) {
			isRunning = false;
			gameOver = true;
			int maxScore = 0;
			int noMaxScore = 0;
			string maxPlayer = "No player!";

			foreach (string player in scores.Keys) {
				if (scores[player] >= maxScore) {
					if (scores[player] == maxScore) {
						noMaxScore += 1;
					}
					else {
						noMaxScore = 1;
					}
					maxPlayer = player;
					maxScore = scores[player];
				}
			}
		
			if (noMaxScore == 0) {
				gameOverText.text = "Game over!\n But how did you not manage get any single product?";
			}
			else if (noMaxScore == 1) {
				gameOverText.text = "Game over!\nThe winner is " + maxPlayer + " with a score of " + maxScore + ".";
			}
			else {
				gameOverText.text = "Game over!\n It's a draw!";
			}

			gameOverText.enabled = true;
		}

		if (isRunning) {
			DoCountdown ();
			UpdateTimerText ();
		}
	
	}

	void DoCountdown() {
		timeLeft -= Time.deltaTime;
	}

	void UpdateTimerText() {
		minutes = Mathf.Max (Mathf.Floor (timeLeft / 60), 0).ToString ("00");
		seconds = Mathf.Max (Mathf.Floor(timeLeft % 60), 0).ToString("00");
		timerText.text = minutes + ":" + seconds;
	}
}