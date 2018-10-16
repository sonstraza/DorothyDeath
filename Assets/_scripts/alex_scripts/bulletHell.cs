using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletHell : MonoBehaviour {
    public GameObject bullet;
    public float damageAmount;

    public enemyBehaviour enemy;

    public int damage = 50;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision col)
    {

    }
}
