using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanyonStars : MonoBehaviour
{
    public GameObject CanyonStar1;
    public GameObject CanyonStar2;
    public GameObject CanyonStar3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void canyonstar1()
    {
        CanyonStar1.gameObject.SetActive(true);
    }
    public void canyonstar2()
    {
        CanyonStar2.gameObject.SetActive(true);
    }
    public void canyonstar3()
    {
        CanyonStar3.gameObject.SetActive(true);
    }
}
