using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour {

	public int numberOfKeysNeeded;
	public GameObject portal;
	public GameObject spotLight;

	private int keys;

	// Use this for initialization
	void Start () {
		keys = 0;
	}

	public void Addkey () {
		keys++;
		if (keys >= numberOfKeysNeeded )  {
			spotLight.SetActive(true);
			portal.SetActive(true);
		}
	}
}
