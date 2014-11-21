using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {
	public float seconds;

	// Use this for initialization
	void Start () {
	}

	void StartTimer () {
		StartCoroutine(Wait(seconds));
	}
	
	IEnumerator Wait(float seconds) {
		Debug.Log("Wait " + seconds + " seconds");
		yield return new WaitForSeconds(seconds);
		Debug.Log("Timer done");
	}
}
