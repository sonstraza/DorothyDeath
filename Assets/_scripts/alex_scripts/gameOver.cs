using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOver : MonoBehaviour {

    public statsParameters playerStats;
    public float restartDelay = 5f;

    Animator anim;
    float restartTimer;

    Scene currentScene = SceneManager.GetActiveScene();


    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(playerStats.currentHealth <= 0)
        {
            anim.SetTrigger("GameOver");
            restartTimer += Time.deltaTime;

            if(restartTimer > restartDelay)
            {
                //Application.LoadLevel(Application.loadedLevel);
                SceneManager.LoadScene(currentScene.name);
            }

            //TODO: Change restart timer to buttons
            //Buttons: Main Menu, Quit, Restart Level
        }
	}
}
