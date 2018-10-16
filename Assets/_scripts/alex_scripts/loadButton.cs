using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loadButton : MonoBehaviour {
    public Button startButton;
    public GameObject startButtonObject;

    public Button quitButton;
    public GameObject quitButtonObject;


	// Use this for initialization
	void Start () {

        Button loadButton = startButton.GetComponent<Button>();
        Button exitButton = quitButton.GetComponent<Button>();

        startButtonObject.SetActive(false);
        quitButtonObject.SetActive(false);

        loadButton.onClick.AddListener(LoadLevel);
        exitButton.onClick.AddListener(Quit);
	}
	
	// Update is called once per frame
	void Update () {

	}

    void LoadLevel()
    {
        SceneManager.LoadScene(0);
    }

    void Quit()
    {
        Application.Quit();
    }
    
}
