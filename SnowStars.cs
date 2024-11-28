using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowStars : MonoBehaviour
{
    public GameObject SnowStar1;
    public GameObject SnowStar2;
    public GameObject SnowStar3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void snowstar1()
    {
        SnowStar1.gameObject.SetActive(true);
    }
    public void snowstar2()
    {
        SnowStar2.gameObject.SetActive(true);
    }
    public void snowstar3()
    {
        SnowStar3.gameObject.SetActive(true);
    }
}
