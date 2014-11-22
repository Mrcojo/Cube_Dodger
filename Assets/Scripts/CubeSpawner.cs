using UnityEngine;
using System.Collections;

public class CubeSpawner : MonoBehaviour {

	public GameObject[] cubePrefabs;

	private Vector3 spawnPosition;
	private int randomValue;

	private GameManager gameManager;

	// Use this for initialization
	void Start () {
		WaitAndSpawn();
	}

	public void WaitAndSpawn () {
		StartCoroutine (Spawn());
	}

	IEnumerator Spawn () {
		GameObject cubeSpawned = null;

		yield return new WaitForSeconds(Random.Range(1, 3));
		
		randomValue = Random.Range(0, 100);
		
		if (randomValue >= 0 && randomValue < 70) {
			cubeSpawned = (GameObject) Instantiate(cubePrefabs[0], transform.position, Quaternion.identity);//Random.rotation);
		} else if (randomValue >= 70 && randomValue < 90) {
			cubeSpawned = (GameObject) Instantiate(cubePrefabs[1], transform.position, Quaternion.identity); //Random.rotation);
		} else if (randomValue >= 90 && randomValue < 95) {
			cubeSpawned = (GameObject) Instantiate(cubePrefabs[2], transform.position, Quaternion.identity); //Random.rotation);
		} else if (randomValue >= 95) {
			cubeSpawned = (GameObject) Instantiate(cubePrefabs[3], transform.position, Quaternion.identity); //Random.rotation);
		}

		cubeSpawned.GetComponent<Cube>().spawner = this;
	}
}
