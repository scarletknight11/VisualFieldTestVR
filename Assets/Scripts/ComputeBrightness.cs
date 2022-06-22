using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ComputeBrightness : MonoBehaviour {
    
    public GameObject light;
    public Vector3[] positions;
    public TextController text;
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
                yield return null;
            }
        }
     }

    public void spawnobjects()
    {
        light.SetActive(true);
        int randomNumber = UnityEngine.Random.Range(0, positions.Length);
        light.transform.position = positions[randomNumber];
    }
}