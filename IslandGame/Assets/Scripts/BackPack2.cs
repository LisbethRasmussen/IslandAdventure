﻿using UnityEngine;
using System.Collections;

public class BackPack2 : MonoBehaviour {

	//There needs to be added a getter function for checking whether or not the character has a backpack.
	private bool Bpressed = false;
	private bool CloseMe = false;
	private int saftyCounter = 0;
	private string LineShift = "\n\n\n";
	
	void Start () {
		
	}
	
	void Update () {
		
		if (Input.GetKey (KeyCode.B) && Bpressed == false && CloseMe == false) {
			Bpressed = true;
		}
		if (Input.GetKey (KeyCode.B) && Bpressed == true && CloseMe == true) {
			Bpressed = false;
		}
		if (Bpressed == true && CloseMe == false) {
			saftyCounter++;
			if (saftyCounter == 24) {
				CloseMe = true;
				saftyCounter = 0;
			}
		}
		if (Bpressed == false && CloseMe == true) {
			saftyCounter++;
			if (saftyCounter == 24) {
				CloseMe = false;
				saftyCounter = 0;
			}
		}
	}
	
	void OnGUI() {
		if (Bpressed == true ){
			GUI.Button (new Rect(1100,10,250,250), "food items "
			            + Movement2.GetFoodCount()
			            + LineShift
			            + "I should also be an item!"
			            + LineShift
			            + "You don't ways? what about me?"
			            + LineShift
			            + "HEY! I'm here too!!!");
		}
	}
}
