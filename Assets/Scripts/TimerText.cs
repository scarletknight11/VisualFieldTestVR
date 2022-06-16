using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerText : MonoBehaviour
{

    public Text timer;
   
    public float currentTime = 0.0f;
    float startimgTime = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        currentTime = startimgTime;
    }

    void Update()
    {
        StartCoroutine("MilliTimer");
    }

    IEnumerator MilliTimer()
    {
        currentTime -= 0.2f * Time.fixedDeltaTime;
        timer.text = currentTime.ToString("0");
        yield return new WaitForSeconds(1f);
    }

}
