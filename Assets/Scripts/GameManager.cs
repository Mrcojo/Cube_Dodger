using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public int playerLives;

	public Timer gameTimer;
	public Timer gravityTimer;

	public Vector3 gravityValue;

	public TextMesh timerText;
	public TextMesh livesText;
	
	// Use this for initialization
	void Start () {
		gravityValue = new Vector3(0, -9.81f, 0);
		gameTimer.StartTimer();

		livesText.text = "Lives: " + playerLives;
	}

	void Update () {
		int minutes = Mathf.FloorToInt(gameTimer.time / 60);
		int seconds = Mathf.FloorToInt(gameTimer.time - minutes * 60);

		if (seconds < 10 ) {
			timerText.text = 0 + "" + minutes + ".0" + seconds;
		} else {
			timerText.text = 0 + "" + minutes + "." + seconds;
		}
		if(gravityTimer.timerEnded) {
			Physics.gravity = gravityValue;
			gravityTimer.timerEnded = false;
		}
	}

	public void RemoveLife () {
		if (playerLives <= 0) {
			Application.Quit();
		}
		else {
			playerLives--;
		}

		livesText.text = "Lives: " + playerLives;
	}

	public void AddLife () {
		playerLives++;
		
		livesText.text = "Lives: " + playerLives;
	}

	public void ExtendGameTime () {
		gameTimer.AddSeconds(5);
	}

	public void ReduceGravity () {
		Physics.gravity = (gravityValue / 4);
		gravityTimer.StopTimer();
		gravityTimer.StartTimer();
	}
}
