using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float movementSpeed;
    public float movementSpeedMulti = 1;
    float movementSpeedDelta;
    public float attackSpeed = 3f;
    public float speedOfAttack = 3f;
	public float dashTime = 1.3f;
	public float dashTimeDelta;
	public float distance = 5.0f;

	private int scytheDelay = 3;
	

    public Animator animPlayer;

    public Rigidbody rigid;
    


	public bool leftShift;


    public bool isAttackedHeavy;

    public bool attacking;
    public bool attacking_2;
    public bool attacking_3;

    public bool canAttack;
    public bool canAttack_2;
    public bool canAttack_3;

    public bool moving;
    public bool canMove;
	public bool dashing;

	public bool canDash;

    public bool inAction;
    public bool isGrounded;

    public GameObject player;
    public GameObject scytheAttacking;
    public GameObject scytheIdle;
	public GameObject dashParticle;


    void Start()
    {
		dashParticle.SetActive(false);
		dashing = false;
		canDash = true;
		dashTimeDelta = dashTime;
		
		rigid = GetComponent<Rigidbody>();
        movementSpeedDelta = movementSpeed;
        animPlayer.SetBool("isMoving", false);
        isAttackedHeavy = false;
    }

    void Update()
    {
		if(dashTimeDelta == dashTime)
		{
			canDash = true;
		}
		if(dashing == true)
		{
			dashParticle.SetActive(true);
			canDash = false;
			dashTimeDelta -= Time.deltaTime;
			if(dashTimeDelta <= 0)
			{
				dashTimeDelta = dashTime;
				canDash = true;
				dashing = false;
				dashParticle.SetActive(false);
			}		
		}

        if(canAttack == true)
        {
            canAttack_3 = false;
        }

        if (inAction == true)
        {
            canMove = false;
            moving = false;
            movementSpeed = 0;
        }

        if (inAction == false)
        {
            canMove = true;		
            movementSpeed = movementSpeedDelta;
        }

        if (attacking == true) {
            scytheAttacking.SetActive(true);
            scytheIdle.SetActive(false);
        }

        if(attacking == false)
        {
            scytheAttacking.SetActive(false);
            scytheIdle.SetActive(true);
        }

        if(attacking_2 == true)
        {
            canAttack_2 = false;
        }
        if(attacking_3 == true)
        {
            canAttack_3 = false;
        }

        Plane playerPlane = new Plane(Vector3.up, transform.position);
        //Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
        float hitDist = 0.0f;

        if (attackSpeed == speedOfAttack)
        {
            canAttack = true;
            canAttack_2 = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (canAttack == true)
            {
                animPlayer.SetBool("isAttacking", true);
                inAction = true;
                attacking = true;
                Debug.Log("Attacking");

            }
        }
        if(attacking == true)
        {
            
            canAttack = false;
            attackSpeed -= Time.deltaTime;
            if (Input.GetMouseButtonUp(0))
            {
                canAttack_2 = true;
            }
            if (Input.GetMouseButtonDown(0))
            {
                if(canAttack_2 == true)
                {
                    animPlayer.SetBool("isAttacking_2", true);
                    attackSpeed = speedOfAttack;
                    inAction = true;            
                    attacking_2 = true;                                 
                    canAttack_2 = false;
                }
            }
            if (attackSpeed <= 0)
            {
                animPlayer.SetBool("isAttacking_2", false);
                attackSpeed = 0;              
                attacking = false;
                attacking_2 = false;
                attacking_3 = false;                            
            }
        }

        if(attacking_2 == true)
        {
            if (Input.GetMouseButtonUp(0))
            {
                canAttack_3 = true;
            }
            if (Input.GetMouseButtonDown(0))
            {
                if (canAttack_3 == true)
                {
                    animPlayer.SetBool("isAttacking_3", true);
                    attackSpeed = speedOfAttack;
                    inAction = true;
                    attacking_3 = true;                   
                    canAttack_3 = false;
                }
            }
        }

        if (attacking == false)
        {
            attacking = false;
            attacking_2 = false;
            scytheAttacking.SetActive(false);
            scytheIdle.SetActive(true);
            animPlayer.SetBool("isAttacking", false);
            animPlayer.SetBool("isAttacking_2", false);
            animPlayer.SetBool("isAttacking_3", false);
            inAction = false;
            attackSpeed += Time.deltaTime;
            if (attackSpeed > speedOfAttack)
                attackSpeed = speedOfAttack;
            if (attackSpeed == speedOfAttack)
                canAttack = true;
        }



		if (canMove == true)
            PlayerController();
    }

    void PlayerController()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        if (movement != Vector3.zero)
        {
            moving = true;
            if(moving == true)
                animPlayer.SetBool("isMoving", true);
            
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement.normalized), 0.15f);
        }
        if (movement == Vector3.zero)
        {
            moving = false;
            if(moving == false)
                animPlayer.SetBool("isMoving", false);
        }
        
        if(moving == true && attacking == true)
        {
            moving = false;
        }

        transform.Translate(movement * (movementSpeed * movementSpeedMulti) * Time.deltaTime, Space.World);

		if (Input.GetKeyDown(KeyCode.LeftShift))
		{
			if (canDash == true)
			{
				Dashing();	
			}
		}
    }

	void Dashing()
	{
		if (canDash == true)
		{
			dashing = true;
			
			Debug.Log("Dashing");
			RaycastHit hit;
			Vector3 destination = transform.position + transform.forward * distance;

			if (Physics.Linecast(transform.position, destination, out hit))
			{
				destination = transform.position + transform.forward * (hit.distance - 1f);
			}

			if (Physics.Raycast(destination, -Vector3.up, out hit))
			{
				destination = hit.point;
				destination.y = 0.5f;
				transform.position = destination;
			}
			
		}
	}

    void IsAttackedHeavy() {
        animPlayer.SetBool("isAttackedHeavy", true);

        float iFrames = .5f;

        while (iFrames > 0)
        {
            iFrames -= Time.deltaTime;
        }      
        if(iFrames < 0)
        {
            animPlayer.SetBool("isAttackedHeavy", false);
        }
    }


    /*
    IEnumerator ScytheINidle()
    {
        yield return new WaitForSeconds(scytheDelay);

    }
    */

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "floor")
        {
            isGrounded = true;
        }
        if (col.gameObject.tag == "heavyBullet")
        {
            isAttackedHeavy = true;
        }
        
    }
    void OnCollisionExit(Collision col)
    {
        if(col.gameObject.tag == "floor")
        {
            isGrounded = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        
    }

    void OnTriggerExit(Collider other)
    {

    }
}
