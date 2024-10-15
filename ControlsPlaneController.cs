using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsPlaneController : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        // Get Players Rigidbody.
        
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate (0,1,0*Time.deltaTime);
    }
    
    public void reset()
    {
        transform.rotation = Quaternion.identity;
    }
}
