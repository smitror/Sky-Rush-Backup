using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassStars : MonoBehaviour
{
    public GameObject GrassStar1;
    public GameObject GrassStar2;
    public GameObject GrassStar3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void grassstar1()
    {
        GrassStar1.gameObject.SetActive(true);
    }
    public void grassstar2()
    {
        GrassStar2.gameObject.SetActive(true);
    }
    public void grassstar3()
    {
        GrassStar3.gameObject.SetActive(true);
    }
}
