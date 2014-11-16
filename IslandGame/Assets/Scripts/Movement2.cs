using UnityEngine;
using System.Collections;

//access to the player mouselook:
//GetMouseLookLock
//SetMouseLookLock

public class Movement2 : MonoBehaviour {

	private bool messageON = false;
	private int messageTimer = 0;
	private static int foodCount = 0;
	private static float playerPosX;
	private static float playerPosZ;


	public GameObject myStick;			// I need mah stick!
	public static bool MiniGameOn = false;

	public static bool GetMiniGameOn(){ //this is for the conversation script, in case it is needed.
		return MiniGameOn;
	}
	public static void SetMiniGameOn(bool x){//this value is to changed in the conversation script, so when I has asked the player
		MiniGameOn = x; 			//to fish up the boxes, this needs to be returned true.
	}


	public static int GetFoodCount(){
		return foodCount;
	}
	
	public static float GetPlayerX() {
		return playerPosX;
	}
	
	public static float GetPlayerZ() {
		return playerPosZ;
	}
	
	// Use this for initialization
	void Start () {
		MiniGameOn = true; //this needs to be deleted later.
	}
	
	// Update is called once per frame
	void Update () {
		playerPosX = transform.position.x;
		playerPosZ = transform.position.z;

		//------------------------------------------minibox game components

		if (MiniGameOn == true){
			myStick.SetActive(true);
		}
		else{
			myStick.SetActive(false);
		}

		//somehow this does not work now. debug later.
		if (Input.GetKey(KeyCode.T) && myStick.activeSelf == true){	// ".activeSelf" checks if the object is active or not
			myStick.transform.Rotate(-20 * Time.deltaTime, 0, 0, Space.World);	// Makes the stick rotate up! don't ask why it is .left and not .up
		}
		if (Input.GetKey(KeyCode.G) && myStick.activeSelf == true){
			myStick.transform.Rotate(20 * Time.deltaTime, 0, 0, Space.World);	// Makes the stick rotate down! don't ask why it is .right and not .down
		}
		
		/*if (Input.GetKey(KeyCode.O)){
			myStick.SetActive(false);	// This deactivates the stick! Making it disappear form the scene and makes it inaffective (but it still "follows" he player's position)
		}
		if (Input.GetKey(KeyCode.P)){
			myStick.SetActive(true);	// Same as before just with activating it!
		}*/
		if (Hook.GetBoxesOnLand() == 3){
			myStick.SetActive(false);
		}
		//------------------------------------------mingame code stop-----------------------------------
		
		if (messageON == false){
			// Basic movements for testing
			
			
			// Limitation of movements!
			//if (transform.position.z >= 30000 || transform.position.x <= 30000){	// Here shall we set the limit for where we can go depending on xyz (This is to limit us in a square which might be easist to do)
			//	messageON = true;	// This should also do so a message pops up while the timer runs
		//	}
			
			if (PickUpSound2.GetItemPicked () == true){
				foodCount++;
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
