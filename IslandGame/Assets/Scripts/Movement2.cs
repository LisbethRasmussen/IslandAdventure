﻿using UnityEngine;
using System.Collections;

//access to the player mouselook:
//GetMouseLookLock
//SetMouseLookLock

public class Movement2 : MonoBehaviour {

	private bool messageON = false;
	private int messageTimer = 0;
	private static int foodCount = 0;
	private static int FireWood = 0;
	private static float playerPosX;
	private static float playerPosZ;
	private static float playerPosY; //because of the picture

	public GameObject NormalSpeed;//these game objects creates a bridge to the java script characterMotor. As we were unsuccessfull to make the scripts interact
	public GameObject FasterSpeed;//the middle way was to create these objects, and make the c# script set them active or not active, and then let the javascript
	public GameObject SlowerSpeed;//detect which object is active and set the speed to a certain value, if a certain object is active on the scene.
	//the code in the java script for this is after line 190 and consists of three if statements checking for the objects' active status.

	//------------------------------------------As the java script and C# did not want to work together
	/*//This wall makes the player stop moving.
	public GameObject GoNoFurtherWall;//this is not needed anymore, delete tomorrow.
	public static bool CanPlayerMove = true;
	private bool WallIsThere = false;

	public static bool GetCanPlayerMove(){ //this sends a message to the script on the wall, making sure it can be destroyed
		return CanPlayerMove;
	}
	public static void SetCanPlayerMove (bool x){ //we need the conversation script/decision script/cutscene script to tamper with this.
		CanPlayerMove = x; //setting the bool to the value of x, which can be accessed from other scripts.
	}*/
	//-------------------------------------------------------------------------------------------Wall

	//------------------------------------------minigame code-----------------------------------------
	public GameObject myStick;			// I need mah stick!
	public static bool MiniGameOn = false; //Is the game even on?

	public static bool GetMiniGameOn(){ //this is for the conversation script, in case it is needed.
		return MiniGameOn;
	}
	public static void SetMiniGameOn(bool x){//this value is to changed in the conversation script, so when I has asked the player
		MiniGameOn = x; 			//to fish up the boxes, this needs to be returned true.
	}
	//----------------------------------------------------------------------------------------------------

	public static int GetFoodCount(){ //code for sending the number of food items picked up to the backpack script
		return foodCount;
	}
	public static int GetFireWood(){ 
		return FireWood;
	}
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
		//MiniGameOn = true; //this needs to be deleted later.
		NormalSpeed.SetActive (true);
		FasterSpeed.SetActive (false);
		SlowerSpeed.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		playerPosX = transform.position.x; //setting the floats to the players position in world.
		playerPosZ = transform.position.z;
		playerPosY = transform.position.y;

		if (Choices.GetChoice(3) == false && GUIDialogue.GetDialogueON() == false){
			NormalSpeed.SetActive (true);
			FasterSpeed.SetActive (false);
			SlowerSpeed.SetActive (false);
		}
		if (Choices.GetChoice(1) == false && GUIDialogue.GetDialogueON() == false){ //If they chose to eat - we move faster!
			NormalSpeed.SetActive (false);
			FasterSpeed.SetActive (true);
			SlowerSpeed.SetActive (false);
		}
		if(GUIDialogue.GetDialogueON() == true){
			NormalSpeed.SetActive (false); //this is the speed in which they walk not so fast, as they lack energy.
			FasterSpeed.SetActive (false); //this is the speed after they've aten something, or if they are well rested.
			SlowerSpeed.SetActive (true); //this value needs to be checked in the java script, it should be 0
		}


		/*if (Input.GetKey(KeyCode.V)){ //needs to be deleted later on, this code is for debugging.
			CanPlayerMove = true;
		}
		if (Input.GetKey(KeyCode.C)){
			CanPlayerMove = false;
		}*/

		/*if (CanPlayerMove == false && WallIsThere == false){ //if the player should not be able to move, and we don't have a wall yet
			GameObject.Instantiate(GoNoFurtherWall, new Vector3(playerPosX,playerPosY,playerPosZ), transform.rotation);
			WallIsThere = true; //we don't want this function to run more than one time.
		}
		if (CanPlayerMove == true && WallIsThere == true){
			WallIsThere = false; // Now the upper function is ready again to spawn the wall when needed.
		}*/

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
