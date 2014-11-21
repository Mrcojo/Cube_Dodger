using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour {

	public Portal portal;

	// Use this for initialization
	void Start () {
	}

	void OnTriggerEnter (Collider otherCollider) {
		if (otherCollider.transform.tag == "Player") {
			portal.Addkey();
			GameObject.Destroy(gameObject);
		}

	}
}
