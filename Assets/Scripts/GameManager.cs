using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public Timer gameTimer;
	public Timer gravityTimer;
	public Vector3 gravityValue;

	// Use this for initialization
	void Start () {
		gravityValue = new Vector3(0, -9.81f, 0);
		gameTimer.StartTimer();
	}

	void Update () {
		if(gravityTimer.timerEnded) {
			Physics.gravity = gravityValue;
			gravityTimer.timerEnded = false;
		}
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
