using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusSwitcher : MonoBehaviour {

    public string FocusedLayer = "Focused";

    private GameObject currentlyFocused;
    private int previousLayer;

    public void SetFocused(GameObject obj) 
    {
        //enables camera & post processing volume which is the child of main camera
        gameObject.SetActive(true);

        //if something else was focused before reset it
        if (currentlyFocused) currentlyFocused.layer = previousLayer;

        // store & focus the new object
        currentlyFocused = obj;

        if (currentlyFocused)
        {
            previousLayer = currentlyFocused.layer;
            currentlyFocused.layer = LayerMask.NameToLayer(FocusedLayer);
        }
        else
        {
            // if no object is focused disable the FocusCamera
            // and PostProcessingVolume for not wasting rendering resources
            gameObject.SetActive(false);
        }
    }

    //disable & reset current object
    private void OnDisable()
    {
        if (currentlyFocused) currentlyFocused.layer = previousLayer;

        currentlyFocused = null;
    }

}
