using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMain : MonoBehaviour {

    public float delay = 22;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        delay -= Time.deltaTime;
        if (delay <= 0)
            SceneManager.LoadScene("MainScreen");
    }
}
