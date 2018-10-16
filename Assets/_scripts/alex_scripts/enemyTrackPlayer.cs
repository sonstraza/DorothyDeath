using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyTrackPlayer : MonoBehaviour {
    [Header("Show in Inspetor")]
    public GameObject player;
    public Transform playerCurrentPos;
    public GameObject enemy;

    public Rigidbody enemyRigidBody;
    public float enemySpeed;

	// Use this for initialization
	void Start () {
        enemySpeed = 1;
        

        playerCurrentPos = gameObject.transform.Find("Player");
        player = gameObject.GetComponent<GameObject>();
        enemyRigidBody = GetComponent<Rigidbody>();

	}
	
	// Update is called once per frame
	void Update () {
        //find and update playerCurrentPos for tracking
        playerCurrentPos = player.transform.Find("Player");
        Vector3 trackPos = playerCurrentPos.position- transform.position;
        trackPos.z = 0;
        transform.LookAt(trackPos);

        // Step size equal to speed times time
        float step = enemySpeed * Time.deltaTime;

        Vector3 newDir = Vector3.RotateTowards(transform.forward, trackPos, step, 0.0f);
        Debug.DrawRay(transform.position, trackPos, Color.red);

        //change position rotation of enemies
        //transform.position = Vector3.MoveTowards(trackPos, trackPos, enemySpeed);
        transform.rotation = Quaternion.LookRotation(trackPos);

        //compitent code
	}
}
