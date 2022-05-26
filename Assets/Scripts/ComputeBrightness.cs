using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputeBrightness : MonoBehaviour {
    
    public GameObject light;
    public Vector3 center;
    public Vector3 size;
    public TimeFrame timer;
    double sec;
    double sec0;

    // Start is called before the first frame update
    void Start()
    {
        light.SetActive(false);
        StartCoroutine("MilliTimer");
    }

     IEnumerator MilliTimer()
    {
        sec0 = Time.fixedTimeAsDouble;
        light.SetActive(true);
        while (true)
        {
            sec = Time.fixedTimeAsDouble;
            if (sec-sec0 >= 0.2)
            { 
                light.SetActive(false);
                timer.TurnOnText();
            }
            yield return null;
        }
    }
 
}