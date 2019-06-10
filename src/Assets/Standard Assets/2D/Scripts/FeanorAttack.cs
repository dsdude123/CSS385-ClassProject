using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Work In Progress
// Any Assistance Would Be Nice
//


public class FeanorAttack : MonoBehaviour {
    private Animator animator;
	public float attackRange;
	public float frequencyInSeconds;
	private float closestDist;
	private float lastAttack;
    // Use this for initialization
    void Start()
    {
        animator = this.GetComponent<Animator>();
		lastAttack = -frequencyInSeconds;
    }

    // Update is called once per frame
    void Update()
    {
		closestDist = float.MaxValue;
        var vertical = Input.GetAxis("Vertical");
        var horizontal = Input.GetAxis("Horizontal");
		animator.SetInteger("AttackD", 4);
		if((Input.GetKeyDown(KeyCode.E) || Input.GetKey(KeyCode.E)) && (Time.time - lastAttack) >= frequencyInSeconds) {
			Movement direction = GameObject.FindGameObjectWithTag ("Player").GetComponent<Movement>();
			if (direction.direction.Equals(Vector2.up))
        {
            animator.SetInteger("AttackD", 0);
        }
			else if (direction.direction.Equals(Vector2.down))
        {
            animator.SetInteger("AttackD", 1);
        }
			else if (direction.direction.Equals(Vector2.right))
        {
            animator.SetInteger("AttackD", 2);
        }
			else if (direction.direction.Equals(Vector2.left))
        {
            animator.SetInteger("AttackD", 3);
        }
			var audioSource = GameObject.FindGameObjectWithTag ("Player").GetComponent<AudioSource>();
			audioSource.PlayOneShot (audioSource.clip);

			lastAttack = Time.time;
			GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Enemy");
			if (enemies.Length < 1) {
				return;
			}
			GameObject closestEnemy = null;
			foreach (GameObject g in enemies) {
				if (Vector2.Distance (transform.position, g.transform.position) <= closestDist) {
					closestEnemy = g;
					closestDist = Vector2.Distance (transform.position, g.transform.position);
				}
			}
			if ((Vector2.Distance (transform.position, closestEnemy.transform.position) <= attackRange)) {
				closestEnemy.GetComponent<Health> ().currentHealth--;
			}


        }
    }
}
