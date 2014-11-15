using UnityEngine;
using System.Collections;

public class Ib : MonoBehaviour {

	private static float PosX;				// Ib's X position in world space (Z is below)
	private static float PosZ;
	private float playerDistanceX;			// The distance between Ib and the player (X (Z is below))
	private float playerDistanceZ;
	private static bool pauseMovement = true;		// Shall Ib be moving? This bool states it!
	private float movementRange = 4.0f; 	// The range between the player and Ib before he moves towards the player ("skewed" walking)
	private float maxMovementRange = 7.0f;	// Needed this as if you stood directly on Ib's X or Z axies wouldn't he move
	public GameObject myStick;			// I need mah stick!

	public static bool GetPauseMovement(){
		return pauseMovement;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		PosX = transform.position.x;		
		PosZ = transform.position.z;

		playerDistanceX = Mathf.Abs(PosX - Movement2.GetPlayerX());	// Calculates the distance from Ib and the player (X (Z is below))
		playerDistanceZ = Mathf.Abs(PosZ - Movement2.GetPlayerZ());

		transform.LookAt (GameObject.Find ("Player").transform);	// This makes Ib look directly at the player all the time! Creepy D:
		
		if((playerDistanceX >= movementRange && playerDistanceZ >= movementRange) || playerDistanceX >= maxMovementRange || playerDistanceZ >= maxMovementRange){	// See if the Ib is too far away from the player
			pauseMovement = true;	// Then lets move closer to our friend!
		}
		else{
			pauseMovement = false;	// I am close enough... don't want things to become weird!
		}

		if(pauseMovement == true){
			//transform.position += transform.forward * 10 * Time.deltaTime;	// This so far controls the movement, just moves towards the player
			//This if statement is not needed, but I'm not gonna delete it yet, as I have to tell that the animation
			//which sets on walking when this statement is true, also takes care of getting the character to move forward.
		}
		if (Input.GetKey(KeyCode.P)){
			myStick.SetActive(false);	// This deactivates the stick! Making it disappear form the scene and makes it inaffective (but it still "follows" he player's position)
		}
		if (Input.GetKey(KeyCode.O)){
			myStick.SetActive(true);	// Same as before just with activating it!
		}
	}
}
