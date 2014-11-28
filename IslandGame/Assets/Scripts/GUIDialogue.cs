using UnityEngine;
using System.Collections;

public class GUIDialogue : MonoBehaviour {

	//new stuff--------------
	private static bool DrinkCarl = false;
	private static bool GetDrinkCarl(){return DrinkCarl;}

	private static bool Conversation15Done = false;
	public static bool GetConversation15Done(){return Conversation15Done;}

	private static bool Conversation16Done = false;
	public static bool GetConversation16Done(){return Conversation16Done;}

	//---------------------

	/*To start a dialogue is there 2 lines of code be used:
	 But first make a public GameObject object in the script there shall activate the dialogue (like "DialogueObj01") This empty GameObject shall be deactivated from the start!
	 GUIDialogue.SetDialogueON(true);	(Makes the program know that a dialogue shall play now)
	 Dialogue1.SetActive(true); 		(This activates the deactivated object there holds the script)
	 */

	public int NumberOfDialogue;// This is necessary for dialogue number 2, 4, 5, 8, 13 and 14, the rest really dosn't need this input 
	public int totalNumOfDia;	// The total number of dialogue boxes there shall be in this dialogue scene. IF THIS IS NOT INPUTED FROM OUTSIDE THE SCRIPT THEN WILL IT CRASH!!!
	public Texture DiaBox01;
	public Texture DiaBox02;
	public Texture DiaBox03;
	public Texture DiaBox04;
	public Texture DiaBox05;
	public Texture DiaBox06;
	public Texture DiaBox07;
	public Texture DiaBox08;
	public Texture DiaBox09;
	public Texture DiaBox10;
	public Texture DiaBox11;
	public Texture DiaBox12;
	public Texture DiaBox13;
	public Texture DiaBox14;
	public Texture DiaBox15;	// 15 lines of dialogue is the longest there is, not all shall be filled to get the script to work!

	private Texture[] Dialogue;	// The array there will store all the dialogue textures
	private static bool DialogueON = false;
	private static int currentDialogue = 0;
	private int lastDialogue = 16;		//Have to set it to a high number otherwise will it just close the dialogue right away
	private static bool ChoiceIsMade = false;

	public static bool GetDialogueON(){		// This getter will be used in our main code to tell that nothing else shall be moving while DialogueON is true
		return DialogueON;
	}
	public static void SetDialogueON(bool x){
		DialogueON = x;
	}

	public static void SetChoiceIsMade(bool x){
		ChoiceIsMade = x;
	}



	// Use this for initialization
	void Start () {
		Dialogue = new Texture[totalNumOfDia];	// Applies only the needed amount of textures into the Dialogue array
		if(totalNumOfDia >= 1)		// This could sadly not be done in any other way...
			Dialogue[0] = DiaBox01;	// Because we can't assign anything to Dialogue[14] when we have less than that number
		if(totalNumOfDia >= 2)		// assigned to the array. So this awful looking code have to be there.
			Dialogue[1] = DiaBox02;	// It works perfectly... it just looks... awful.
		if(totalNumOfDia >= 3)		// Also tried to use a switch but that didn't work as we learned how it works so... yeah...
			Dialogue[2] = DiaBox03;
		if(totalNumOfDia >= 4)
			Dialogue[3] = DiaBox04;
		if(totalNumOfDia >= 5)
			Dialogue[4] = DiaBox05;
		if(totalNumOfDia >= 6)
			Dialogue[5] = DiaBox06;
		if(totalNumOfDia >= 7)
			Dialogue[6] = DiaBox07;
		if(totalNumOfDia >= 8)
			Dialogue[7] = DiaBox08;
		if(totalNumOfDia >= 9)
			Dialogue[8] = DiaBox09;
		if(totalNumOfDia >= 10)
			Dialogue[9] = DiaBox10;
		if(totalNumOfDia >= 11)
			Dialogue[10] = DiaBox11;
		if(totalNumOfDia >= 12)
			Dialogue[11] = DiaBox12;
		if(totalNumOfDia >= 13)
			Dialogue[12] = DiaBox13;
		if(totalNumOfDia >= 14)
			Dialogue[13] = DiaBox14;
		if(totalNumOfDia >= 15)
			Dialogue[14] = DiaBox15;
	
	}

	
	// Update is called once per frame
	void Update () {
		//print ("WeSaveCarl (True) = "+LetUsGoInvisible.GetWeSaveCarl ()+", HaveSavedCarl (False) = "+LetUsGoInvisible.GetWeHaveSavedCarl ());
		if (currentDialogue > totalNumOfDia-1 || currentDialogue > lastDialogue-1){	// -1 as the entries in an array starts at 0
			DialogueON = false;
			lastDialogue = 16; 		// Just to make sure that no bugs happen!
			currentDialogue = 0;	// To reset the variable, no clue if it will change on all "GUIDialogue" scripts)
			if (NumberOfDialogue == 1){
				Movement2.SetAnimationOn(true);
			}
			if (NumberOfDialogue == 2){
				Movement2.SetMiniGameOn(true);
				Movement2.SetGoNormal(true);
				Movement2.SetAnimationOn(false);
				Movement2.SetDoNotMove(false);
			}
			if (NumberOfDialogue == 3 && Choices.GetChoice(1) == false){
				Movement2.SetGoFaster(true);
				Movement2.SetFoodCount(0);
			}
			if (NumberOfDialogue == 3 && Choices.GetChoice(1) == true){
				Movement2.SetGoNormal(true);
			}
			if (NumberOfDialogue == 4 && Choices.GetChoice(1) == true){
				Movement2.SetGoNormal(true);
				BackPack2.SetHaveBackpack(true);
			}
			if (NumberOfDialogue == 4 && Choices.GetChoice(1) == false){
				Movement2.SetGoFaster(true);
				BackPack2.SetHaveBackpack(true);
			}
			if (NumberOfDialogue == 5 && Choices.GetChoice(1) == true){
				Movement2.SetGoNormal(true);
			}
			if (NumberOfDialogue == 5 && Choices.GetChoice(1) == false){
				Movement2.SetGoFaster(true);
			}
			if (NumberOfDialogue == 6 && Choices.GetChoice(1) == true){
				Movement2.SetGoNormal(true);
			}
			if (NumberOfDialogue == 6 && Choices.GetChoice(1) == false){
				Movement2.SetGoFaster(true);
			}
			if (NumberOfDialogue == 7 && Choices.GetChoice(1) == true){
				Movement2.SetGoNormal(true);
			}
			if (NumberOfDialogue == 7 && Choices.GetChoice(1) == false){
				Movement2.SetGoFaster(true);
			}

			if (NumberOfDialogue == 8 && Choices.GetChoice(3) == true && LetUsGoInvisible.GetCarlHasCookedHisFood() == false){
				LetUsGoInvisible.SetWeDidNotSaveCarl(true);
			}

			if (NumberOfDialogue == 8 && Choices.GetChoice(3) == false){
				Movement2.SetLegBroken(true);
			}

			if (NumberOfDialogue == 9 && Choices.GetChoice(3) == true){
				Movement2.SetGoFaster(true);
				Movement2.SetProceedFromTheCave(true);
			}

			if (NumberOfDialogue == 10 && Choices.GetChoice(3) == true){
				Movement2.SetGoFaster(true);
			}
			if (NumberOfDialogue == 10 && Choices.GetChoice(3) == false){
				Movement2.SetLegBroken(true);
			}

			if (NumberOfDialogue == 11 && Choices.GetChoice(3) == true){
				Movement2.SetGoFaster(true);
			}
			if (NumberOfDialogue == 11 && Choices.GetChoice(3) == false){
				Movement2.SetLegBroken(true);
			}
			if (NumberOfDialogue == 12 && Choices.GetChoice(3) == true){//dead girl
				Movement2.SetGoFaster(true);
				Choices.SetDecisionToBeMade(true);
				Choices.SetChoiceNumber(4);
			}
			if (NumberOfDialogue == 12 && Choices.GetChoice(3) == false){
				Movement2.SetLegBroken(true);
				Choices.SetDecisionToBeMade(true);
				Choices.SetChoiceNumber(4);
			}
			if (NumberOfDialogue == 13 && Choices.GetChoice(3) == true){
				Movement2.SetGoFaster(true);
				Choices.SetDecisionToBeMade(true);
				Choices.SetChoiceNumber(5);
			}
			if (NumberOfDialogue == 13 && Choices.GetChoice(3) == false){
				Movement2.SetLegBroken(true);
				Choices.SetDecisionToBeMade(true);
				Choices.SetChoiceNumber(5);
			}
			if (NumberOfDialogue == 14 && Choices.GetChoice(3) == true){
				Movement2.SetGoFaster(true);
			}
			if (NumberOfDialogue == 14 && Choices.GetChoice(3) == false){
				Movement2.SetLegBroken(true);
			}
			if (NumberOfDialogue == 15 && Choices.GetChoice(3) == true){
				Movement2.SetGoFaster(true);
				Conversation15Done = true;
			}
			if (NumberOfDialogue == 15 && Choices.GetChoice(3) == false){
				Movement2.SetLegBroken(true);
			}
			if (NumberOfDialogue == 16 && Choices.GetChoice(3) == true){
				Movement2.SetGoFaster(true);
				Application.Quit();

			}
			if (NumberOfDialogue == 16 && Choices.GetChoice(3) == false){
				Movement2.SetLegBroken(true);
			}

			if (NumberOfDialogue == 17 && Choices.GetChoice(3) == true){
				Movement2.SetGoFaster(true);
				LetUsGoInvisible.SetWePullCarlUpNow(true);
			}
			if (NumberOfDialogue == 17 && Choices.GetChoice(3) == false){
				Movement2.SetLegBroken(true);
				LetUsGoInvisible.SetWePullCarlUpNow(true);
			}
			if (NumberOfDialogue == 18 && Choices.GetChoice(3) == true){
				Movement2.SetGoFaster(true);
			}
			if (NumberOfDialogue == 18 && Choices.GetChoice(3) == false){
				Movement2.SetLegBroken(true);
			}
			if (NumberOfDialogue == 19 && Choices.GetChoice(3) == true){
				Movement2.SetGoFaster(true);
			}
			if (NumberOfDialogue == 19 && Choices.GetChoice(3) == false){
				Movement2.SetLegBroken(true);
			}

			if (NumberOfDialogue == 7){
				Movement2.SetGatherFood(true);
			}
			gameObject.SetActive(false);
			DialogueON = false;
		}
	}

	public static void NextDialogue(){
		currentDialogue++;
	}

	void OnGUI(){
		if(DialogueON == true){
			GUI.Box (new Rect(Screen.width/2-200, Screen.height/2-300, 400, 400), Dialogue[currentDialogue]);	// This inputs what dialogue shall be shown! Sizes of box might be changed

			// For dialogue 2 !!! (ABC choice)
			if (NumberOfDialogue == 2 && currentDialogue == 0){
				ChoiceIsMade = true;
				if (GUI.Button (new Rect(Screen.width/2-50, Screen.height/2+150, 100, 25), "What now?") || GUI.Button (new Rect(Screen.width/2-85, Screen.height/2+175, 170, 25), "Right. Let's just move on.")){
					ChoiceIsMade = false;
					currentDialogue++;
					lastDialogue = 2;	// Will set the last Dialogue to 2 (3rd image) as the last part of the array is not needed
					BackPack2.SetHaveBackpack(true);
				}
				else if (GUI.Button (new Rect(Screen.width/2-85, Screen.height/2+200, 170, 25), "No shit Sherlock.")){
					ChoiceIsMade = false;
					currentDialogue = 2;	// Skips a part of the dialogue which is not needed
					BackPack2.SetHaveBackpack(true);
				}
			}
			// For dialogue 7 !!! (ABC choice)
			if (NumberOfDialogue == 7 && currentDialogue == 0){
				ChoiceIsMade = true;
				if (GUI.Button (new Rect(Screen.width/2-235, Screen.height/2+150, 470, 25), "Yes. I suggest that we should split up and search in either directions for food.")){
					ChoiceIsMade = false;
					currentDialogue++;
					lastDialogue = 3;	// Will set the last Dialogue to 2 (3rd image) as the last part of the array is not needed
				}
				else if (GUI.Button (new Rect(Screen.width/2-235, Screen.height/2+175, 470, 25), "Yes. I suggest that we both go out looking for food together.") || GUI.Button (new Rect(Screen.width/2-235, Screen.height/2+200, 470, 25), "Yes. I suggest that you head out while I watch the fire.")){
					ChoiceIsMade = false;
					currentDialogue = 3;	// Skips a part of the dialogue which is not needed
				}
			}
			// For dialogue 8 !!! (ABC choice)
			if (NumberOfDialogue == 8 && currentDialogue == 0){
				ChoiceIsMade = true;
				if (GUI.Button (new Rect(Screen.width/2-235, Screen.height/2+150, 470, 25), "Carl! You’re back! What happened?") || GUI.Button (new Rect(Screen.width/2-235, Screen.height/2+175, 470, 25), "Carl! I’m glad you’re back!") || GUI.Button (new Rect(Screen.width/2-235, Screen.height/2+200, 470, 25), "Carl! You’re back! I’m happy to see that you found more food!")){
					ChoiceIsMade = false;
					currentDialogue++;
				}
			}

			// The normal "Next" button
			if (ChoiceIsMade == false && Choices.GetDecisionToBeMade() == false){
				if (GUI.Button (new Rect(Screen.width/2- 50, Screen.height/2+100, 100, 25), "Next")){
					if (NumberOfDialogue == 3 && currentDialogue == 2){
						Choices.SetDecisionToBeMade(true);
						Choices.SetChoiceNumber(1);
						// Also the 1 choice script shall run the "GUIDialogue.NextDialogue()" when a choice is made or we would be stuck!
					}
					else currentDialogue++;
					// Other triggers in dialogue:
					if (NumberOfDialogue == 3 && currentDialogue == 4){
						// Insert the "Eating Sound" to trigger here
					}
					if (NumberOfDialogue == 4 && (currentDialogue == 4 || currentDialogue == 5)){
						BackPack2.SetHaveBackpack(true);
					}
				}
			}

			// For dialogue 3 !!! (1 choice)
			if (NumberOfDialogue == 3 && ChoiceIsMade == true){
				if (Choices.GetChoice(1) == true){
					lastDialogue = 4;
						ChoiceIsMade = false;
				}
				else if (Choices.GetChoice(1) == false){
					currentDialogue = 4;
					ChoiceIsMade = false;
				}
			}
			// For dialogue 4 !!! (how the outcome of 1 choice was)
			if (NumberOfDialogue == 4 && currentDialogue == 2){
				if (Choices.GetChoice(1) == true){
					lastDialogue = 5;
					ChoiceIsMade = false;
				}
				else if (Choices.GetChoice(1) == false){
					currentDialogue = 5;
					ChoiceIsMade = false;
				}
			}
			// For dialogue 12 !!! (how the outcome of 3 choice was)
			if (NumberOfDialogue == 12 && currentDialogue == 2){
				if (Choices.GetChoice(3) == true){
					lastDialogue = 3;
					ChoiceIsMade = false;
				}
				else if (Choices.GetChoice(3) == false){
					currentDialogue = 3;
					ChoiceIsMade = false;
				}
			}
			// For dialogue 13 !!! (how the outcome of 3 and 4 choices was)
			if (NumberOfDialogue == 13 && currentDialogue == 1){
				if (Choices.GetChoice(3) == true){
					lastDialogue = 2;
					ChoiceIsMade = false;
				}
				else if (Choices.GetChoice(3) == false){
					if (Choices.GetChoice(4) == true){
						currentDialogue = 2;
						lastDialogue = 3;
					}
					else if (Choices.GetChoice(4) == false){
						currentDialogue = 3;
						ChoiceIsMade = false;
					}
				}
			}

		}
	}
}
