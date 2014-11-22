using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public int playerLives;

	public Timer gameTimer;
	public Timer gravityTimer;

	public Vector3 gravityValue;

	public TextMesh timerText;
	public TextMesh keysText;
	public TextMesh livesText;
	public TextMesh messageText;

	public AudioClip damageSound;
	public AudioClip gameOverSound;
	public AudioClip winSound;

	private CharacterController controller;
	private bool gameOver;

	// Use this for initialization
	void Start () {
		gameOver = false;
		controller = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();

		gravityValue = new Vector3(0, -9.81f, 0);
		gameTimer.StartTimer();

		livesText.text = "Lives: " + playerLives;
	}

	void Update () {
		if (gameTimer.time > 0 && playerLives > 0) {
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
		else {
			if (!gameOver) {
				GameOver();
			}	
		}	
	}

	public void UpdateKeysNumber (int keys) {
		keysText.text = "Keys: " + keys + " / 3";
	}

	public void UpdateMessageText (string message) {
		messageText.text = message;
	}

	public void GameOver () {
		gameOver = true;
		messageText.text = "GAME OVER";
		AudioSource.PlayClipAtPoint(gameOverSound, transform.position);
		controller.enabled = false;
	}

	public void GameSuccess () {
		messageText.text = "WELL DONE!";
		AudioSource.PlayClipAtPoint(winSound, transform.position);
		controller.enabled = false;
	}

	public void RemoveLife () {
		if (playerLives <= 0) {
			GameOver();
		}
		else {
			AudioSource.PlayClipAtPoint(damageSound, transform.position);
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
		Physics.gravity = (gravityValue / 7);
		gravityTimer.StopTimer();
		gravityTimer.StartTimer();
	}
}
