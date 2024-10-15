using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    bool timerActive = false;
    public bool Snowmap = true;
    public bool Canyonmap = false;
    public bool Grassmap = false;
    float currentTime;
    public Text currentTimeText;
    public Text FinishTimeText;
    public Text StarNum;
    public GameObject Star1;
    public GameObject Star2;
    public GameObject Star3;
    private SnowStars snowstars;
    private CanyonStars canyonstars;
    private GrassStars grassstars;
    public float Snowstarcount;
    public float Canyonstarcount;
    public float Grassstarcount;
    public float Starcount;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;
        Starcount = 0;
        snowstars = GameObject.Find("Canvas").GetComponent<SnowStars>();
        canyonstars = GameObject.Find("Canvas").GetComponent<CanyonStars>();
        grassstars = GameObject.Find("Canvas").GetComponent<GrassStars>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timerActive == true)
        {
            currentTime = currentTime + Time.deltaTime;
        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        if (currentTime < 60)
        {
        currentTimeText.text = time.ToString(@"ss\:ff");
        FinishTimeText.text = time.ToString(@"ss\:ff");
        }
        else if (currentTime > 60)
        {
        currentTimeText.text = time.ToString(@"mm\:ss\:ff");
        FinishTimeText.text = time.ToString(@"mm\:ss\:ff");
        }

        Starcount = (Snowstarcount + Grassstarcount + Canyonstarcount);
        StarNum.text = (Starcount).ToString("F0");


        if ((timerActive == false) && (Snowmap == true) && (currentTime <= 60) && (currentTime >= 5))
        {
            Starone();
            snowstars.snowstar1();
            if (Snowstarcount <= 1)
            {
                Snowstarcount = 1;
            }
        }
        if ((timerActive == false) && (Snowmap == true) && (currentTime <= 38) && (currentTime >= 5))
        {
            Startwo();
            snowstars.snowstar2();
            if (Snowstarcount <= 2)
            {
                Snowstarcount = 2;
            }
        }
        if ((timerActive == false) && (Snowmap == true) && (currentTime <= 28) && (currentTime >= 5))
        {
            Starthree();
            snowstars.snowstar3();
            if (Snowstarcount <= 3)
            {
                Snowstarcount = 3;
            }
        }



        if ((timerActive == false) && (Canyonmap == true) && (currentTime <= 60) && (currentTime >= 5))
        {
            Starone();
            canyonstars.canyonstar1();
            if (Canyonstarcount <= 1)
            {
                Canyonstarcount = 1;
            }
        }
        if ((timerActive == false) && (Canyonmap == true) && (currentTime <= 25) && (currentTime >= 5))
        {
            Startwo();
            canyonstars.canyonstar2();
            if (Canyonstarcount <= 2)
            {
                Canyonstarcount = 2;
            }
        }
        if ((timerActive == false) && (Canyonmap == true) && (currentTime <= 22) && (currentTime >= 5))
        {
            Starthree();
            canyonstars.canyonstar3();
            if (Canyonstarcount <= 3)
            {
                Canyonstarcount = 3;
            }
        }


        if ((timerActive == false) && (Grassmap == true) && (currentTime <= 60) && (currentTime >= 5))
        {
            Starone();
            grassstars.grassstar1();
            if (Grassstarcount <= 1)
            {
                Grassstarcount = 1;
            }
        }
        if ((timerActive == false) && (Grassmap == true) && (currentTime <= 25) && (currentTime >= 5))
        {
            Startwo();
            grassstars.grassstar2();
            if (Grassstarcount <= 2)
            {
                Grassstarcount = 2;
            }
        }
        if ((timerActive == false) && (Grassmap == true) && (currentTime <= 20) && (currentTime >= 5))
        {
            Starthree();
            grassstars.grassstar3();
            if (Grassstarcount <= 3)
            {
                Grassstarcount = 3;
            }
        }
    }

    public void StartTimer()
    {
        timerActive = true;
        Start();
    }
    public void StopTimer()
    {
        timerActive = false;
    }
    public void SnowActive()
    {
        Snowmap = true;
        Canyonmap = false;
        Grassmap = false;
    }
    public void CanyonActive()
    {
        Snowmap = false;
        Canyonmap = true;
        Grassmap = false;
    }
    public void GrassActive()
    {
        Snowmap = false;
        Canyonmap = false;
        Grassmap = true;
    }
    public void Starone()
    {
        Star1.gameObject.SetActive(true);
    }
    public void Startwo()
    {
        Star1.gameObject.SetActive(true);
        Star2.gameObject.SetActive(true);
    }
    public void Starthree()
    {
        Star1.gameObject.SetActive(true);
        Star2.gameObject.SetActive(true);
        Star3.gameObject.SetActive(true);
    }
}
