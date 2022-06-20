using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

    public Light sceneLight;
    public Light sceneLight2;
    public Light sceneLight3;
    public Light sceneLight4;
    public Text contrast;
    public Text contrast2;
    public Text contrast3;
    public Text contrast4;
    public Text avgreversals;
    public Text message;
    public Text simulationover;
    public GameObject messaging;
    public GameObject sim;
    public GameObject button;
    public GameObject light;
    public float contrastlevel = 1.0f;
    public float contrastlevel2 = 1.0f;
    public float contrastlevel3 = 1.0f;
    public float contrastlevel4 = 1.0f;
    //public float[] contrastlevels = {1.0f, 1.0f, 1.0f, 1.0f};
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
    //public TextController text;
    double sec0;
    bool timerActive = false;
    float loop = 1f;

    void Start()
    {
        sceneLight.intensity = contrastlevel;
        currentTime = startimgTime;
        sec0 = 0.0;
        timerActive = true;
        StartCoroutine("MilliTimer");
    }

    // Update is called once per frame
    void Update()
    {
        //StartCoroutine(Count());
        prevcontrast = contrastlevel;
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

    //public void PickRandomFromList()
    //{
    //    int num = 1;
    //    int num2 = 2;
    //    int num3 = 3;
    //    int num4 = 4;
    //    string[] groups = new string[] { "Group " + num, "Group " + num2, "Group " + num3, "Group " + num4 };
    //    string randomgroups = groups[Random.Range(0, groups.Length)];
    //    largeText.text = randomgroups;

    //    if (randomgroups == "Group " + num)
    //    {
    //        GameObject.Find("ContrastText").SetActive(true);
    //        contrast.text = "Contrast Level: " + contrastlevel;
    //        GameObject.Find("ContrastText2").SetActive(false);
    //        GameObject.Find("ContrastText3").SetActive(false);
    //        GameObject.Find("ContrastText4").SetActive(false);
    //        Debug.Log("hi");
    //    }
    //    else if (randomgroups == "Group " + num2)
    //    {
    //        GameObject.Find("ContrastText").SetActive(false);
    //        GameObject.Find("ContrastText2").SetActive(true);
    //        contrast2.text = "Contrast Level: " + contrastlevel2;
    //        GameObject.Find("ContrastText3").SetActive(false);
    //        GameObject.Find("ContrastText4").SetActive(false);
    //        Debug.Log("hi 2");
    //    }
    //    else if (randomgroups == "Group " + num3)
    //    {
    //        GameObject.Find("ContrastText").SetActive(false);
    //        GameObject.Find("ContrastText2").SetActive(false);
    //        GameObject.Find("ContrastText3").SetActive(true);
    //        contrast3.text = "Contrast Level: " + contrastlevel3;
    //        GameObject.Find("ContrastText4").SetActive(false);
    //        Debug.Log("hi 3");
    //    }
    //    else if (randomgroups == "Group " + num4)
    //    {
    //        GameObject.Find("ContrastText").SetActive(false);
    //        GameObject.Find("ContrastText2").SetActive(false);
    //        GameObject.Find("ContrastText3").SetActive(false);
    //        GameObject.Find("ContrastText4").SetActive(true);
    //        contrast4.text = "Contrast Level: " + contrastlevel4;
    //        Debug.Log("hi 4");
    //    }
    //}

    //public void getcontrast1()
    //{
    //    GameObject.Find("ContrastText").SetActive(true);
    //    sceneLight.intensity = contrastlevel;
    //    contrast.text = "Contrast Level: " + contrastlevel;
    //    GameObject.Find("ContrastText2").SetActive(false);
    //    GameObject.Find("ContrastText3").SetActive(false);
    //    GameObject.Find("ContrastText4").SetActive(false);
    //}

    //public void getcontrast2()
    //{
    //    GameObject.Find("ContrastText").SetActive(false);
    //    sceneLight2.intensity = contrastlevel2;
    //    GameObject.Find("ContrastText2").SetActive(true);
    //    contrast2.text = "Contrast Level: " + contrastlevel2;
    //    GameObject.Find("ContrastText3").SetActive(false);
    //    GameObject.Find("ContrastText4").SetActive(false);
    //}

    //public void getcontrast3()
    //{
    //    GameObject.Find("ContrastText").SetActive(false);
    //    GameObject.Find("ContrastText2").SetActive(false);
    //    GameObject.Find("ContrastText3").SetActive(true);
    //    sceneLight3.intensity = contrastlevel3;
    //    contrast3.text = "Contrast Level: " + contrastlevel3;
    //    GameObject.Find("ContrastText4").SetActive(false);
    //}

    //public void getcontrast4()
    //{
    //    GameObject.Find("ContrastText").SetActive(false);
    //    GameObject.Find("ContrastText2").SetActive(false);
    //    GameObject.Find("ContrastText3").SetActive(false);
    //    GameObject.Find("ContrastText4").SetActive(true);
    //    sceneLight4.intensity = contrastlevel4;
    //    contrast4.text = "Contrast Level: " + contrastlevel4;
    //}

    IEnumerator MilliTimer()
    {
        bright.spawnobjects();
        if (timerActive == true)
        {
            while (true)
            {
                sec0 = sec0 + Time.fixedTimeAsDouble;
                TimeSpan time = TimeSpan.FromMilliseconds(sec0);
                if (time.Milliseconds >= 200f)
                {
                    sec0 = 0.0;
                    light.SetActive(false);
                    yield return new WaitForSeconds(1f);
                    StartCoroutine(Count());
                }
                yield return null;
            }
        }
    }

    IEnumerator Count()
    {
        currentTime -= 0.2f * Time.frameCount;
        yield return new WaitForSeconds(1f);

        if (currentTime <= 0.0f)
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