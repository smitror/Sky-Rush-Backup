using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinteMapTrigger2 : MonoBehaviour
{
    private InfinteMapTwo infintemap2;
    
    // Start is called before the first frame update
    void Start()
    {
      infintemap2 = GameObject.Find("Group 2").GetComponent<InfinteMapTwo>();
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    private void OnTriggerEnter(Collider other)
    {
      infintemap2.Zupdate2();
    }
    
}
