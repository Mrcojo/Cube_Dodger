using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour {

	public int numberOfKeysNeeded;

	public GameObject portal;
	public GameObject spotLight;

	public AudioClip openPortalSound;

	private int keys;
	private GameManager gameManager;
	
	// Use this for initialization
	void Start () {
		gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
		keys = 0;
	}

	public void Addkey () {
		keys++;
		gameManager.UpdateKeysNumber(keys);
		if (keys >= numberOfKeysNeeded )  {
			AudioSource.PlayClipAtPoint(openPortalSound, transform.position);
			spotLight.SetActive(true);
			portal.SetActive(true);
		}
	}
}
