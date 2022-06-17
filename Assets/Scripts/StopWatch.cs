using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class StopWatch : MonoBehaviour {

    bool timerActive = false;
    public double currentTime;
    public Text currentTimeText;
    public Vector3[] positions;
    public GameObject gameobj;


    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0.0;
        timerActive = true;
        //gameobj.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine("MilliTimer");
    }

    public void spawnobjects()
    {
        gameobj.SetActive(true);
        int randomNumber = UnityEngine.Random.Range(0, positions.Length);
        gameobj.transform.position = positions[randomNumber];
    }

    IEnumerator MilliTimer()
    {
        gameobj.SetActive(true);
        if (timerActive == true)
        {
            currentTime = currentTime + Time.fixedTimeAsDouble;
            TimeSpan time = TimeSpan.FromMilliseconds(currentTime);

            if (time.Milliseconds >= 200f)
            {
                currentTime = 0.0;
                gameobj.SetActive(false);
                yield return new WaitForSeconds(1);
                spawnobjects();
            }
            currentTimeText.text = time.ToString(@"mm\:ss\:fff");
            yield return null;
        }
    }
   
    //public void StartTimer()
    //{
    //    timerActive = true;
    //}

    //public void StopTimer()
    //{
    //    timerActive = false;
    //}
}
