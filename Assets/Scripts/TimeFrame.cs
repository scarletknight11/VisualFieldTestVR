using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeFrame : MonoBehaviour {

    public GameObject textDisplay;
    public int secondsLeft = 30;
    public bool takingAway = false;
    public TextController text;

    void Start()
    {
        textDisplay.GetComponent<Text>().text = "00:" + secondsLeft;
    }

    // Update is called once per frame
    void Update()
    {
        if (takingAway == false && secondsLeft > 0)
        {
            StartCoroutine(TimerTake());
        }
    }

    IEnumerator TimerTake()
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        secondsLeft -= 1;
        if (secondsLeft <= 0)
        {
            textDisplay.GetComponent<Text>().text = "00:0" + secondsLeft;
            text.no();
            secondsLeft = 30;
        }
        else
        {
            textDisplay.GetComponent<Text>().text = "00:" + secondsLeft;
        }
        takingAway = false;
    }

    public void resettime()
    {
        secondsLeft = 30;
        textDisplay.GetComponent<Text>().text = "00:0" + secondsLeft;
    }
}