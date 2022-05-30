using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


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
                yield return new WaitForSeconds(1);
            }
            yield return null;
        }
     }

    public void spawnobjects()
    {
        light.SetActive(true);
        int randomNumber = Random.Range(0, positions.Length);
        light.transform.position = positions[randomNumber];
    }

    //public void PickRandomFromList()
    //{
    //    //int num = Random.Range(1, 4);
    //    int num = 1;
    //    int num2 = 2;
    //    int num3 = 3;
    //    int num4 = 4;
    //    string[] students = new string[] { "Group " + num, "Group " + num2, "Group " + num3, "Group " + num4 };
    //    string randomName = students[Random.Range(0, students.Length)];
    //    largeText.text = randomName;
    //}
}