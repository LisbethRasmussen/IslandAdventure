using UnityEngine;
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
	private static bool[] TimerRanOut;		// An array there checks if a chocie was made during testing (used for the timer)
	private static bool[] WasChoiceMade;	// Checks if a certain choice have been made
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

	public static bool GetTimerRanOut(int index){
		return TimerRanOut[index];
	}

	public static bool GetWasChoiceMade(int index){
		return WasChoiceMade[index-1];
	}

	public static void SetChoiceNumber(int Num){
		ChoiceNumber = Num-1;
	}

	// Use this for initialization
	void Start () {
		Choice = new bool[6];			// Stores 6 bools in our choice array, these will be the answers for our test!
		TimerRanOut = new bool[6];	// Stores 6 bools in our was choice made? aray, this is need to get a "No answer" if people don't get to answer
		WasChoiceMade = new bool[6];
		for (int i = 0; i < 6; i++){
			TimerRanOut[i] = false;	// Sets every entry in the array to be true for now (so we don't have to code it below
			WasChoiceMade[i] = false;
		}
		timeBarBACK.enabled = false;	
		timeBarFRONT.enabled = false;
		timeBarBACK.pixelInset = new Rect (0-160, -180-20, 320, 40);
	}
	
	// Update is called once per frame
	void Update () {
		if (DecisionToBeMade == true){


			if (TestStart.GetTimeOn() == true){	// If a timer shall be set on the choice
				lengthOfBar -= 0.75f;			// This shall be changed to illustrate around 7 seconds of time
				timeBarBACK.enabled = true;
				timeBarFRONT.enabled = true;
				timeBarFRONT.pixelInset = new Rect (0-lengthOfBar/2, -180-10, lengthOfBar, 20);
				
				if (lengthOfBar <= 0.1f){	// If the timer runs out then:
					ChoiceNOTMade(ChoiceNumber);
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
			else if (ChoiceNumber == 3-1 || ChoiceNumber == 4-1 || ChoiceNumber == 6-1){	// For these choices shall the rational choice be the first the eye would see
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
		Choice[index] = result;		// Sets the result into the current index of the choice array
		DecisionToBeMade = false;	// A decision was made, so this should be set to false now
		WasChoiceMade [index] = true;	// Sets that a current choice have been made

		if (TestStart.GetTimeOn() == true)
			ResetTimer();						// If time was on shall the timer be reseted now
		if (index == 1-1){						// for choice 1 shall:
			GUIDialogue.SetChoiceIsMade(true);	// We return to the dialogue so this shall be set to true now
			GUIDialogue.NextDialogue();			// Makes us go to the next slide of dialogue
		}
		if (index == 6-1){						// After choice 6 shall:
			TestResultManager.SaveResult();		// Saves the test results!
		}
	}

	private void ChoiceNOTMade(int index){
		int RandomResult = Random.Range(0,2);	// Assings a random number between 0 and 1 to an int (have to set the max value to 2 otherwise will "1" never happen)
		if (RandomResult == 0)
			Choice[index] = true;		// if that number is 0 then will the choice be rational
		else if (RandomResult == 1)
			Choice[index] = false;		// if that number is 1 then will the choice be emotional
		DecisionToBeMade = false;		// A decision was "kinda" made, so this should be set to false now
		WasChoiceMade[index] = true;			// Sets that a current choice have been made
		TimerRanOut[index] = true;	// Sets the index of the Was choice made? variable to false, this is used for the results later

		if (TestStart.GetTimeOn() == true)
			ResetTimer();						// If time was on shall the timer be reseted now
		if (index == 1-1){						// for choice 1 shall:
			GUIDialogue.SetChoiceIsMade(true);	// We return to the dialogue so this shall be set to true now
			GUIDialogue.NextDialogue();			// Makes us go to the next slide of dialogue
		}
		if (index == 6-1){						// After choice 6 shall:
			TestResultManager.SaveResult();		// Saves the test results!
		}
	}

	private void ResetTimer(){
		timeBarBACK.enabled = false;	// Disables the timer GUI (also with the line below)
		timeBarFRONT.enabled = false;
		lengthOfBar = 300;				// Resets the length of the timer bar
	}
}
