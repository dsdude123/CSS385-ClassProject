using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuMusicKiller : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject i = GameObject.Find ("MainMenuMusic");
		Destroy (i);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
