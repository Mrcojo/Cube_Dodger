using UnityEngine;
using System.Collections;

public class PortalDoor : MonoBehaviour {

	private GameManager gameManager;

	// Use this for initialization
	void Start () {
		gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
	}

	// Use this for initialization
	void OnTriggerEnter (Collider otherCollider) {
		gameManager.GameSuccess();
	}

}
