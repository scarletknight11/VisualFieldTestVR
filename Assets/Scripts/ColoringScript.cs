using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColoringScript : MonoBehaviour {

    public Text mytext;
    public Camera cam;
    Color32 color;

    // Start is called before the first frame update
    void Start()
    {
        color.r = 0;
        color.g = 0;
        color.b = 0;
        color.a = 0;
        mytext.text = "R " + color.r + "G " + color.g + "B " + color.b + "A " + color.a;

        cam = GetComponent<Camera>();
        cam.clearFlags = CameraClearFlags.SolidColor;
        cam.backgroundColor = new Color32(color.r, color.g, color.b, color.a);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            color.r += 1;
            color.g += 1;
            color.b += 1;
            color.a += 1;
            mytext.text = "R " + color.r + "G " + color.g + "B " + color.b + "A " + color.a;

            cam.backgroundColor = new Color32(color.r, color.g, color.b, color.a);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            color.r -= 1;
            color.g -= 1;
            color.b -= 1;
            color.a -= 1;
            mytext.text = "R " + color.r + "G " + color.g + "B " + color.b + "A " + color.a;

            cam.backgroundColor = new Color32(color.r, color.g, color.b, color.a);
        }
    }
}
