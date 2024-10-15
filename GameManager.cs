using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Is the game running or is the player in the menu
    public bool isGameActive = false;

    // Is the FPS counter active
    public bool IsFPSActive = false;

    // Is the infinte level active
    public bool InfinteActive = false;

    // In Game objects
    public GameObject Plane;

    // UI Game objects
    public GameObject titleScreen;
    public GameObject resetScreen;
    public GameObject completeScreen;
    public GameObject mapScreen;
    public GameObject ControlsScreen;
    public GameObject SettingsScreen;
    public GameObject InGame;
    public GameObject Star1;
    public GameObject Star2;
    public GameObject Star3;
    public GameObject SnowTimes;
    public GameObject CanyonTimes;
    public GameObject GrassTimes;
    public GameObject StarTimes;
    public GameObject InfinteScoreCounter;
    public GameObject TimerCounter;
    public GameObject FPSDisplay;
    public GameObject FPSTick;
    public Text DistanceScoreCount;
    
    // Level Game objects
    public GameObject canyon;
    public GameObject grass;
    public GameObject snow;
    public GameObject infinte;
    
    // Access other scripts
    private PlayerController playercontroller;
    private ControlsPlaneController controlsPlaneController;
    private InfinteMap infintemap;
    private InfinteMapTwo infintemap2;
    private Timer timer;

    // Camera controls
    public Camera cam;

    // Variables
    private float plane_speed;
    private float last_speed;
    public float zoomStep;
    private float _hudRefreshRate = 1f;
    private float _timer;
    float currentFov; //currentQuantity
    float desiredFov; //desiredQuantity
    
    // Update Texts
    public Text _fpsText;
    public Text FOVText;

    // Settings Slider
    public Slider mySlider;
    
 
    // Start is called before the first frame update
    void Start()
    {
        // Access scripts
        playercontroller = GameObject.Find("Plane").GetComponent<PlayerController>();
        timer = GameObject.Find("Canvas").GetComponent<Timer>();
        controlsPlaneController = GameObject.Find("ControlPlane").GetComponent<ControlsPlaneController>();
        infintemap = GameObject.Find("Group 1").GetComponent<InfinteMap>();
        infintemap2 = GameObject.Find("Group 2").GetComponent<InfinteMapTwo>();

        // Set objects to not be active
        Plane.gameObject.SetActive(false);
        ControlsScreen.gameObject.SetActive(false);
        infinte.gameObject.SetActive(false);

        // Set FOV
        currentFov = 70f;
        desiredFov = currentFov;

        // Dont lock the cursor
        Cursor.lockState = CursorLockMode.None;
    }
        void Update()
    {
        // Get the plane's speed for the player controller script
        plane_speed = playercontroller.speed;

        // FOV
        if (isGameActive)
        {
            zoomStep = mySlider.value;

            // If the plane is slowing down decease fov
            if (plane_speed < last_speed)
            {
                // Zoom in
                last_speed = plane_speed;
                desiredFov = 60f;
                // CurrentFOV to minFOV
            }
            // Else if the plane is speeding up increase the fov
            else if (plane_speed > last_speed)
            {
                // Zoom
                last_speed = plane_speed;
                desiredFov = 80f;
                // Current FOV to maxFOV
            }
        }
        // If the game is not active reset the fov back to 70
        else
        {
            zoomStep = 20.0f;
            desiredFov = 70f;
        }

        // Apply the fov to the camera
        currentFov = Mathf.MoveTowards(currentFov, desiredFov, zoomStep * Time.deltaTime);
        cam.fieldOfView = currentFov;

        // Calculate the distance score for the infinte level
        DistanceScoreCount.text = (-Plane.transform.position.z).ToString("0 M");
        FOVText.text = (mySlider.value).ToString("F0");

        // FOV counter
        if (Time.unscaledTime > _timer)
        {
            int fps = (int)(1f / Time.unscaledDeltaTime);
            _fpsText.text = " " + fps;
            _timer = Time.unscaledTime + _hudRefreshRate;
        }
        

    }

    // When the start button is clicked
    public void StartGame()
    {
        ResetUI();
        resetInfinte();
        isGameActive = true;
        StarTimes.gameObject.SetActive(true);
        InGame.gameObject.SetActive(true);
        
        Plane.gameObject.SetActive(true);
        timer.StartTimer();
        Star1.gameObject.SetActive(false);
        Star2.gameObject.SetActive(false);
        Star3.gameObject.SetActive(false);
        
        if (InfinteActive == true)
        {
            StarTimes.gameObject.SetActive(false);
        }
        Plane.transform.position = new Vector3(0, 0, 0);
        Plane.transform.rotation = Quaternion.identity;
        playercontroller.resetPlane();
        
    }
    public void PlaneResetting()
    {
        playercontroller.resetPlaneVelocity();
    }
    public void ResetTitleScreen()
    {
        ResetUI();
        titleScreen.gameObject.SetActive(true);
        StarTimes.gameObject.SetActive(true);
        resetInfinte();
        Plane.transform.position = new Vector3(0, 0, 0);
        if (InfinteActive == true)
        {
            StarTimes.gameObject.SetActive(false);
        }
    }
    public void SetMapUI()
    {
        ResetUI();
        mapScreen.gameObject.SetActive(true);
    }
    public void ControlsUI()
    {
        ResetUI();
        ControlsScreen.gameObject.SetActive(true);
        controlsPlaneController.reset();
        Plane.transform.position = new Vector3(205, 0, 0);
    }
    public void Settings()
    {
        ResetUI();
        SettingsScreen.gameObject.SetActive(true);
    }
    public void Canyon()
    {
        timer.StartTimer();
        ResetGame();
        titleScreen.gameObject.SetActive(true);
        StarTimes.gameObject.SetActive(true);
        canyon.gameObject.SetActive(true);
        CanyonTimes.gameObject.SetActive(true);
        timer.CanyonActive();
    }
    public void Grass()
    {
        timer.StartTimer();
        ResetGame();
        titleScreen.gameObject.SetActive(true);
        StarTimes.gameObject.SetActive(true);
        grass.gameObject.SetActive(true);
        GrassTimes.gameObject.SetActive(true);
        timer.GrassActive();
    }
    public void Snow()
    {
        timer.StartTimer();
        ResetGame();
        titleScreen.gameObject.SetActive(true);
        StarTimes.gameObject.SetActive(true);
        snow.gameObject.SetActive(true);
        SnowTimes.gameObject.SetActive(true);

        timer.SnowActive();
    }
    public void Infinte()
    {
        timer.StartTimer();
        ResetGame();
        titleScreen.gameObject.SetActive(true);
        StarTimes.gameObject.SetActive(true);
        infinte.gameObject.SetActive(true);
        StarTimes.gameObject.SetActive(false);
        InfinteActive = true;
        InfinteScoreCounter.gameObject.SetActive(true);
        TimerCounter.gameObject.SetActive(false);
        resetInfinte();
    }


    public void crash()
    {
       
    }
    public void resetInfinte()
    {
        infintemap.resetm();
        infintemap2.resetm2();
    }
    public void ResetPlane()
    {
        Plane.transform.position = new Vector3(0, 0, 0);
    }
    public void ResetGame()
    {
        titleScreen.gameObject.SetActive(false);
        StarTimes.gameObject.SetActive(false);
        mapScreen.gameObject.SetActive(false);
        canyon.gameObject.SetActive(false);
        grass.gameObject.SetActive(false);
        snow.gameObject.SetActive(false);
        infinte.gameObject.SetActive(false);
        SnowTimes.gameObject.SetActive(false);
        CanyonTimes.gameObject.SetActive(false);
        GrassTimes.gameObject.SetActive(false);
        InfinteActive = false;
        Plane.transform.position = new Vector3(0, 0, 0);
        InfinteScoreCounter.gameObject.SetActive(false);
        TimerCounter.gameObject.SetActive(true);
    }
    public void ResetUI()
    {
        titleScreen.gameObject.SetActive(false);
        StarTimes.gameObject.SetActive(false);
        resetScreen.gameObject.SetActive(false);
        completeScreen.gameObject.SetActive(false);
        InGame.gameObject.SetActive(false);
        ControlsScreen.gameObject.SetActive(false);
        mapScreen.gameObject.SetActive(false);
        SettingsScreen.gameObject.SetActive(false);
    }
    public void FPSsetting()
    {
        if (IsFPSActive == false)
        {
            FPSDisplay.gameObject.SetActive(true);
            FPSTick.gameObject.SetActive(true);
            IsFPSActive = true;
        }
        else if (IsFPSActive == true)
        {
            FPSDisplay.gameObject.SetActive(false);
            FPSTick.gameObject.SetActive(false);
            IsFPSActive = false;
        }
    }
 

 

}
