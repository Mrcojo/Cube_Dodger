using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour {

	public GameObject[] cubePrefabs;

	private Vector3 spawnPosition;
	private int randomValue;

	private GameManager gameManager;

	// Use this for initialization
	void Start () {
		gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

		spawnPosition = transform.position;
		transform.localScale = Vector3.zero;

		animation.Play("ScaleUp");
	}

	void OnTriggerEnter (Collider otherCollider) {
		if (otherCollider.transform.tag == "Environment") {
			collider.enabled = false;
			renderer.enabled = false;
			WaitAndSpawn();
		}
		
		if (otherCollider.transform.tag == "Player") {
			switch (transform.tag) {
				case "DamageCube":
					break;
				case "TimerCube":
					gameManager.ExtendGameTime();
					break;
				case "GravityCube":
					gameManager.ReduceGravity();
					break;
			}
		}
	}

	void WaitAndSpawn () {
		StartCoroutine (Spawn());
	}

	IEnumerator Spawn () {
		yield return new WaitForSeconds(Random.Range(0, 2));
		
		collider.enabled = true;
		renderer.enabled = true;
		
		randomValue = Random.Range(0, 100);
		
		if (randomValue >= 0 && randomValue < 70) {
			Instantiate(cubePrefabs[0], spawnPosition, Random.rotation);
		} else if (randomValue >= 70 && randomValue < 90) {
			Instantiate(cubePrefabs[1], spawnPosition, Random.rotation);
		} else if (randomValue >= 90) {
			Instantiate(cubePrefabs[2], spawnPosition, Random.rotation);
		}
		GameObject.Destroy(gameObject);
	}
}
