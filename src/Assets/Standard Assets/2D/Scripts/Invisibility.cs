using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Invisibility : MonoBehaviour {

    public float timer;
    private Transform player;
    Text printTimer;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
  //          printTimer.text = "Teleport in " + (int)timer + "s";
        }
        if (timer < 0)
        {
            GameObject.Find("Feanor").layer = 0;
            timer = 0;
      //      printTimer.text = "Teleport in " + (int)timer + "s";
        }
        if (Input.GetKeyDown(KeyCode.R) || Input.GetKey(KeyCode.R)){
            GameObject.FindGameObjectWithTag("Player").layer = 8;
            if (Invisible())
                timer = 5;
        }
    }

    bool Invisible()
    {
        if (GameObject.Find("Feanor").layer == 8)
        {
            return true;
        }
        return false;
    }
}
