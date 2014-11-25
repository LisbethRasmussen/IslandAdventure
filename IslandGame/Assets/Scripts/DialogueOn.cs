using UnityEngine;
using System.Collections;

//this script will be used to trigger every single pice of dialogue, but it will be called from many different scripts.

public class DialogueOn : MonoBehaviour {

	public GameObject Dialogue1;	// The game objects there shall contain each dialogue empty objects
	public GameObject Dialogue2;
	public GameObject Dialogue3;
	public GameObject Dialogue4;
	public GameObject Dialogue5;
	public GameObject Dialogue6;
	public GameObject Dialogue7;
	public GameObject Dialogue8;
	public GameObject Dialogue9;
	public GameObject Dialogue10;
	public GameObject Dialogue11;
	public GameObject Dialogue12;
	public GameObject Dialogue13;
	public GameObject Dialogue14;
	public GameObject Dialogue15;
	public GameObject Dialogue16;
	public GameObject Dialogue17;
	public GameObject Dialogue18;
	public GameObject Dialogue19;

	private bool[] Trigger;	// A trigger for letting a dialogue only trigger once

	private float PlayerX;
	private float PlayerY;
	private float PlayerZ;

	// Use this for initialization
	void Start () {
		Trigger = new bool[19];
		for (int i = 0; i < 19; i++) {
			Trigger[i] = true;
		}
	}
	
	// Update is called once per frame
	void Update () {

		PlayerX = Movement2.GetPlayerX();
		PlayerY = Movement2.GetPlayerY();
		PlayerZ = Movement2.GetPlayerZ();



		if (Ib.GetDialogueTrigger1() == true && Trigger[1-1] == true) {
			GUIDialogue.SetDialogueON(true);
			Dialogue1.SetActive(true);
			Trigger[1-1] = false;
		}
		if (AnimationsOnOff.GetConversation2Active() == true && Trigger [2-1] == true){
			GUIDialogue.SetDialogueON(true);
			Dialogue2.SetActive(true);
			Trigger[2-1] = false;
		}
		if (Hook.GetBoxesOnLand () == 3 && Movement2.GetFoodCount () == 3 && Trigger [3 - 1] == true){
			GUIDialogue.SetDialogueON (true);
			Dialogue3.SetActive (true);
			Trigger [3 - 1] = false;
		}
		if (AnimationsOnOff.GetConversation4Active() == true && Trigger [4 - 1] == true){
			GUIDialogue.SetDialogueON (true);
			Dialogue4.SetActive (true);
			Trigger [4 - 1] = false;
		}
		if (PlayerZ >= 1403f && PlayerZ <= 1472 && PlayerX <= 1124 && Trigger [5 - 1] == true){
			GUIDialogue.SetDialogueON (true);
			Dialogue5.SetActive (true);
			Trigger [5 - 1] = false;
		}
		if (PlayerZ >= 1348f && PlayerZ <= 1428 && PlayerX <= 1086 && Trigger [6 - 1] == true){
			GUIDialogue.SetDialogueON (true);
			Dialogue6.SetActive (true);
			Trigger [6 - 1] = false;
		}
		if (Movement2.GetCampfireOn() == true && Trigger [7 - 1] == true){
			GUIDialogue.SetDialogueON (true);
			Dialogue7.SetActive (true);
			Trigger [7 - 1] = false;
		}
		if (LetUsGoInvisible.GetSleep() == false && Choices.GetChoice(3) == true && Choices.GetWasChoiceMade(3) && Ib.GetPauseMovement() == false && Movement2.GetSubtitleCounter() == 11 && Trigger [8 - 1] == true){
			GUIDialogue.SetDialogueON (true);
			Dialogue8.SetActive (true);
			Trigger [8 - 1] = false;
		}
		if (LetUsGoInvisible.GetCarlHasCookedHisFood() == true && Trigger [9 - 1] == true){
			GUIDialogue.SetDialogueON (true);
			Dialogue9.SetActive (true);
			Trigger [9 - 1] = false;
		}
		if (LetUsGoInvisible.GetWeHaveSavedCarl() == true && Trigger [11 - 1] == true){
			GUIDialogue.SetDialogueON (true);
			Dialogue11.SetActive (true);
			Trigger [11 - 1] = false;
		}
		if (DeadGirl.GetDeadGirlInRange() == true && Trigger [12 - 1] == true){
			GUIDialogue.SetDialogueON (true);
			Dialogue12.SetActive (true);
			Trigger [12 - 1] = false;
		}
		if (Choices.GetWasChoiceMade(5) == false && DyingMale.GetCloseEnoughToDyingMale() == true && Trigger [13 - 1] == true){
			GUIDialogue.SetDialogueON (true);
			Dialogue13.SetActive (true);
			Trigger [13 - 1] = false;
		}
		if (DustExplotion2.GetTheFirstDustCloudeIsSeen() == true && Trigger [14 - 1] == true){
			GUIDialogue.SetDialogueON (true);
			Dialogue14.SetActive (true);
			Trigger [14 - 1] = false;
		}
		if (BoatTrigger.GetBoatInRange() == true && Trigger [15 - 1] == true){
			GUIDialogue.SetDialogueON (true);
			Dialogue15.SetActive (true);
			Trigger [15 - 1] = false;
			BoatTrigger.SetShowBlackScreenByBoat(true);
		}
		if (BoatTrigger.GetShowBlackScreenByBoat() == true && Trigger [16 - 1] == true){
			GUIDialogue.SetDialogueON (true);
			Dialogue16.SetActive (true);
			Trigger [16 - 1] = false;
		}
		if (Choices.GetWasChoiceMade(6) == true && Choices.GetChoice(6) == false && Trigger [17 - 1] == true){
			GUIDialogue.SetDialogueON (true);
			Dialogue17.SetActive (true);
			Trigger [17 - 1] = false;
		}
	}
}
