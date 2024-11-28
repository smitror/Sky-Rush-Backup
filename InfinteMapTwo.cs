using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinteMapTwo : MonoBehaviour
{
    public float zvalue2;
    // Start is called before the first frame update
    void Start()
    {
        zvalue2 = -5920;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Zupdate2()
    {
        zvalue2 = zvalue2 - 11880; 
        transform.position = new Vector3(0, 0, zvalue2);
    }
    public void resetm2()
    {
        zvalue2 = -5920;
        transform.position = new Vector3(0, 0, zvalue2);
    }
    
}
