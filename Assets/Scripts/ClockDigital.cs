using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ClockDigital : MonoBehaviour {

    private Text textClock;
    private ComputeBrightness bright;
    public GameObject light;

    void Awake()
    {
        textClock = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        DateTime time = DateTime.Now;
        string hour = LeadingZero(time.Hour);
        string minute = LeadingZero(time.Minute);
        string second = LeadingZero(time.Second);
        string milliseconds = LeadingZero(time.Millisecond);

        textClock.text = hour + ":" + minute + ":" + second + ":" + milliseconds;

        if (time.Millisecond >= 200)
        {
            Debug.Log("Hi");
        }
    }

    string LeadingZero(int n)
    {
        return n.ToString().PadLeft(2, '0');
    }
}
