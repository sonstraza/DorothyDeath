using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class statsParameters : MonoBehaviour {

    [Header("Show In Inspector")]
    public GameObject player;
    public Player playerScript;

    public Animation deathAnimation;

    public AudioClip playerDamageClip;
    public AudioSource playerDamageSource;
    public bool damageAudioPlaying = false;
    public bool playDamageAudio = false;

    public AudioClip playerAttackClip;
    public AudioSource playerAttackSource;
    public bool playerAttackPlaying = false;
    public bool playPlayerAttack = false;

    public float currentHealth = 100;
    public float maxHealth = 100;
    public float totalHealth;

    public float energy = 100;
    public float maxEnergy = 100;
    public float totalEnergy;

    public float attackValue;
    public float defenseValue;


    /*
     * stats:
     * 
     * health
     * mana or energy
     * attack
     * defense
     * 
     * */


    // Use this for initialization
    void Start () {
        currentHealth = 80.0f;
        maxHealth = 100.0f;

        //playerDamageSource = GetComponent<AudioSource>(); //start get audio component
    }
	
	// Update is called once per frame
	void Update () {

        if (playerScript.attacking)// && playPlayerAttack == true)
        {
            playerAttackSource.PlayOneShot(playerAttackClip, 1f);
            energy -= 2f;
            //playerAttackPlaying = true;
        }

        totalEnergy = energy / maxEnergy;
        totalHealth = currentHealth / maxHealth;
	}
    private void FixedUpdate()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "enemyDamage")// && damageAudioPlaying == false)
        {
            currentHealth -= 2f;
            playerDamageSource.PlayOneShot(playerDamageClip, 1F); //audio for attack (0-1F for volume)
            //damageAudioPlaying = true;
            //playDamageAudio = true;
        }
        if (Input.GetMouseButtonDown(0))
        {
            energy -= 1.0f;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            energy -= 5f;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //if(other.gameObject.tag == "enemyDamage")
        //{
            //playDamageAudio = false;
            //damageAudioPlaying = false;
        //}
    }
}
