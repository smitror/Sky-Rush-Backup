using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinteMap : MonoBehaviour
{
    public float zvalue;
    // Start is called before the first frame update
    void Start()
    {
        zvalue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Zupdate()
    {
        zvalue = zvalue - 11880; 
        transform.position = new Vector3(0, 0, zvalue);
    }

    public void resetm()
    {
        zvalue = 0;
        transform.position = new Vector3(0, 0, zvalue);
        
    }
}
