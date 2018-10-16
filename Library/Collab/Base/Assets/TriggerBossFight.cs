using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBossFight : MonoBehaviour {

    public bool playerCrossed;

    public GameObject soundManager;
    public CameraScript cam;
    public AudioSource bgmToDim;
    public AudioSource bossFightMusic;

    public GameObject wall;

	// Use this for initialization
	void Start () {
        wall.SetActive(false);
        soundManager = GetComponent<GameObject>();
        bgmToDim = soundManager.GetComponent<AudioSource>();
        bossFightMusic = soundManager.GetComponent<AudioSource>();
        bossFightMusic.volume = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            bgmToDim.volume = 0;
            bossFightMusic.volume = 1;
            bossFightMusic.Play();
            cam.height = 35.4f;
            cam.xAxis = -2.2f;
            cam.zAxis = -26.17f;
            wall.SetActive(true);
        }
    }

}
