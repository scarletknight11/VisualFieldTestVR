using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

    public Light sceneLight;
    public Text contrast;
    public Text avgreversals;
    public Text message;
    public Text simulationover;
    public GameObject messaging;
    public GameObject sim;
    public GameObject button;
    public GameObject light;
    public float contrastlevel = 1.0f;
    public float reversalcount = 0.0f;
    public float prevcontrast;
    float storefirstcount;
    float secondfirstcount;
    float thirdfirstcount;
    public ComputeBrightness bright;
    public Text largeText;
    public double currentTime = 0.0;
    float startimgTime = 1f;
    public float clicked;
    public string lastresponse = "yes";
    public string newresponse;

    [SerializeField] Text countdownText;
    [SerializeField] Text reversaltext;

    public Vector3[] positions;
    //double sec0;
    bool timerActive = false;
    float loop = 1f;

    public Text textClock;

    void Start()
    {
        sceneLight.intensity = contrastlevel;
        currentTime = startimgTime;
        timerActive = true;
        StartCoroutine("MilliTimer");
    }

    void FixedUpdate()
    {
        prevcontrast = contrastlevel;
        StartCoroutine(Count());
        contrast.text = "Contrast Level: " + contrastlevel;
        message.text = "Can you see? ";
        sceneLight.intensity = contrastlevel;
    }

    public void yes()
    {
        contrastlevel -= 0.05f;
        clicked = 1;
        newresponse = "yes";
        if (contrastlevel <= 0)
        {
            contrastlevel = 0;
        }
    }

    public void no()
    {
        contrastlevel += 0.05f;
        newresponse = "no";

        if (contrastlevel > 1)
        {
            contrastlevel = 1;
        } 
    }

    IEnumerator MilliTimer()
    {
        bright.spawnobjects();
        if (timerActive == true)
        {
            while (true)
            {
                DateTime time2 = DateTime.Now;
                string hour = LeadingZero(time2.Hour);
                string minute = LeadingZero(time2.Minute);
                string second = LeadingZero(time2.Second);
                string milliseconds = LeadingZero(time2.Millisecond);

                textClock.text = hour + ":" + minute + ":" + second + ":" + milliseconds;

                if (time2.Millisecond >= 200f)
                {
                    Debug.Log("milli " + time2.Millisecond);
                    light.SetActive(false);
                    StartCoroutine(Count());
                }
                yield return new WaitForSeconds(0.1f);
            }
        }
    }

    string LeadingZero(int n)
    {
        return n.ToString().PadLeft(2, '0');
    }

    IEnumerator Count()
    {

        if (currentTime > 0f)
        {
            currentTime -= 0.1f * Time.deltaTime;
            yield return new WaitForSeconds(0.01f);
        }

        if (currentTime <= 0f)
        {
            currentTime = 1f;
            bright.spawnobjects();
            clicked = 0;
        }
        else if (clicked == 0 && currentTime <= 0.005167351f)
        {
            no();
            currentTime = 1;
            bright.spawnobjects();
        }

        if (newresponse == "yes" || newresponse == "no")
        {
            if (newresponse != lastresponse)
            {
                reversalcount += 1;
                lastresponse = newresponse;
                reversaltext.text = "Reversal Count " + reversalcount;

                if (reversalcount == 1)
                {
                    storefirstcount = prevcontrast;
                    Debug.Log("first " + prevcontrast);
                }
                if (reversalcount == 2)
                {
                    secondfirstcount = prevcontrast;
                    Debug.Log("second " + prevcontrast);
                }
                if (reversalcount == 3)
                {
                    thirdfirstcount = prevcontrast;
                    Debug.Log("third " + prevcontrast);
                    float avg = (storefirstcount + secondfirstcount + thirdfirstcount) / 3;
                    GameObject.Find("Reversalstext").SetActive(false);
                    GameObject.Find("TextController").SetActive(false);
                    GameObject.Find("Light").SetActive(false);
                    Debug.Log("avg " + avg);
                    avgreversals.text = "Contrast Threshold: " + avg;
                }
            }
        }
    }
}