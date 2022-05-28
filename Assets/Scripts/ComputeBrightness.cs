using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputeBrightness : MonoBehaviour {
    
    public GameObject light;
    public Vector3[] positions;
    //public TimeFrame timer;
    double sec;
    double sec0;
    float loop = 1f;
    public TextController text;

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
        //text.clickyes = 0f;
        while (true)
        {
            sec = Time.fixedTimeAsDouble;
            if (sec - sec0 >= 0.2)
            { 
                light.SetActive(false);
                yield return new WaitForSeconds(1);
               
            }
            //if (sec - sec0 >= 1.2)
            //{
            //    yield return new WaitForSeconds(1);
            //    text.no();
            //}
            yield return null;
     
        }
        
    }

    public void spawnobjects()
    {
        light.SetActive(true);
        int randomNumber = Random.Range(0, positions.Length);
        light.transform.position = positions[randomNumber];
    }
}