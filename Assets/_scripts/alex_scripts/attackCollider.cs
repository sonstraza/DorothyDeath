using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackCollider : MonoBehaviour {
    [Header("Show in Inspector")]
    public int damage;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void onCollision(Collision coll)
    {
        GameObject collidedWith = coll.gameObject;

        if(collidedWith.tag == "Enemy")
        {
         //   enemyHealth--;
        }
    }
}
