using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToEpilogue : MonoBehaviour {

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        alive();
    }

    public bool alive()
    {
        if(GameObject.Find("Sugzar") == false)
            SceneManager.LoadScene("Epilogue");
        return false;
    }
}
