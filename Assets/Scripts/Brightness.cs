using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Brightness : MonoBehaviour {

    public Slider slider;
    public Light sceneLight;
    public float contrastlevel = 0.5f;
    public GameObject light;

    void Start()
    {
        slider.value = contrastlevel;
        sceneLight.intensity = slider.value;
    }

    void Update()
    {
        //Change intensity of light to whatever slider value is
        sceneLight.intensity = slider.value;
    }
}
