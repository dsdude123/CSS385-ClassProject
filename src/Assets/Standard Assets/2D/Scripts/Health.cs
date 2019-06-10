using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour {

	public int currentHealth = 0;
	public bool isPlayer = false;
	public AudioClip injureSound;
	public AudioClip healSound;

	int lastHealth = 0;

	// Use this for initialization
	void Start () {
		lastHealth = currentHealth;
	}
	
	// Update is called once per frame
	void Update () {
		if (isPlayer && lastHealth != currentHealth) {
			AudioSource aud = this.gameObject.GetComponent<AudioSource> ();
			if (lastHealth > currentHealth) {
				aud.PlayOneShot (injureSound);
			} else {
				aud.PlayOneShot (healSound);
			}
		}
		lastHealth = currentHealth;
		if (currentHealth < 1) {
			Destroy (this.gameObject);
			if (isPlayer) {
				SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
			}
		}
	}
}
