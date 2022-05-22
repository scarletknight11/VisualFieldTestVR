using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputeBrightness : MonoBehaviour {
    
    public float time;
    public GameObject light;
    public TimeFrame timer;
    float sec;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("MilliTimer");
    }

     IEnumerator MilliTimer()
    {
        while (true)
        {
            time += Time.deltaTime;
            sec = (int)(time % 60);
            float ms = (int)(sec * 1000);
            if (ms >= 2000)
            { 
                light.SetActive(false);
                timer.TurnOnText();
            }
            yield return null;
        }
    }
}