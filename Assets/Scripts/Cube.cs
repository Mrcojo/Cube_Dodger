using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour {

	public GameObject[] cubePrefabs;

	private Vector3 spawnPosition;
	private int randomValue;

	// Use this for initialization
	void Start () {
		spawnPosition = transform.position;
		transform.localScale = Vector3.zero;

		animation.Play("ScaleUp");
	}

	IEnumerator Spawn () {
		yield return new WaitForSeconds(Random.Range(0, 2));

		collider.enabled = true;
		renderer.enabled = true;

		randomValue = Random.Range(0, 100);
		
		if (randomValue >= 0 && randomValue < 15) {
			Instantiate(cubePrefabs[2], spawnPosition, Random.rotation);
		} else if (randomValue >= 15 && randomValue < 30) {
			Instantiate(cubePrefabs[1], spawnPosition, Random.rotation);
		} else if (randomValue >= 30) {
			Instantiate(cubePrefabs[0], spawnPosition, Random.rotation);
		}
		GameObject.Destroy(gameObject);
	}

	void WaitAndSpawn () {
		StartCoroutine (Spawn());
	}

	void OnTriggerEnter (Collider otherCollider) {
		if (otherCollider.transform.tag == "Floor") {
			collider.enabled = false;
			renderer.enabled = false;
			WaitAndSpawn();
		}

		if (otherCollider.transform.tag == "Player") {
			Debug.Log ("Player hit");
		}
	}
}
