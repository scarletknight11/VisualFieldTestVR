using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomGenerator : MonoBehaviour {

    public GameObject textBox;
    public int TheNumber;
    public int TheNumberTwo;


    public void RandomGenerate()
    {
        TheNumber = Random.Range(1, 10000);
        TheNumberTwo = Random.Range(1, 10);
        textBox.GetComponent<Text>().text = "Number: " + TheNumberTwo;
    }
}
