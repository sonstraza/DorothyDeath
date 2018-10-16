using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonLordScript : MonoBehaviour {


    public float bossHealth;
    //[Alex] above is both health and player collision stuff

	public Animator anim;
    
	public TriggerBossFight tbf;

	public GameObject fireball;
	public GameObject spawner_1;
	public GameObject spawner_2;
	public GameObject spawner_3;
	public GameObject spawner_4;
	public GameObject spawner_5;
	public GameObject spawner_6;
	public GameObject spawner_7;
	public GameObject spawner_8;
	public GameObject spawner_9;
	public GameObject spawner_10;
	public GameObject spawner_11;
	public GameObject spawner_12;
	public GameObject spawner_13;
	public GameObject spawner_14;
	public GameObject spawner_15;
	public GameObject spawner_16;
	public GameObject spawner_17;
	public GameObject spawner_18;
	public GameObject spawner_19;
	public GameObject spawner_20;
	public GameObject spawner_22;
	public GameObject spawner_23;
	public GameObject spawner_24;
	public GameObject spawner_25;
	public GameObject spawner_26;
	public GameObject spawner_27;
	public GameObject spawner_28;
	public GameObject spawner_29;
	public GameObject spawner_30;
	public GameObject spawner_31;
	public GameObject spawner_32;
	public GameObject spawner_33;
	public GameObject spawner_34;
	public GameObject spawner_35;
	public GameObject spawner_36;
	public GameObject spawner_37;
	public GameObject spawner_38;
	public GameObject spawner_39;
	public GameObject spawner_40;


	public Rigidbody fireballRB;
	int fireballSpeed = 5;

	public int[] bossAttack = new int[5];

	private int randAttack;

	float attackTime = 2f;
	float attackTimeDelta;

	public float idleTime = 5f;
	
	public float idleTimeDelta;

	bool canAttack;
	bool isIdle;

	bool attacking;

	public bool startTimer;





	// Use this for initialization
	void Start () {
		attacking = false;
		startTimer = false;
		attackTimeDelta = attackTime;
		idleTimeDelta = idleTime;
		anim = GetComponent<Animator>();
		anim.SetBool("isBossTriggered", false);
	}

	// Update is called once per frame
	void Update () {

		if (startTimer == false)
		{
			anim.SetInteger("anim", 0);
		}

		if (startTimer == true)
		{
			idleTimeDelta -= Time.deltaTime;
		}

		if(idleTimeDelta <= 0)
		{
			startTimer = false;
			idleTimeDelta = idleTime;
			RandomizeAttack(bossAttack);
			Attack();
		}

		if(idleTimeDelta != idleTime)
		{
			anim.SetInteger("anim", 0);
		}


		if (tbf.playerCrossed)
		{
			anim.SetBool("isBossTriggered", true);
			startTimer = true;
		}


	}

	void RandomizeAttack(int[] bossAttack)
	{
		if (idleTimeDelta == idleTime)
		{
			for (int i = 0; i < bossAttack.Length; i++)
			{
				bossAttack[i] = Random.Range(1, bossAttack.Length + 1);
				randAttack = bossAttack[i];
			}
			anim.SetInteger("anim", randAttack);
			startTimer = true;
		}
	}

	void Attack()
	{
		if(randAttack == 1)
		{
			print("Attack 1");
			Attack_1();
		}

		if (randAttack == 2)
		{
			print("Attack 2");
			Attack_2();
		}

		if (randAttack == 3)
		{
			print("Attack 3");
			Attack_3();
		}

		if (randAttack == 4)
		{
			print("Attack 4");
			Attack_2();
		}

		if (randAttack == 5)
		{
			print("Attack 5");
			Attack_2();
		}
	}

	void Attack_1()
	{
		Instantiate(fireball, spawner_1.transform.position, transform.rotation);
		Instantiate(fireball, spawner_2.transform.position, transform.rotation);
		Instantiate(fireball, spawner_3.transform.position, transform.rotation);
		Instantiate(fireball, spawner_4.transform.position, transform.rotation);
		Instantiate(fireball, spawner_5.transform.position, transform.rotation);
		Instantiate(fireball, spawner_6.transform.position, transform.rotation);
	}

	void Attack_2()
	{
		int Rand = Random.Range(1, 3);

		if (Rand == 1)
		{
			print(Rand);
			Instantiate(fireball, spawner_7.transform.position, transform.rotation);
			Instantiate(fireball, spawner_8.transform.position, transform.rotation);
			Instantiate(fireball, spawner_9.transform.position, transform.rotation);
			Instantiate(fireball, spawner_10.transform.position, transform.rotation);
			Instantiate(fireball, spawner_11.transform.position, transform.rotation);
			Instantiate(fireball, spawner_12.transform.position, transform.rotation);
			Instantiate(fireball, spawner_13.transform.position, transform.rotation);
		}
		if (Rand == 2)
		{
			print(Rand);
			Instantiate(fireball, spawner_14.transform.position, transform.rotation);
			Instantiate(fireball, spawner_15.transform.position, transform.rotation);
			Instantiate(fireball, spawner_16.transform.position, transform.rotation);
			Instantiate(fireball, spawner_17.transform.position, transform.rotation);
			Instantiate(fireball, spawner_18.transform.position, transform.rotation);
			Instantiate(fireball, spawner_19.transform.position, transform.rotation);
			Instantiate(fireball, spawner_20.transform.position, transform.rotation);
			Instantiate(fireball, spawner_22.transform.position, transform.rotation);
			Instantiate(fireball, spawner_23.transform.position, transform.rotation);
			Instantiate(fireball, spawner_24.transform.position, transform.rotation);
			Instantiate(fireball, spawner_25.transform.position, transform.rotation);
			Instantiate(fireball, spawner_26.transform.position, transform.rotation);
			Instantiate(fireball, spawner_27.transform.position, transform.rotation);
			Instantiate(fireball, spawner_28.transform.position, transform.rotation);
		}
	}

	void Attack_3()
	{
		Instantiate(fireball, spawner_29.transform.position, transform.rotation);
		Instantiate(fireball, spawner_30.transform.position, transform.rotation);
		Instantiate(fireball, spawner_31.transform.position, transform.rotation);
		Instantiate(fireball, spawner_32.transform.position, transform.rotation);
		Instantiate(fireball, spawner_33.transform.position, transform.rotation);
		Instantiate(fireball, spawner_34.transform.position, transform.rotation);
		Instantiate(fireball, spawner_35.transform.position, transform.rotation);
		Instantiate(fireball, spawner_36.transform.position, transform.rotation);
		Instantiate(fireball, spawner_37.transform.position, transform.rotation);
		Instantiate(fireball, spawner_38.transform.position, transform.rotation);
		Instantiate(fireball, spawner_39.transform.position, transform.rotation);
		Instantiate(fireball, spawner_40.transform.position, transform.rotation);
	}

	void Attack_4()
	{

	}

	void Attack_5()
	{

	}
}
