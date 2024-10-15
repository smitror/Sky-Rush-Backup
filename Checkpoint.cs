using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject InvisWall;
    private AudioSource CheckpointAudio;
    public AudioClip CheckpointSound;
    private Timer timer;
    
    // Start is called before the first frame update
    void Start()
    {
        CheckpointAudio = GetComponent<AudioSource>();
        timer = GameObject.Find("Canvas").GetComponent<Timer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
      InvisWall.gameObject.SetActive(false); 
      StartCoroutine(InvisWallReset());
      CheckpointAudio.PlayOneShot(CheckpointSound, 1.0f);
       
    }
    IEnumerator InvisWallReset()
    {
        yield return new WaitForSeconds(2);
        InvisWall.gameObject.SetActive(true); 
    }
}
    

