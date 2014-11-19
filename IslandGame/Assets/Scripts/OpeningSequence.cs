using UnityEngine;
using System.Collections;

public class OpeningSequence : MonoBehaviour {

	//Name this variable "ShowText" then drag the "ShowText" script into the variable through the inspector.
	public ShowText textDisplayingScript;

	void Start () {
		//Shows two lines of text at the bottom left of the screen (10 pixels from the left and 50 from the bottom).
		//The text lasts for 5 seconds before it disappears.
		textDisplayingScript.DisplayTextHereFor ("There is enough room for the food in my back. \n" +
		                                         "I will put it there.", 10,  50,  5);

		//Subtitles can be added with triggers/timers and/or if statements
	}
}
