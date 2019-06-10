using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    [SerializeField]
    private float speed;
    private Transform target;
    private Animator animator;
    public Vector2 direction = Vector2.down;

	// Use this for initialization
	void Start () {
        animator = this.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        GetInput();	
	}

    public void Move()
    {
        transform.Translate(direction*speed*Time.deltaTime);
    }

    private void GetInput()
    {
        
		if (Input.GetKey (KeyCode.W)) {
			animator.SetInteger ("Direction", 0);
			direction = Vector2.zero;
			direction = Vector2.up;
			Move ();
		} else if (Input.GetKey (KeyCode.S)) {
			animator.SetInteger ("Direction", 1);
			direction = Vector2.zero;
			direction = Vector2.down;
			Move ();
			//
		} else if (Input.GetKey (KeyCode.A)) {
			animator.SetInteger ("Direction", 3);
			direction = Vector2.zero;
			direction = Vector2.left;
			Move ();
			//
		} else if (Input.GetKey (KeyCode.D)) {
			animator.SetInteger ("Direction", 2);
			direction = Vector2.zero;
			direction = Vector2.right;
			Move ();
			//
		} else {
			animator.SetInteger ("Direction", 4);
		}
    }
}
