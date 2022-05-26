using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {
    
    public Light sceneLight;
    public Text contrast;
    public Text message;
    public Text simulationover;
    public GameObject messaging;
    public GameObject timer;
    public GameObject sim;
    public GameObject button;
    public GameObject light;
    public float contrastlevel = 1.0f;
    public TimeFrame time;
    public ComputeBrightness bright;

    void Start()
    {
        sceneLight.intensity = contrastlevel;
    }

    // Update is called once per frame
    void Update()
    { 
        contrast.text = "Contrast Level: " + contrastlevel;
        message.text = "Can you see? ";
        sceneLight.intensity = contrastlevel;
        Debug.Log("Contrast Level is: " + contrastlevel);
    }

    public void yes()
    {
        contrastlevel -= 0.05f;
        time.resettime();
        light.SetActive(true);
        bright.spawnobjects();

        if (contrastlevel <= 0)
        {
            contrastlevel = 0;
            time.timesame();
        }
    }

    public void no()
    {
        contrastlevel += 0.05f;
        time.resettime();
        bright.spawnobjects();
        if (contrastlevel > 1)
        {
            contrastlevel = 1;
            messaging.SetActive(false);
            timer.SetActive(false);
            sim.SetActive(true);
            button.SetActive(false);
            simulationover.text = "Visual Field Testing Over";
        }
    }
}
