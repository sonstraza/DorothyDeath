using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawn : MonoBehaviour {
    [Header("Show in Inspector")]
    public GameObject enemyToSpawn;
    public float secondsBetweenSpawns = 3f;

	// Use this for initialization
	void Start () {

        Invoke("Spawn", secondsBetweenSpawns);
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Spawn()
    {
        GameObject enemy = Instantiate<GameObject>(enemyToSpawn);      // c

        enemy.transform.position = transform.position;                  // d

        Invoke("Spawn", secondsBetweenSpawns);
    }
}
