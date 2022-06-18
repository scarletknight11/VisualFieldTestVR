using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ComputeBrightness : MonoBehaviour {
    
    public GameObject light;
    public Vector3[] positions;
    public TextController text;
    //public TimeFrame timer;
    //double sec;
    double sec0;
    bool timerActive = false;
    float loop = 1f;
    public Text currentTimeText;

    // Start is called before the first frame update
    void Start()
    {
        sec0 = 0.0;
        timerActive = true;
        StartCoroutine("MilliTimer");
    }

    IEnumerator MilliTimer()
    {
        spawnobjects();
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
                    yield return new WaitForSeconds(1);
                }
                //currentTimeText.text = time.ToString(@"mm\:ss\:fff");
                yield return null;
            }
        }
     }

    public void spawnobjects()
    {
        light.SetActive(true);
        int randomNumber = UnityEngine.Random.Range(0, positions.Length);
        light.transform.position = positions[randomNumber];

        //if (positions[randomNumber] == positions[0])
        //{
        //    //Debug.Log(positions[0]);
        //    text.getcontrast1();
        //}
        //if (positions[randomNumber] == positions[1])
        //{
        //    //Debug.Log(positions[1]);
        //    text.getcontrast2();
        //}
        //if (positions[randomNumber] == positions[2])
        //{
        //    //Debug.Log(positions[2]);
        //    text.getcontrast3();
        //}
        //if (positions[randomNumber] == positions[3])
        //{
        //    //Debug.Log(positions[3]);
        //    text.getcontrast4();
        //}
    }

    public void PickRandomFromList()
    {
        int num = 1;
        int num2 = 2;
        int num3 = 3;
        int num4 = 4;
        string[] groups = new string[] { "Group " + num, "Group " + num2, "Group " + num3, "Group " + num4 };
        string randomgroups = groups[UnityEngine.Random.Range(0, groups.Length)];
        //largeText.text = randomgroups;

        if (randomgroups == "Group " + num)
        {
            GameObject.Find("ContrastText").SetActive(true);
            GameObject.Find("ContrastText2").SetActive(false);
            GameObject.Find("ContrastText3").SetActive(false);
            GameObject.Find("ContrastText4").SetActive(false);
        }
        else if (randomgroups == "Group " + num2)
        {
            GameObject.Find("ContrastText").SetActive(false);
            GameObject.Find("ContrastText2").SetActive(true);
            GameObject.Find("ContrastText3").SetActive(false);
            GameObject.Find("ContrastText4").SetActive(false);
        }
        else if (randomgroups == "Group " + num3)
        {
            GameObject.Find("ContrastText").SetActive(false);
            GameObject.Find("ContrastText2").SetActive(false);
            GameObject.Find("ContrastText3").SetActive(true);
            GameObject.Find("ContrastText4").SetActive(false);
        }
        else if (randomgroups == "Group " + num4)
        {
            GameObject.Find("ContrastText").SetActive(false);
            GameObject.Find("ContrastText2").SetActive(false);
            GameObject.Find("ContrastText3").SetActive(false);
            GameObject.Find("ContrastText4").SetActive(true);
        }
    }
}