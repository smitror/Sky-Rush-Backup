using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //Get player rigidbody
    private Rigidbody planeRb;

    //Invert the players up and down
    public bool Invert = false;
    //Players speed, brake, acceration
    public float speedIncrement;
    public float brakeIncrement = 0.4f;
    public float maxSpeed = 40f;
    public float speed;
    //Get players inputs as values
    public float responsiveness = 10f;
    private float roll;
    private float pitch;
    private float yaw;
    private float responseModifier
    {
        get 
        {
            return (planeRb.mass / 5f) * responsiveness;
        }
    }
    //Speed text for UI
    public Text SpeedText;

    //UI Screens
    public GameObject resetScreen;
    public GameObject InGame;

    //Invert UI CHanges
    public GameObject InvertTick;
    public GameObject InvertW;
    public GameObject InvertS;
    public GameObject Wtext;
    public GameObject Stext;

    //Particles
    public ParticleSystem explosionParticle;
    
    //Audio
    private AudioSource playerAudio;

    //Linked Scripts
    private CameraController cameracontroller;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        // Get Players Rigidbody.
        planeRb = GetComponent<Rigidbody>();
        playerAudio = GetComponent<AudioSource>();
        cameracontroller = GameObject.Find("Camera").GetComponent<CameraController>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // get the user's input
        

        // move the plane forward at a constant rate
        planeRb.velocity = transform.forward * -speed;

        // tilt the plane up/down based on up/down arrow keys
        SpeedText.text = (planeRb.velocity.magnitude * 4f).ToString("F0");
        if (Input.GetKey(KeyCode.Space)) speed += speedIncrement;
        else speed-= speedIncrement;
        if (Input.GetKey(KeyCode.LeftShift)) speed -= brakeIncrement;  
        speed = Mathf.Clamp(speed, 25f, 1000f); 
        
        speedIncrement = (15 / speed);
        planeRb.AddTorque(transform.up * yaw * responseModifier);
        planeRb.AddTorque(transform.forward * roll * responseModifier);
        HandleInputs();
        if (Invert == false)
        {
            planeRb.AddTorque(transform.right * pitch * responseModifier);
        }
        if (Invert == true)
        {
           planeRb.AddTorque(-transform.right * pitch * responseModifier); 
        }
    }
    private void HandleInputs()
    {
        roll = Input.GetAxis("Roll");
        pitch = Input.GetAxis("Vertical");
        yaw = Input.GetAxis("Horizontal");
    }
    private void FixedUpdate()
    {
        planeRb.AddForce(-transform.forward * maxSpeed * speed);
        
    }
    public void resetPlane()
    {
        speed = 50;
    }
    public void resetPlaneVelocity()
    {
        planeRb.angularVelocity = Vector3.zero;
    }

    private void OnCollisionEnter(Collision collision)
   {
      planeRb.angularVelocity = Vector3.zero;
      gameObject.SetActive(false);
    
      resetScreen.gameObject.SetActive(true);  
      InGame.gameObject.SetActive(false);  
      explosionParticle.Play();
      cameracontroller.Audio();
      speed = 50;
      gameManager.crash();
      Cursor.lockState = CursorLockMode.None;
   }
    public void InvertControls()
    {
        if (Invert == true)
        {
            Invert = false;
            InvertTick.gameObject.SetActive(false);
            InvertW.gameObject.SetActive(false);
            InvertS.gameObject.SetActive(false);
            Wtext.gameObject.SetActive(true);
            Stext.gameObject.SetActive(true);
        }
        else if (Invert == false)
        {
            Invert = true;
            InvertTick.gameObject.SetActive(true);
            InvertW.gameObject.SetActive(true);
            InvertS.gameObject.SetActive(true);
            Wtext.gameObject.SetActive(false);
            Stext.gameObject.SetActive(false);
        }
    }
}
