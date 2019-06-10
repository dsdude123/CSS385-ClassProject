using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartMonitor : MonoBehaviour {

	private Sprite fullHeart;
	private Health target;
	public Sprite emptyHeart;
	public uint monitorHealthAt;

	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
		fullHeart = this.GetComponent<UnityEngine.UI.Image> ().sprite;
	}
	
	// Update is called once per frame
	void Update () {
		if (target.currentHealth < monitorHealthAt) {
			this.GetComponent<UnityEngine.UI.Image> ().sprite = emptyHeart;
		} else {
			this.GetComponent<UnityEngine.UI.Image> ().sprite = fullHeart;
		}
	}
}
