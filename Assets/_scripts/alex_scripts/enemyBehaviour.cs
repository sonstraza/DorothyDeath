using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBehaviour : MonoBehaviour
{
    [Header("Show in Inspector")]
    public float enemyHealth = 50;
    public float currentHealth;
    public float sinkSpeed = 2.5f; //speed which enemy disappears through floor
    public GameObject Enemy;
    public int scoreValue = 10;

    AudioSource deathAudio; //audio for death sound
    AudioSource enemyAudio; //reference the audio source

    Animator anim;
    CapsuleCollider capsuleCollider; //reference collider
    public GameObject damageTest;

    // Use this for initialization
    void Start()
    {
        //Get references
        anim = GetComponent<Animator>();
        enemyAudio = GetComponent<AudioSource>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        deathAudio = GetComponent<AudioSource>();

        currentHealth = enemyHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            Death();
        }
    }

    public void TakeDamage(int damageAmount)
    {
        //otherwise
        enemyAudio.Play();

        //reduce health by damage amount
        currentHealth -= damageAmount;

    }

    void Death()
    {
        deathAudio.Play();
       // isDead = true;  //set enemy to dead
        capsuleCollider.isTrigger = true; //collider becomes trigger so no longer blocked by dead body

        Destroy(this.gameObject, 1f);

        //set enemy to dissappear
       // isSinking = true;

    }

    void OnCollisionEnter(Collision collision)
    {
        if (enemyHealth > 0)
        {
            if (collision.gameObject.tag == "damage")
            {
                TakeDamage(40);
            }else if(collision.gameObject.tag == "Weapon")
            {
                TakeDamage(100);
            }
        }
        else
        {
            Death();
        }
    }
}
