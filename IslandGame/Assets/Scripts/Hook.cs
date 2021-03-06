﻿using UnityEngine;
using System.Collections;

public class Hook : MonoBehaviour {

	private static float PosX;	// The Hook's X position in origin (Z is below)
	private static float PosZ;
	private static float PosY; //because we need to know how high up the hook is from the box as well.
	public Vector3 WorldPos;	// The Hook's position in world space
	public GameObject myCheatBox;	 //put the box which is placed upon the player stick onto here.

	public GameObject BoxOnLand1;
	public GameObject BoxOnLand2;
	public GameObject BoxOnLand3;

	public GameObject BoxInWater1;
	public GameObject BoxInWater2;
	public GameObject BoxInWater3;

	private static bool youMayPickUpAnotherBox = true;
	public static bool GetyouMayPickUpAnotherBox(){return youMayPickUpAnotherBox;}

	private bool WeCheatOnlyOnce = false;
	
	private bool Box1 = false;
	private bool Box2 = false;
	private bool Box3 = false;

	public static int BoxesOnLand = 0;

	public static int GetBoxesOnLand(){
		return BoxesOnLand;
	}

	public static float GetPosX(){
		return PosX;
	}
	public static float GetPosZ(){
		return PosZ;
	}
	public static float GetPosY(){
		return PosY;
	}

	// Use this for initialization
	void Start () {
		myCheatBox.SetActive (false);
		BoxOnLand1.SetActive (false);
		BoxOnLand2.SetActive (false);
		BoxOnLand3.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		WorldPos = transform.TransformPoint(Vector3.right * 0.16f);	// This transform the Hook's position from origion to world space, the 0.16f is for the scaling as this transformation do not affect how the object is scaled
		PosX = WorldPos.x;	// Sets this world position to overwrite the original origin position (X (Z is below))
		PosZ = WorldPos.z;
		PosY = WorldPos.y;

		if (myCheatBox.activeSelf == false){
			youMayPickUpAnotherBox = true;
		}

		if (Box.GetInRange() == true){
			myCheatBox.SetActive(true);
			youMayPickUpAnotherBox = false;
		}

		if (Box1 == false && Box.GetInRange() ==true && BoxInWater1.activeSelf == false && PosX <= 1287 && PosX >= 1274 && PosZ <= 1435 && PosZ >=1419){
			Box1 = true;
			BoxOnLand1.SetActive(true);
			myCheatBox.SetActive (false);
			Box.SetInRange(false);
			BoxesOnLand += 1;
		}
		if (Box2 == false && Box.GetInRange() ==true && BoxInWater2.activeSelf == false && PosX <= 1287 && PosX >= 1274 && PosZ <= 1435 && PosZ >=1419){
			Box2 = true;
			BoxOnLand2.SetActive(true);
			myCheatBox.SetActive (false);
			Box.SetInRange(false);
			BoxesOnLand += 1;
		}
		if (Box3 == false && Box.GetInRange() ==true && BoxInWater3.activeSelf == false && PosX <= 1287 && PosX >= 1274 && PosZ <= 1435 && PosZ >=1419){
			Box3 = true;
			BoxOnLand3.SetActive(true);
			myCheatBox.SetActive (false);
			Box.SetInRange(false);
			BoxesOnLand += 1;
		}
		if (Input.GetKey(KeyCode.K) && WeCheatOnlyOnce == false){
			BoxesOnLand = 3;
			Movement2.SetFoodCount(3);
			WeCheatOnlyOnce = true;
		}

		/*if (Box.GetInRange() == true){			// If the hook is in range of the box:
			myBox.transform.parent = transform;	// Makes the hook become a parent of the box!
			myBox.rigidbody.useGravity = false;	// Gravitiy will be disabled to we can lift it up! Careful it can now float away D:
		}*/
	}

	void OnGUI(){

		if (Movement2.GetMiniGameOn() == true){
			GUI.Box (new Rect(Screen.width/2-177, Screen.height/2-300, 355, 50),
			         "When standing at the boxes press T to rotate the stick up"
			         + "\n"
			         + "and G to rotat the stick down.");
		}
	}
}
