using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour {

	public Portal portal;
	public AudioClip clip;

	// Use this for initialization
	void Start () {
	}

	void OnTriggerEnter (Collider otherCollider) {
		if (otherCollider.transform.tag == "Player") {
			AudioSource.PlayClipAtPoint(clip, transform.position);
			portal.Addkey();
			GameObject.Destroy(gameObject);
		}

	}
}
