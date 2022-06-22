using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ClockDigital : MonoBehaviour {

    private Text textClock;
    public ComputeBrightness bright;
    public GameObject light;
    bool timerActive = false;
    

    void Awake()
    {
        textClock = GetComponent<Text>();
        timerActive = true;
    }

    // Update is called once per frame
    void Update()
    {

        //bright.spawnobjects();
        if (timerActive == true)
        {
                DateTime time = DateTime.Now;
                string hour = LeadingZero(time.Hour);
                string minute = LeadingZero(time.Minute);
                string second = LeadingZero(time.Second);
                string milliseconds = LeadingZero(time.Millisecond);

                //double milli = float.Parse(milliseconds);

                textClock.text = hour + ":" + minute + ":" + second + ":" + milliseconds;

                if (time.Millisecond >= 200)
                {
                    light.SetActive(false);
                    bright.spawnobjects();
                    Debug.Log("Hi");
                }
            }
    }

    string LeadingZero(int n)
    {
        return n.ToString().PadLeft(2, '0');
    }
}
