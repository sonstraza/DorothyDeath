using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAttack : MonoBehaviour {

	public GameObject fireBall;
	public Rigidbody rb;

	public float force = 10f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SpawnObject()
	{
		fireBall.SetActive(true);
		Instantiate(fireBall, transform.position, transform.rotation);
		fireBall.GetComponent<Rigidbody>().velocity = fireBall.transform.forward * 6;
	}
}
