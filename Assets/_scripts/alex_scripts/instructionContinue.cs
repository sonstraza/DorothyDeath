using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class instructionContinue : MonoBehaviour {
    public Button continueButton;
    public GameObject continueButtonObject;
    
    float startDelay = 5f;
    float startTimer;


    // Use this for initialization
    void Start()
    {
        Button loadButton = continueButton.GetComponent<Button>();
        continueButtonObject.SetActive(false);
        loadButton.onClick.AddListener(LoadLevel);
    }

    // Update is called once per frame
    void Update()
    {
        startTimer += Time.deltaTime;
        if (startDelay <= startTimer)
        {
            continueButtonObject.SetActive(true);
        }
    }

    void LoadLevel()
    {
        SceneManager.LoadScene(2);
    }
}
