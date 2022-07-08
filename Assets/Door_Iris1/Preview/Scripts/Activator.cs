using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 	 Activator is a simple script to allow the player to throw switches for the preview scene. If they press
 *  E then it casts a ray and sends a ToggleDoor message to whatever it hit.
 * 
 *   The code that actually makes the door move is in the DoorSwitch script.
 */

public class Activator : MonoBehaviour {

	public GameObject FPSCamera; // the player's camera object

	void Update () {
		RaycastHit hit;

		if (Input.GetKeyDown(KeyCode.E))
		{
			// use target object
			if (Physics.Raycast(FPSCamera.transform.position, FPSCamera.transform.forward, out hit, 2.0f))
			{
				hit.collider.gameObject.SendMessage("ToggleDoor", null, SendMessageOptions.DontRequireReceiver);
			}
		}
	}
}
