using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossFireGroundAttack : MonoBehaviour {

    public GameObject fireDOTSpawn;
    public Collider bossWhipCollider;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
		
	}
    void OnCollisionEnter(Collision collision)
    {
       if(collision.gameObject.tag == "lavaWhip")
        {
            Instantiate(fireDOTSpawn);
        }
    }
}
