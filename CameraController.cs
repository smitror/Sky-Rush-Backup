using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public GameObject plane;
    private Vector3 offset = new Vector3(0, 5, 20);
    private AudioSource CamAudio;
    public Text MusicVolText;
    public AudioClip CamSound;
    public Slider MusicVolSlider;
    
    public bool FOV1 = false;
    
    // Start is called before the first frame update
    void Start()
    {
        CamAudio = GetComponent<AudioSource>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (FOV1 == false)
        {
            Vector3 offset = new Vector3(0, 5, 20);
        }
        transform.position = plane.transform.position + offset;
        CamAudio.volume = MusicVolSlider.value;
        MusicVolText.text = (MusicVolSlider.value).ToString("F2");

        
        
    }

    public void Audio()
    {
        CamAudio.PlayOneShot(CamSound, 1.0f);
    }

    public void FOV1st()
    {
        FOV1 = true;
        Vector3 offset = new Vector3(0, 0, -5);
    }

}
