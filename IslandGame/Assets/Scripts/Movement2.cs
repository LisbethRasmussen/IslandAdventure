using UnityEngine;
using System.Collections;

//access to the player mouselook:
//GetMouseLookLock
//SetMouseLookLock

public class Movement2 : MonoBehaviour {

	private int saftyCounterToUseForJumpHelp = 0;
	private bool HelpMeIamSTUCK = false;

	private bool SlipAndFallInTheWater = false;
	private float saftyCounterForPushedInWater = 0;

	private static int SubtitleCounter = 0;
	public static int GetSubtitleCounter(){return SubtitleCounter;}
	public static void SetSubtitleCounter(int x){SubtitleCounter = x;}

	private bool Choie2Made = false;

	private bool messageON = false;
	private int messageTimer = 0;
	private static int foodCount = 0;
	private static int FireWood = 0;

	public GameObject Carl; //we need to have him inactive at three times: Beginning, during food search and when he falls down a hole.
	public static bool CarlActive = false; //this variable is for the getter function further down.

	private bool arrivedFirstTime = false;
	public static bool GatherFood = false;
	//public static bool FindCarl = false;
	public static bool ProceedFromTheCave = false;
	public GameObject CWallF;
	public GameObject CWallL;
	public GameObject CWallR;
	public GameObject CWallB;
	private bool GoSearch = true;
	public GameObject CampFire;
	public GameObject Fire;
	private bool FireFed = false;
	private static bool CampfireOn = false;
	public static bool GetCampfireOn(){return CampfireOn;}
	public static void SetCampfireOn(bool x){CampfireOn = x;}
	private static bool GatherFireWood = false;
	public static bool GetGatherFireWood(){return GatherFireWood;}
	private static bool secondGatherFirewood = false;
	private static bool Slept = false;
	private bool SleepDone = false;
	private bool doneWithFoodCollect = false;
	public GameObject Subtitle03;
	public GameObject Subtitle04;
	private bool choice3MadeYet = false;
	private static bool ChoiceScreenOn = false;
	public static void SetChoiceScreenOn(bool x){ChoiceScreenOn = x;}
	private bool YourLegIsBroken = false;
	private bool ThisIsFirstRun = false;
	private bool HaveWeFedTheMan = false;

	private static bool ExitedTheCaveArea = false;
	public static void SetExitedTheCaveArea(bool x){ExitedTheCaveArea = x;}

	public GameObject IslandWall;
	public GameObject SaveCarlWall;
	public GameObject DontSaveCarlWall;

	private static bool AnimationON = false;
	private static bool DoNotMove = false;
	//public GameObject AnimatorObject;
	public Animator Anim;
	public static int AnimationCounter = 1;
	public static int GetAnimationCounter(){return AnimationCounter;}
	public static void SetAnimationCounter(int x){AnimationCounter = x;}

	private static float playerPosX;
	private static float playerPosZ;
	private static float playerPosY; //because of the picture

	public GameObject NormalSpeed;//these game objects creates a bridge to the java script characterMotor. As we were unsuccessfull to make the scripts interact
	public GameObject FasterSpeed;//the middle way was to create these objects, and make the c# script set them active or not active, and then let the javascript
	public GameObject SlowerSpeed;//detect which object is active and set the speed to a certain value, if a certain object is active on the scene.
	public GameObject BrokenLegSpeed;
	//the code in the java script for this is after line 190 and consists of three if statements checking for the objects' active status.
	//The objects needs to be placed out of sight at all times. They are not part of the graphics.

	public static bool GoNormal = false;
	public static bool GoFaster = false;
	public static bool LegBroken = false;
	public static void SetGoNormal(bool x){ GoNormal = x;}
	public static void SetGoFaster(bool x){ GoFaster = x;}
	public static void SetLegBroken(bool x){ LegBroken = x;}

	//---------------------------------------The Carl getter------------------------------------
	public static bool GetCarlActive(){ return CarlActive;}
	public static void SetCarlActive(bool x){ CarlActive = x;}

	//---------------------------------Cave Wall setters--------------------------------------
	public static bool GetGatherFood (){return GatherFood;}
	public static void SetGatherFood(bool x){GatherFood = x;}
	//public static void SetFindCarl(bool x){FindCarl = x;}
	public static void SetProceedFromTheCave(bool x){ProceedFromTheCave = x;}
	//------------------------------------------------------------------------------don't move!
	public static bool GetAnimationOn(){return AnimationON;} //this is to make sure that the animator script only does something when this is turned true
	public static void SetAnimationOn(bool x){AnimationON = x;} //several different scripts can be used to trigger the animation accoring to time and place, therefore we need a setter.
	public static void SetDoNotMove(bool x){DoNotMove = x;}
	//------------------------------------------minigame code-----------------------------------------
	public GameObject myStick;			// I need mah stick!
	public static bool MiniGameOn = false; //Is the box game even on?

	public static bool GetMiniGameOn(){return MiniGameOn;}
	public static void SetMiniGameOn(bool x){MiniGameOn = x;} //this is set to true in the GUIDialogue script when the end of dialogue 2 has been reached.
	//---------------------------------------------------------------------------We need to drink stuff----------
	private float GoDownCount = 0;

	//----------------------------------------------------------------------------------------------------
	//code for sending the number of food items picked up to the backpack script
	public static int GetFoodCount(){return foodCount;}
	public static void SetFoodCount(int x){foodCount = x;}
	public static int GetFireWood(){ return FireWood;}
	public static void SetFireWood(int x){FireWood = x;}
	//--------------------------------------code for sending the information about the players positions
	public static float GetPlayerX() {
		return playerPosX;
	}
	public static float GetPlayerZ() {
		return playerPosZ;
	}
	public static float GetPlayerY() {
		return playerPosY;
	}
	//---------------------------------------------------------------------------------------------------

	// Use this for initialization
	void Start () {
		//needs to be changed later since we start with an animation
		NormalSpeed.SetActive (false); //to false
		FasterSpeed.SetActive (false);
		SlowerSpeed.SetActive (false); //to true
		BrokenLegSpeed.SetActive (false);
		MouseLook.SetMouseLookLock(true); //to false

		CWallF.SetActive (true);
		CWallL.SetActive (true);
		CWallR.SetActive (true);
		CWallB.SetActive (false);

		CampFire.SetActive (false);

		Carl.SetActive (false); //We don't want him to be there at first!!!
		CarlActive = false;

		SaveCarlWall.SetActive (false);
		DontSaveCarlWall.SetActive (false);

		Anim = gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Choices.GetWasChoiceMade(2) == true && Choices.GetChoice(2) == true && playerPosX <= 1215 && playerPosX >= 1210 && playerPosZ <= 1434 && playerPosZ >= 1429 && SlipAndFallInTheWater == false){
			transform.position += new Vector3 (0,0,0.6f);
			saftyCounterForPushedInWater ++;
			if (saftyCounterForPushedInWater >= 18){
				SlipAndFallInTheWater = true;
			}
		}

		if (Input.GetKey(KeyCode.P) && HelpMeIamSTUCK == false){
			transform.position += new Vector3 (0,1,0);
			saftyCounterToUseForJumpHelp ++;
			if (saftyCounterToUseForJumpHelp == 30){
				HelpMeIamSTUCK = true;
			}
		}
		if (Input.GetKey(KeyCode.O)){
			HelpMeIamSTUCK = false;
		}

		if (Input.GetKey(KeyCode.U)){
			GUIDialogue.SetDialogueON(false);
			AnimationON = false;
			DoNotMove = false;
			ChoiceScreenOn = false;
			if (Choices.GetWasChoiceMade (1) == false){
				GoNormal = true;
			}
			if (Choices.GetWasChoiceMade(1) == true &&Choices.GetWasChoiceMade (3) == false && Choices.GetChoice(1) == false){
				GoFaster = true;
			}
			if(Choices.GetWasChoiceMade(1) == true &&Choices.GetWasChoiceMade (3) == false && Choices.GetChoice(1) == true){
				GoNormal = true;
			}
			if (Choices.GetWasChoiceMade (3) == true && Choices.GetChoice(3) == true){
				GoFaster = true;
			}
			if (Choices.GetWasChoiceMade (3) == true && Choices.GetChoice(3) == false){
				LegBroken = true;
			}
		}

		//print ("GoNormal " + GoNormal + " GoFaster " + GoFaster + " Dig " + GUIDialogue.GetDialogueON () + " AnimON " + AnimationON + " do not move " + DoNotMove + " choiches " + ChoiceScreenOn);

		if (Input.GetKey(KeyCode.M)){
			foodCount = 6;
		}
		playerPosX = transform.position.x; //setting the floats to the players position in world.
		playerPosZ = transform.position.z;
		playerPosY = transform.position.y;

		if(GUIDialogue.GetDialogueON() == true || AnimationON == true || DoNotMove == true || ChoiceScreenOn == true){
			NormalSpeed.SetActive (false); //this is the speed in which they walk not so fast, as they lack energy.
			FasterSpeed.SetActive (false); //this is the speed after they've aten something, or if they are well rested.
			SlowerSpeed.SetActive (true); //this value needs to be checked in the java script, it should be 0
			MouseLook.SetMouseLookLock(true);
			GoNormal = false;
			GoFaster = false;
			LegBroken = false;


		}
		if (GoNormal == true && GUIDialogue.GetDialogueON() == false/* && AnimationON == false && DoNotMove == false*/){
			//print ("i walk normal");
			NormalSpeed.SetActive (true);
			FasterSpeed.SetActive (false);
			SlowerSpeed.SetActive (false);
			BrokenLegSpeed.SetActive (false);
			MouseLook.SetMouseLookLock(false);
			Anim.enabled = false;
		}
		if (GoFaster == true && GUIDialogue.GetDialogueON() == false/* && AnimationON == false && DoNotMove == false*/){
			//print ("i go faster");
			NormalSpeed.SetActive (false);
			FasterSpeed.SetActive (true);
			SlowerSpeed.SetActive (false);
			BrokenLegSpeed.SetActive (false);
			MouseLook.SetMouseLookLock(false);
			Anim.enabled = false;
		}
		if (LegBroken == true && GUIDialogue.GetDialogueON() == false/* && AnimationON == false && DoNotMove == false*/){
			NormalSpeed.SetActive (false);
			FasterSpeed.SetActive (false);
			SlowerSpeed.SetActive (false);
			BrokenLegSpeed.SetActive (true);
			MouseLook.SetMouseLookLock(false);
			Anim.enabled = false;
		}
		if (AnimationON == true){
			Anim.enabled = true;
		}
		if (AnimationON == false){
			Anim.enabled = false;
		}

		if (Choices.GetWasChoiceMade(2) == true && Choie2Made == false){
			DoNotMove = false;
			IslandWall.SetActive (false);
			if (Choices.GetChoice(1) == false){
				GoFaster = true;
			}
			if (Choices.GetChoice(1) == true){
				GoNormal = true;
			}
			//AnimationsOnOff.SetIdlle(false);
			if (Choices.GetChoice(2) == false){
				AnimationON = true;
				Choie2Made = true;
			}
			if (Choices.GetChoice(2) == true){
				Choie2Made = true;
			}
		}
		//------------------------------------------------------------------------------------------------

		//------------------------------------------minibox game components

		if (MiniGameOn == true){
			myStick.SetActive(true); //makes the stick part of the game world
		}
		else{
			myStick.SetActive(false);//makes the stick go inactive and invisible
		}

		//somehow this does not work properly now. debug later.
		if (Input.GetKey(KeyCode.T) && myStick.activeSelf == true){	// ".activeSelf" checks if the object is active or not
			myStick.transform.Rotate(-20 * Time.deltaTime, 0, 0, Space.World);	// Makes the stick rotate up! don't ask why it is .left and not .up
		}
		if (Input.GetKey(KeyCode.G) && myStick.activeSelf == true){
			myStick.transform.Rotate(20 * Time.deltaTime, 0, 0, Space.World);	// Makes the stick rotate down! don't ask why it is .right and not .down
		}

		if (Hook.GetBoxesOnLand() == 3){//If we have the three boxes on land, then the minigame needs to end.
			myStick.SetActive(false);
			MiniGameOn = false; //just to be sure that the stick does not respawn.
		}
		//------------------------------------------mingame code stop-----------------------------------
		//-------------------------------------------------------------------We need a drink!------------

		if (LetUsDrink.GetDrink() == true && Input.GetKey(KeyCode.E)){
			/*GoDownCount-= 0.1f;
			transform.position.y -= 0.1f;
			if (GoDownCount <= -1.5f){
				GoDownCount += 0.1f;
				transform.position.y += 0.1f;
				if (GoDownCount >= 0.1){*/
			LetUsDrink.SetDrink(false);
			LetUsDrink.SetDoneDrinking(true);
				/*}
			}*/
		}
		if (Letusdrink2.GetDrink() == true && Input.GetKey(KeyCode.E)){
			/*GoDownCount-= 0.1f;
			transform.position.y -= 0.1f;
			if (GoDownCount <= -1.5f){
				GoDownCount += 0.1f;
				transform.position.y += 0.1f;
				if (GoDownCount >= 0.1){*/
			Letusdrink2.SetDrink(false);
			Letusdrink2.SetDoneDrinking(true);
			/*}
			}*/
		}

		//---------------------------------------------------------We have now been drinking-----------


		//-------------------------------------------------------------walls around the cave
		if (CaveTrigger.GetBothAreAtCave() == true && arrivedFirstTime == false){
			CWallB.SetActive (true);
			if (CampfireOn == true){
				arrivedFirstTime = true;
				CampFire.SetActive(true);
			}
		}
		if (GatherFood == true && GoSearch == true){
			CWallL.SetActive(false);
			CWallR.SetActive(false);
			GoSearch = false;
		}

		if (SubtitleCounter == 6){
			// Noms on food
			Subtitle04.SetActive(true);
		}
		if (SubtitleCounter == 10 && choice3MadeYet == false){
			Choices.SetDecisionToBeMade(true);
			Choices.SetChoiceNumber(3);
			choice3MadeYet = true;
			ChoiceScreenOn = true;

		}
		if (Choices.GetChoice(3) == true && Choices.GetWasChoiceMade(3) && SleepDone == false){
			LetUsGoInvisible.SetSleep(true);
			GoNormal = true;
			GoFaster = false;
			CWallR.SetActive(false);
			SleepDone = true;
		}

		if (/*FindCarl == true*/Choices.GetChoice(3) == false && Choices.GetWasChoiceMade(3) && YourLegIsBroken == false){
			CWallR.SetActive(false);
			CWallL.SetActive(true);
			//need some gui text describing what happens after the player go to find Carl
			LegBroken = true;
			YourLegIsBroken = true;
		}
		if (ProceedFromTheCave == true && ExitedTheCaveArea == false){
			CWallF.SetActive(false);
		}
		if (ExitedTheCaveArea == true){
			CWallF.SetActive(true);
		}
		if (playerPosX >= 1080 && playerPosZ >= 1272 && playerPosZ <= 1359 && GatherFood == true){
			CWallL.SetActive(true);
			//CWallR.SetActive(true);
		}
		if (foodCount >= 4 && doneWithFoodCollect == false){
			GatherFood = false;
			CWallL.SetActive(false);
			Subtitle03.SetActive(true);
		}
		if (GatherFood == false && foodCount >= 4 && playerPosX <= 1072.0f && playerPosZ >= 1300.0f && playerPosZ <= 1332.0f && FireFed == false){
			CWallL.SetActive(true);
			GatherFireWood = true;
			Fire.SetActive(false);
			doneWithFoodCollect = true;
			foodCount = foodCount/2;
			CWallR.SetActive(true);
		}
		if (CampFireScript.GetFedXtimes() == 3 && foodCount >= 1){
			Fire.SetActive(true);
			GatherFireWood = false;
			FireFed = true;
		}
		if (Slept == true && secondGatherFirewood == true){
			Fire.SetActive(false);
			GatherFireWood = true;

		}
		//-------------------------------------------------if we feed the man
		if (Choices.GetWasChoiceMade(5) == true && Choices.GetChoice(5) == false && HaveWeFedTheMan == false){
			foodCount = foodCount/2;
			HaveWeFedTheMan = true;
		}
		//--------------------------------------------------------------Carll will fall now!

		if (triggerCarlFallInHole.GetCarlHasFallen() == true && ThisIsFirstRun == false){
			Carl.SetActive(false);
			ThisIsFirstRun = true;
		}
		if (Choices.GetWasChoiceMade(6) == true && Choices.GetChoice(6) == true){
			DontSaveCarlWall.SetActive(true);
		}
		if (Choices.GetWasChoiceMade(6) == true && Choices.GetChoice(6) == false){
			SaveCarlWall.SetActive(true);
		}
		//-----------------------------------------------------die potato nooooooooooooooooooooooo.

		//------------------------------------------------------------------------------------------
		//if (messageON == false){
			// Basic movements for testing
			
			
			// Limitation of movements!
			//if (transform.position.z >= 30000 || transform.position.x <= 30000){	// Here shall we set the limit for where we can go depending on xyz (This is to limit us in a square which might be easist to do)
			//	messageON = true;	// This should also do so a message pops up while the timer runs
		//	}
			
			if (PickUpSound2.GetItemPicked () == true){//sending a message to the script PickUpSound, thereby it will make a sound!
				foodCount++; //And the food count goes up.
			}
			if (PickUpSound2.GetFireWoodPicked () == true){//sending a message to the script PickUpSound, thereby it will make a sound!
				FireWood++; //And the food count goes up.
			}
		//}
		
		/*if (messageON == true){	// A custom timer there avoid bugs (running forward while you keep being pushed back dosn't look very good)
			messageTimer++;
			if (messageTimer == 24){
				transform.position -= transform.forward * 25 * Time.deltaTime; // This line shall just be changed so we go "backwards" depending on the player's position
				messageON = false;
				messageTimer = 0;
			}
		}*/
		
	}
}
