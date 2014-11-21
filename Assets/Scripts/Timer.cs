using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {
	public float seconds;
	public bool isRunning;
	public bool timerEnded;

	public float time;

	// Use this for initialization
	void Start () {
		timerEnded = false;
		isRunning = false;
	}

	public void StartTimer () {
		time = seconds;
		timerEnded = false;
		isRunning = true;
	}

	public void StopTimer () {
		isRunning = false;
	}

	public void AddSeconds (float secondsToAdd) {
		time += secondsToAdd;
	}

	/*
	IEnumerator Wait(float seconds) {
		Debug.Log("Wait " + seconds + " seconds");
	
		yield return new WaitForSeconds(seconds);
		isRunning = false;

		Debug.Log("Timer done");
	}*/
	
	void Update() {

		if (isRunning) {
			time -= Time.deltaTime;

			if(time < 0)
			{
				isRunning = false;
				timerEnded = true;
			}
		}
	}
}
