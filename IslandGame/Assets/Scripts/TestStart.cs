using UnityEngine;
using System.Collections;

public class TestStart : MonoBehaviour {

	public GameObject DialogObj01;	// This script is not needed to contain these variables,
	public GameObject DialogObj02;	// these variables shall be made for the script there shall contain ALL dialogue (just need a total of 20 of them!)

	private static string TestNumber = "";		// The string there shall contain the number of the test participnt
	private static bool startSettings = true;	// When this is true then should nothing from the game work
	private static bool TimeOn;					// The bool there decides if we test with timer or not

	public static string GetTestNumber(){
		return TestNumber;
	}

	public static bool GetStartSettings(){
		return startSettings;
	}

	public static bool GetTimeOn(){
		return TimeOn;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnGUI(){
		if(startSettings == true){
			TestNumber = GUI.TextField(new Rect(Screen.width/2-100, Screen.height/2-125, 100, 20), TestNumber, 3);	// Sets the test number to be whatever is input in that text feild (max 3 symbols)
			TimeOn = GUI.Toggle (new Rect(Screen.width/2+10, Screen.height/2-125, 100, 25), TimeOn, "Time?");		// A toggle to set if we want a timer on this test or not (White dot in the box means "TRUE")
			if(GUI.Button (new Rect(Screen.width/2-100, Screen.height/2-100, 200, 200), "Enter a test number!\n\nClick to start test!")){	// Makes a button to click on!
				startSettings = false;	// Sets the settings to false and the game can then start!
				DialogObj01.SetActive(true);		// (Dialogue) Activates the (empty) object containing a dialogue script
				GUIDialogue.SetDialogueON(true);	// (Dialogue) Sets a bool inside the dialogue script to be true which will show dialogue
				//Choices.SetDecisionToBeMade(true);// (Choice) Makes the program know that a choice shall be made
				//Choices.SetChoiceNumber(6);		// (Choice) Sets what choice shall be made
			}
		}
	}
}
