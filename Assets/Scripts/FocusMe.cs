using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FocusMe : MonoBehaviour
{
    [SerializeField] private FocusSwitcher focus;

    private void OnMouseEnter()
    {
        focus.SetFocused(gameObject);
    }

    private void OnMouseExit()
    {
        // reset the focus
        // in the future you should maybe check first
        // if this object is actually the focused one currently
        focus.SetFocused(null);
    }
}