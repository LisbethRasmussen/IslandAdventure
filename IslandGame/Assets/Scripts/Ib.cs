using UnityEngine;
using System.Collections;

public class Ib : MonoBehaviour { //don't be fooled by the name, this is Carl's script.

	private static float PosX;				// Ib's X position in world space (Z is below)
	private static float PosZ;
	private float playerDistanceX;			// The distance between Ib and the player (X (Z is below))
	private float playerDistanceZ;
	private static bool pauseMovement = true;		// Shall Ib be moving? This bool states it!
	private static bool DialogueTrigger1 = false;		// A trigger for the first dialogue
	private float movementRange = 4.0f; 	// The range between the player and Ib before he moves towards the player ("skewed" walking)
	private float maxMovementRange = 7.0f;	// Needed this as if you stood directly on Ib's X or Z axies wouldn't he move
	public GameObject myStick;			// I need mah stick!
	private float StupidBallDistanceX;
	private float StupidBallDistanceZ;
	private static bool BallIsActive = false;

	public static bool GetBallIsActive (){return BallIsActive;}
	public static void SetBallIsActive (bool x){BallIsActive = x;}

	public static float GetPosX(){
		return PosX;
	}
	public static float GetPosZ(){
		return PosZ;
	}

	public static bool GetPauseMovement(){
		return pauseMovement;
	}

	public static bool GetDialogueTrigger1(){
		return DialogueTrigger1;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		PosX = transform.position.x;		
		PosZ = transform.position.z;

		if (Movement2.GetMiniGameOn() == true){
			myStick.SetActive(false);
		}
		else{
			myStick.SetActive(true);
		}

		playerDistanceX = Mathf.Abs(PosX - Movement2.GetPlayerX());	// Calculates the distance from Ib and the player (X (Z is below))
		playerDistanceZ = Mathf.Abs(PosZ - Movement2.GetPlayerZ());

		StupidBallDistanceX = Mathf.Abs (PosX - stupidball.GetPosX ());
		StupidBallDistanceZ = Mathf.Abs (PosZ - stupidball.GetPosZ ());

		if (Movement2.GetCarlActive () == true) {
			transform.LookAt (GameObject.Find ("Player").transform);	// This makes Ib look directly at the player all the time! Creepy D:
		
			if ((playerDistanceX >= movementRange && playerDistanceZ >= movementRange) || playerDistanceX >= maxMovementRange || playerDistanceZ >= maxMovementRange) {	// See if the Ib is too far away from the player
				pauseMovement = true;	// Then lets move closer to our friend!
			} else {
				pauseMovement = false;	// I am close enough... don't want things to become weird!
				if (DialogueTrigger1 == false)
					DialogueTrigger1 = true;	// Triggers the first dialogue in the "DialogueOn" script
			}
		}
		if(pauseMovement == true){
			//transform.position += transform.forward * 10 * Time.deltaTime;	// This so far controls the movement, just moves towards the player
			//This if statement is not needed, but I'm not gonna delete it yet, as I have to tell that the animation
			//which sets on walking when this statement is true, also takes care of getting the character to move forward.
		}

		if (BallIsActive == true) {
			transform.LookAt (GameObject.Find ("StupidBall").transform);	// This makes Ib look directly at the player all the time! Creepy D:
			
			if ((StupidBallDistanceX >= movementRange && StupidBallDistanceZ >= movementRange) || StupidBallDistanceX >= maxMovementRange || StupidBallDistanceZ >= maxMovementRange) {	
				pauseMovement = true;	// Then lets move closer to our friend!
			} else {
				pauseMovement = false;	// I am close enough... don't want things to become weird!
			}
		}


		/*if (Input.GetKey(KeyCode.P)){
			myStick.SetActive(false);	// This deactivates the stick! Making it disappear form the scene and makes it inaffective (but it still "follows" he player's position)
		}
		if (Input.GetKey(KeyCode.O)){
			myStick.SetActive(true);	// Same as before just with activating it!
		}*/
	}
}
