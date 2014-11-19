using UnityEngine;
using System.Collections;

public class OpeningSequence : MonoBehaviour {

	private float DistanceX;
	private float DistanceZ;

	//Name this variable "ShowText" then drag the "ShowText" script into the variable through the inspector.
	public ShowText textDisplayingScript;

	void Update () {

		DistanceX = Mathf.Abs (transform.position.x) - Mathf.Abs (Movement2.GetPlayerX());
		DistanceZ = Mathf.Abs (transform.position.z) - Mathf.Abs (Movement2.GetPlayerZ());
		
		if (DistanceX <= 4 && DistanceZ <= 4 && DistanceX >= -4 && DistanceZ >= -4) {
						//Shows two lines of text at the bottom left of the screen (10 pixels from the left and 50 from the bottom).
						//The text lasts for 5 seconds before it disappears.
						textDisplayingScript.DisplayTextHereFor ("Not gonna feed the sharks today..", 10, 50, 3);
		}

	}
}
