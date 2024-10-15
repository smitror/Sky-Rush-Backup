using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class Countdown : MonoBehaviour
{
    bool timerActive = false;
    float countdownTime;
    public Text countdownTimeText;
    private GameManager gameManager;
    public GameObject countdown;
    public GameObject resetScreen;
    public GameObject completeScreen;
    public GameObject titleScreen;
    public GameObject StarTimes;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        countdownTime = 4; 
    }

    // Update is called once per frame
    void Update()
    {
        if (timerActive == true)
        {
            countdownTime = countdownTime - Time.deltaTime;
            countdown.gameObject.SetActive(true);
        }
        TimeSpan time = TimeSpan.FromSeconds(countdownTime);
        countdownTimeText.text = time.ToString(@"s\ ");
        if (countdownTime <= 1)
        {
            gameManager.StartGame();
            countdown.gameObject.SetActive(false);
            
            StopTimer();
            countdownTime = 4;
        }
    }

    public void StartTimer()
    {
        timerActive = true;
        Start();
        gameManager.ResetPlane();
        resetScreen.gameObject.SetActive(false);
        completeScreen.gameObject.SetActive(false);
        StarTimes.gameObject.SetActive(false);
        titleScreen.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void StopTimer()
    {
        timerActive = false;
    }
}
