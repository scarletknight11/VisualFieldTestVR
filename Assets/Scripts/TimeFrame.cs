using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeFrame : MonoBehaviour {

    public GameObject textDisplay;
    public double secondsLeft = 1.0;
    public bool takingAway = false;
    public TextController text;

    // Update is called once per frame
    void Update()
    {
        if (takingAway == false && secondsLeft > 0.0)
        {
            StartCoroutine(TimerTake());
        }
    }

    IEnumerator TimerTake()
    {
        takingAway = true;
        yield return new WaitForSeconds(3);
        secondsLeft -= 1.0;
        if (secondsLeft <= 0.0)
        {
            textDisplay.GetComponent<Text>().text = "00:" + secondsLeft;
            text.no();
            StartCoroutine(TurnOffText());
        }
        takingAway = false;
    }

    IEnumerator TurnOffText()
    {
        yield return new WaitForSeconds(3);
        textDisplay.SetActive(true);
        secondsLeft = 1.0;
    }

    public void TurnOnText()
    {
        textDisplay.SetActive(true);
        textDisplay.GetComponent<Text>().text = "00:" + secondsLeft;
    }

    public void resettime()
    {
        secondsLeft = 1.0;
        textDisplay.GetComponent<Text>().text = "00:" + secondsLeft;
        textDisplay.SetActive(true);
    }

    public void timesame()
    {
        secondsLeft = 0.0;
    }
}