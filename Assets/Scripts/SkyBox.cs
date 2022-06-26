using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBox : MonoBehaviour {

    public Material skyOne;
    //[SerializeField]
    //private Color background = Color.black;


    // Start is called before the first frame update
    void Start()
    {
        Color newColor = new Color(0.3f, 0.4f, 0.6f, 0.3f);

        //RenderSettings.skybox = skyOne;
        RenderSettings.ambientSkyColor = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        //Color color = skyOne.material.color;
    }
}
