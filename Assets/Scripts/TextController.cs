using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

    public Light sceneLight;
    public Text contrast;
    public Text message;
    public float contrastlevel = 1.0f;

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
        if (contrastlevel <= 0)
        {
            contrastlevel = 0;
        }
    }

    public void no()
    {
        contrastlevel += 0.05f;

        if(contrastlevel >= 1)
        {
            contrastlevel = 1;
        }
    }


}
