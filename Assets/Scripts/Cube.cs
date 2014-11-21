using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour {

	public GameObject[] cubePrefabs;

	private Vector3 spawnPosition;
	private Quaternion spawnRotation;

	// Use this for initialization
	void Start () {
		spawnPosition = transform.position;
		transform.localScale = Vector3.zero;

		Spawn();
	}

	void Spawn () {
		transform.position = spawnPosition;
		animation.Play("ScaleUp");
	}

	void OnCollisionEnter (Collision collision) {
		if (collision.transform.tag == "Floor") {
			Spawn();
		}
	}
}
