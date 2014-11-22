using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour {
	public CubeSpawner spawner;

	private int randomValue;

	private GameManager gameManager;

	// Use this for initialization
	void Start () {
		gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

		transform.localScale = Vector3.zero;

		animation.Play("ScaleUp");
	}

	void OnTriggerEnter (Collider otherCollider) {
		if (otherCollider.transform.tag == "Player") {
			switch (transform.tag) {
				case "DamageCube":
					gameManager.RemoveLife();
					break;
				case "TimerCube":
					gameManager.ExtendGameTime();
					break;
				case "GravityCube":
					gameManager.ReduceGravity();
					break;
				case "LifeCube":
					gameManager.AddLife();
					break;
			}
		}

		if (otherCollider.transform.tag == "Environment" && 
		    (otherCollider.transform.tag != "DamageCube" && 
		    otherCollider.transform.tag != "TimerCube" &&
		    otherCollider.transform.tag != "GravityCube" &&
		    otherCollider.transform.tag != "LifeCube")) {

			GameObject.Destroy(gameObject);
			spawner.WaitAndSpawn();
		}
	}
}
