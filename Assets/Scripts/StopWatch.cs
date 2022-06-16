using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class StopWatch : MonoBehaviour {

    bool timerActive = false;
    float currentTime;
    public Text currentTimeText;
    public Vector3[] positions;
    public GameObject gameobj;


    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;
        timerActive = true;
        gameobj.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        gameobj.SetActive(true);

        if (timerActive == true)
        {
            currentTime = currentTime + Time.fixedTime;
            TimeSpan time = TimeSpan.FromMilliseconds(currentTime);
           
            if (time.Milliseconds == 200f)
            {
                currentTime = 0;
                gameobj.SetActive(false);
                spawnobjects();
            }
            currentTimeText.text = time.ToString(@"mm\:ss\:fff");
        }
        //currentTimeText.text = time.Minutes.ToString() + ":" + time.Seconds.ToString() + ":"  + time.Milliseconds.ToString();
    }

    public void spawnobjects()
    {
        gameobj.SetActive(true);
        int randomNumber = UnityEngine.Random.Range(0, positions.Length);
        gameobj.transform.position = positions[randomNumber];
    }

        //IEnumerator MilliTimer()
        //{
        //    if (timerActive == true)
        //    {
        //        currentTime = currentTime + Time.fixedTime;
        //    }
        //    //int randomNumber = UnityEngine.Random.Range(0, positions.Length);
        //    //gameobj.transform.position = positions[randomNumber];

        //    TimeSpan time = TimeSpan.FromMilliseconds(currentTime);
        //    //FromSeconds
        //    //currentTimeText.text = time.Minutes.ToString() + ":" + time.Seconds.ToString() + ":"  + time.Milliseconds.ToString();
        //    if (time.Milliseconds == 200f)
        //    {
        //        currentTime = 0;
        //        gameobj.SetActive(false);
        //    }
        //    currentTimeText.text = time.ToString(@"mm\:ss\:fff");
        //    yield return new WaitForSeconds(1f);
        //}
        //public void StartTimer()
        //{
        //    timerActive = true;
        //}

        public void StopTimer()
    {
        timerActive = false;
    }
}
