﻿using UnityEngine;
using System.Collections;

public class Choices : MonoBehaviour {

	/*To start a choice shall 2 lines of code be used:
	 Choices.SetDecisionToBeMade(true); (Makes the program know that a choice shall be made)
	 Choices.SetChoiceNumber(1);		(Sets what choice shall be made! Notice that in the setter function does it take the input number -1, this is to not confuse when we use this code as it will just enter the right array entry in this code)

	 Also notice that if something in the Choice array is "true" then was it a RATIONAL choice,
	 and if it is "false" then was a "EMOTIONAL" choice picked
	 */

	public GUITexture timeBarBACK;			// GUI texture of the backside of our timer
	public GUITexture timeBarFRONT;			// GUI texture of the frontside of our timer

	private static bool DecisionToBeMade;	// A bool stating of we are currently making a choice or not
	private static bool[] Choice;			// An array of bools there contains all the answers from the choices (is used for change of dialogue and for the final test results)
	private static int ChoiceNumber = 0;	// A counter for what choice there shall be made.
	private string[] RationalChoice = {		// An array of strings there contain all the rational decisions
		"No. We should save them for later.",
		"Leave the photo",
		"Sleep in the cave, stay safe",
		"Leave the girl",
		"Leave the man to his fate",
		"Go for the boat"
	};
	private string[] EmotionalChoice = {	// An array of strings there contain all the emotional decisions
		"Yes, let's eat them now.",
		"Jump in to save the photo",
		"Go look for Carl",
		"Bury the girl",
		"Feed the man half of the supplies",
		"Go check on Carl"
	};
	private float lengthOfBar = 300;		// How long the timer bar is

	public static bool GetDecisionToBeMade(){
		return DecisionToBeMade;
	}
	public static void SetDecisionToBeMade(bool x){
		DecisionToBeMade = x;
	}

	public static bool GetChoice(int index){
		return Choice[index-1];	// -1 as an array starts with 0 and it is not to confuse people when we look back at the code
	}

	public static void SetChoiceNumber(int Num){
		ChoiceNumber = Num-1;
	}

	// Use this for initialization
	void Start () {
		Choice = new bool[6];			// Stores 6 bools in our choice array, these will be the answers for our test!
		timeBarBACK.enabled = false;	
		timeBarFRONT.enabled = false;
		timeBarBACK.pixelInset = new Rect (0-160, -180-20, 320, 40);
	}
	
	// Update is called once per frame
	void Update () {
		if (DecisionToBeMade == true){


			if (TestStart.GetTimeOn() == true){	// If a timer shall be set on the choice
				lengthOfBar -= 1.1f;			// This shall be changed to illustrate around 7 seconds of time
				timeBarBACK.enabled = true;
				timeBarFRONT.enabled = true;
				timeBarFRONT.pixelInset = new Rect (0-lengthOfBar/2, -180-10, lengthOfBar, 20);
				
				if (lengthOfBar <= 0.1f){
					ResetTimer();
				}
			}
		}
	}

	void OnGUI(){
		/* The order of the choices!
		 1. E	R
		 2. E	R
		 3. R	E
		 4. R	E 
		 5. E	R
		 6. R	E
		 */ 
		if (DecisionToBeMade == true){
			// Probably add the blurry effect at this line!
			if (ChoiceNumber == 1-1 || ChoiceNumber == 2-1 || ChoiceNumber == 5-1){	// For these choices shall the emotional choice be the first the eye would see
				if (GUI.Button (new Rect(Screen.width/2-225, Screen.height/2+100, 220, 50), EmotionalChoice[ChoiceNumber])){
					ChoiceMade(ChoiceNumber, false);
				}
				else if (GUI.Button (new Rect(Screen.width/2+5, Screen.height/2+100, 220, 50), RationalChoice[ChoiceNumber])){
					ChoiceMade(ChoiceNumber, true);
				}
			}
			if (ChoiceNumber == 3-1 || ChoiceNumber == 4-1 || ChoiceNumber == 6-1){	// For these choices shall the rational choice be the first the eye would see
				if (GUI.Button (new Rect(Screen.width/2-225, Screen.height/2+100, 220, 50), RationalChoice[ChoiceNumber])){
					ChoiceMade(ChoiceNumber, true);
				}
				else if (GUI.Button (new Rect(Screen.width/2+5, Screen.height/2+100, 220, 50), EmotionalChoice[ChoiceNumber])){
					ChoiceMade(ChoiceNumber, false);
				}
			}
		}
	}

	private void ChoiceMade(int index, bool result){
		Choice[index] = result;
		DecisionToBeMade = false;
		GUIDialogue.SetChoiceIsMade(true);
		if (TestStart.GetTimeOn() == true)
			ResetTimer();
		if (index == 1-1)
			GUIDialogue.NextDialogue();
	}

	private void ResetTimer(){
		timeBarBACK.enabled = false;
		timeBarFRONT.enabled = false;
		lengthOfBar = 300;
		DecisionToBeMade = false;
	}
}