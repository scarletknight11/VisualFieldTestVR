using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeFrame : MonoBehaviour {

    public GameObject textDisplay;
    public int secondsLeft = 1;
    public bool takingAway = false;
    public TextController text;

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
        yield return new WaitForSeconds(3);
        secondsLeft -= 1;
        if (secondsLeft <= 0)
        {
            textDisplay.GetComponent<Text>().text = "00:" + secondsLeft;
            text.no();
            secondsLeft = 1;
        }
        else
        {
            textDisplay.GetComponent<Text>().text = "00:" + secondsLeft;
        }
        takingAway = false;
    }

    public void TurnOnText()
    {
        textDisplay.SetActive(true);
        textDisplay.GetComponent<Text>().text = "00:" + secondsLeft;
    }

    public void resettime()
    {
        secondsLeft = 1;
        textDisplay.GetComponent<Text>().text = "00:" + secondsLeft;
    }

    public void timesame()
    {
        secondsLeft = 0;
    }
}