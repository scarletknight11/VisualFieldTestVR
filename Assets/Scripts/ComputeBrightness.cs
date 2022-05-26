using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputeBrightness : MonoBehaviour {
    
    public GameObject light;
    public Vector3[] positions;
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
        int randomNumber = Random.Range(0, positions.Length);
        light.transform.position = positions[randomNumber];

        while (true)
        {
            sec = Time.fixedTimeAsDouble;
            if (sec - sec0 >= 0.2)
            { 
                light.SetActive(false);
                timer.TurnOnText();
                yield return new WaitForSeconds(3);
            }
            yield return null;
        }
    }

    public void spawnobjects()
    {
        int randomNumber = Random.Range(0, positions.Length);
        light.transform.position = positions[randomNumber];
    }

}