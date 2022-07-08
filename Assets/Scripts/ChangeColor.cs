using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour {
    
    public Color colorChange;

    void OnMouseEnter()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = colorChange;
        Debug.Log("Mouse is over GameObject.");
    }

    void OnMouseExit()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
        Debug.Log("Mouse is no longer on GameObject.");
    }
}
