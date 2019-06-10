using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour {

    [SerializeField]
    private float speed1;
	public float detectRange;
    public Vector2 pos;
    private Transform target;
	// Use this for initialization
	void Start () {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
  //a      player = GameObject.FindGameObjectWithTag("Player").GetComponent<>;
    }
	
	// Update is called once per frame
	void Update () {
        if (GameObject.Find("Feanor").layer == 8)
        {
            detectRange = 0;
        } else
        {
            detectRange = 5;
        }
		if (Vector2.Distance (transform.position, target.position) <= detectRange) {
			transform.position = Vector2.MoveTowards (transform.position, target.position, speed1 * Time.deltaTime);
		}
    }  
}
