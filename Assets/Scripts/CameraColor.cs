using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraColor : MonoBehaviour {

    public Camera cam;
    Color32 color;
    public float duration = 0.01f;

    void Start()
    {
        color.r = 0;
        color.g = 0;
        color.b = 0;

        cam = GetComponent<Camera>();
        cam.clearFlags = CameraClearFlags.SolidColor;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            float color1 = 0.01f;
            float color2 = 0.01f;
            float color3 = 0.01f;
            float colorred = color.r + color1;
            float colorgreen = color.g + color2;
            float colorblue = color.b + color3;
            //float t = Mathf.PingPong(Time.time, duration) / 256;
            float t2 = Mathf.PingPong(Time.time, colorred) / 256;
            float t3 = Mathf.PingPong(Time.time, colorgreen) / 256;
            float t4 = Mathf.PingPong(Time.time, colorblue) / 256;
            cam.backgroundColor = new Color(t2, t3, t4);
        }
    }

    public void ButtonClick()
    {
        float color1 = 0.01f;
        float color2 = 0.01f;
        float color3 = 0.01f;
        float colorred = color.r + color1;
        float colorgreen = color.g + color2;
        float colorblue = color.b + color3;
        float t = Mathf.PingPong(Time.time, duration) / duration;
        float t2 = Mathf.PingPong(Time.time, colorred) / colorred;
        float t3 = Mathf.PingPong(Time.time, colorgreen) / colorgreen;
        float t4 = Mathf.PingPong(Time.time, colorblue) / colorblue;
        cam.backgroundColor = new Color(t2, t3, t4, t);
    }


}
