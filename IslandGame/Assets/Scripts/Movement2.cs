using UnityEngine;
using System.Collections;

//access to the player mouselook:
//GetMouseLookLock
//SetMouseLookLock

public class Movement2 : MonoBehaviour {

	private bool messageON = false;
	private int messageTimer = 0;
	private static int foodCount = 0;
	private static int FireWood = 0;

	public GameObject Carl; //we need to have him inactive at three times: Beginning, during food search and when he falls down a hole.
	public static bool CarlActive = false; //this variable is for the getter function further down.

	private bool arrivedFirstTime = false;
	public static bool GatherFood = false;
	public static bool FindCarl = false;
	public static bool ProceedFromTheCave = false;
	public GameObject CWallF;
	public GameObject CWallL;
	public GameObject CWallR;
	public GameObject CWallB;
	private bool GoSearch = true;
	public GameObject CampFire;
	private static bool CampfireOn = false;
	public static bool GetCampfireOn(){return CampfireOn;}

	public GameObject IslandWall;

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
	public static void SetGatherFood(bool x){GatherFood = x;}
	public static void SetFindCarl(bool x){FindCarl = x;}
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

		Anim = gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		playerPosX = transform.position.x; //setting the floats to the players position in world.
		playerPosZ = transform.position.z;
		playerPosY = transform.position.y;

		//----------------------------------------Java c# coorperation cheat
		/*if (Choices.GetChoice(3) == false && GUIDialogue.GetDialogueON() == false && AnimationON == false){
			GoNormal = true;
		}
		if (Choices.GetChoice(1) == false){ //If they chose to eat - we move faster!
			GoFaster = true;
		}*/
		if(GUIDialogue.GetDialogueON() == true || AnimationON == true || DoNotMove == true){
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
		/*if (Choices.GetWasChoiceMade(2) == true && Choices.GetChoice(2) == false) {
			AnimationON = true;
			IslandWall.SetActive (false);
		}
		if (Choices.GetWasChoiceMade(2) == true && Choices.GetChoice(2) == true && playerPosY <= 22) {
			AnimationON = true;
			IslandWall.SetActive (false);
		}*/
		if (Choices.GetWasChoiceMade(2) == true){
			DoNotMove = false;
			if (Choices.GetChoice(1) == false){
				GoFaster = true;
			}
			if (Choices.GetChoice(1) == true){
				GoNormal = true;
			}
			//AnimationsOnOff.SetIdlle(false);
			if (Choices.GetChoice(2) == false){
				IslandWall.SetActive (false);
				AnimationON = true;
			}
			if (Choices.GetChoice(2) == true){
				IslandWall.SetActive (false);
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

		//---------------------------------------------------------We have now been drinking-----------


		//-------------------------------------------------------------walls around the cave
		if (playerPosX >= 1042 && playerPosX <= 1069 && playerPosZ >= 1330 && playerPosZ <= 1348 && arrivedFirstTime == false){
			CWallB.SetActive (true);
			arrivedFirstTime = true;
			CampFire.SetActive(true);//when Carl have his animation, this needs to be put somewhere else
		}
		if (GatherFood == true && GoSearch == true){
			CWallL.SetActive(false);
			Carl.SetActive(false);
			GoSearch = false;
		}
		if (FindCarl == true){
			CWallR.SetActive(false);
			CWallL.SetActive(true);
		}
		if (ProceedFromTheCave == true){
			CWallF.SetActive(false);
		}
		if (playerPosX >= 1080 && playerPosZ >= 1272 && playerPosZ <= 1359 && GatherFood == true){
			CWallL.SetActive(true);
		}
		if (foodCount == 4){
			GatherFood = false;
			CWallL.SetActive(false);
		}
		/*if (foodCount == 7.0f){
			FoodAreaWallF.SetActive (false);
			FoodAreaWallL.SetActive (false);
			FoodAreaWallR.SetActive (false);
			FoodAreaWallB.SetActive (false);
			GatherFood = false;
		}*/ //set this active when the other stuff is active as well.


		//------------------------------------------------------------------------------------------
		if (messageON == false){
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
		}
		
		if (messageON == true){	// A custom timer there avoid bugs (running forward while you keep being pushed back dosn't look very good)
			messageTimer++;
			if (messageTimer == 24){
				transform.position -= transform.forward * 25 * Time.deltaTime; // This line shall just be changed so we go "backwards" depending on the player's position
				messageON = false;
				messageTimer = 0;
			}
		}
		
	}
}
