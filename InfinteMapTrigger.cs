using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinteMapTrigger : MonoBehaviour
{
    private InfinteMap infintemap;
    
    // Start is called before the first frame update
    void Start()
    {
      infintemap = GameObject.Find("Group 1").GetComponent<InfinteMap>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    private void OnTriggerEnter(Collider other)
    {
      infintemap.Zupdate();
    }
    
}
