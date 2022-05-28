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
    public GameObject sim;
    public GameObject button;
    public GameObject light;
    public float contrastlevel = 1.0f;
    public float clickyes;
    public float seconds = 0f;
    public ComputeBrightness bright;

    void Start()
    {
        sceneLight.intensity = contrastlevel;
        StartCoroutine(time());
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
        //seconds = 0;
        bright.spawnobjects();

        if (contrastlevel <= 0)
        {
            contrastlevel = 0;
        }
    }

    public void no()
    {
        contrastlevel += 0.05f;
        seconds = 1;
        bright.spawnobjects();
        if (contrastlevel > 1)
        {
            contrastlevel = 1;
            Debug.Log("Contrast went above 1");
        }
    }

    IEnumerator time()
    {
        while (true)
        {
            timeCount();
            yield return new WaitForSeconds(1);
        }
    }
    void timeCount()
    {
        seconds += 1;
        if (seconds == 1)
        {
            no();
        } 
    }
}
