using UnityEngine;
using System.Collections;

public class Subtitles : MonoBehaviour {

	private float DistanceX;
	private float DistanceZ;
	private bool displaying;	//When true, text is displayed each frame, when off it iss't displayed
	private bool SubTrigger = true;

	public string text;
	public int StartLine;
	public GUIStyle myStyle;	//This text style can can be easily changed in the inspector

	void Update () {
		DistanceX = Mathf.Abs (transform.position.x - Movement2.GetPlayerX ());
		DistanceZ = Mathf.Abs (transform.position.z - Movement2.GetPlayerZ ());
	
		if (DistanceX <= 4 && DistanceZ <= 4 && SubTrigger && !TestStart.GetStartSettings()) {
			SubTrigger = false;
			Invoke ("StartDisplaying", StartLine);
		}
	
	}

	//Draws the text on the GUI while "displaying" is true
	void OnGUI() {
		if (displaying) {
			GUI.Label(new Rect(Screen.width/2, Screen.height - 100, 0, 0), text, myStyle);
		}
		
	}

	void StartDisplaying () {
		displaying = true;
		Invoke ("StopDisplaying", 5);
	}

	//Simply says to stop displaying
	void StopDisplaying () {
		displaying = false;
	}

}

