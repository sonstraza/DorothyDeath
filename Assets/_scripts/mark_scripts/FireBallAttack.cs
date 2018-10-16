using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallAttack : MonoBehaviour {

	public GameObject fireball;
	Rigidbody rb;


	// Use this for initialization
	void Start()
	{ 
		rb = GetComponent<Rigidbody>();
	}

	void Update()
	{
		rb.AddForce(transform.forward * 20);
	}
}
