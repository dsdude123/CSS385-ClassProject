using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeAttack : MonoBehaviour
{

    public float attackRange;
    public float frequencyInSeconds;
    private GameObject target;
    private float lastAttack;
    // Use this for initialization
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        lastAttack = -frequencyInSeconds;
    }

    // Update is called once per frame
    void Update()
    {
        //if ((Vector2.Distance(transform.position, target.transform.position) <= attackRange) && Time.time - lastAttack >= frequencyInSeconds)
        //{
        //    target.GetComponent<Health>().currentHealth--;
        //    lastAttack = Time.time;
        //}
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Enemy") && Time.time - lastAttack >= frequencyInSeconds)
        {
            other.GetComponent<Health>().currentHealth--;
            lastAttack = Time.time;
        }
        if (other.gameObject.tag.Equals("Player") && Time.time - lastAttack >= frequencyInSeconds)
        {
            other.GetComponent<Health>().currentHealth--;
            lastAttack = Time.time;
        }
    }
}