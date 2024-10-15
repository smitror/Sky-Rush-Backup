using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinshController : MonoBehaviour
{
    public GameObject completeScreen;
    public GameObject ingameScreen;
    public GameObject Plane;
    private Timer timer;
    

    private AudioSource finishAudio;
    public AudioClip finishSound;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {  
      gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
      timer = GameObject.Find("Canvas").GetComponent<Timer>();
      finishAudio = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
      gameManager.PlaneResetting();
      completeScreen.gameObject.SetActive(true);
      Plane.gameObject.SetActive(false);
      ingameScreen.gameObject.SetActive(false);
      timer.StopTimer();
      finishAudio.PlayOneShot(finishSound, 1.0f);
      Cursor.lockState = CursorLockMode.None;
    }
}
