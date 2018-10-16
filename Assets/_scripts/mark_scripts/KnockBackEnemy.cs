using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBackEnemy : MonoBehaviour {

    public Transform target;
    public Transform myTransform;

    public Player player;

    public Rigidbody rb;

    public bool inHitbox;

    public float moveSpeed = 5f;

    public float knockBackForce;
    public float knockBackTime;
    private float knockBackCounter;

    public Vector3 moveDirection;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {


		if(knockBackCounter <= 0)
        {
            transform.LookAt(target);
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        else
        {
            knockBackCounter -= Time.deltaTime;
            rb.AddForce((transform.forward * -1) * knockBackForce);
        }
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "hitbox")
        {
            inHitbox = true;
        }
        if (inHitbox == true)
        {
            if (col.gameObject.tag == "Weapon" && player.attacking == true)
            {
                knockBackCounter = 1;               
                Debug.Log("Knocked Back");
            }
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "hitbox")
        {
            inHitbox = false;
        }
    }
}
