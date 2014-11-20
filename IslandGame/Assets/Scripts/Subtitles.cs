using UnityEngine;
using System.Collections;

public class Subtitles : MonoBehaviour {

	//Name this variable "ShowText" then drag the "ShowText" script into the variable through the inspector.
	public ShowText textDisplayingScript;

	void OnTriggerEnter(Collision other){

		textDisplayingScript.DisplayTextHereFor ("WORKTZZZ", 10, 50, 5);


	}
}
