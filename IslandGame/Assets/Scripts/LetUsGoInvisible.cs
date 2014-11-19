using UnityEngine;
using System.Collections;

//this script is intended to be faking the vision of the player. It should appear as if the players vision fade in and out due to
//the harsh trip of being a castaway.

//Place this script on the black box.

//Under the mesh rendere of the object this is to be placed on, choose some shader/material which can be tampered with
//this script does NOT work, if you just use the default diffuse material or what ever it is called. Make a new material
//if needed in the desired color or an imported picture material.
//the shader of this material, where it says "shader" there is a button which normally says something like
//Diffuse. Click on it, and click on transparent, and then on Diffuse. Then this script will work!

//this script is not intended for Gui, although it can prolly easy be implimented.

public class LetUsGoInvisible : MonoBehaviour {

	private bool FadeOut = true;
	private bool FadeIn = false;
	public static bool HasGameStarted = false;
	private float fadeCounter = 1;

	private int FadedTooManyTimes = 0;
	private static bool BlackMyScreen = false;
	private static bool Sleeping = false;

	public static void SetFogBegin(bool x){
		HasGameStarted = x;
	}
	public static void SetBlackMyScreen (bool x){
		BlackMyScreen = x;
	}
	public static void SetSleep (bool x){
		Sleep = x;
	}

	// Use this for initialization
	void Start () {
		HasGameStarted = true;
	}
	
	// Update is called once per frame
	void Update () {

		if (HasGameStarted == true && FadeOut == true){
			fadeCounter -= 0.01f;
			renderer.material.color = new Color(0,0,0,fadeCounter);
			if (fadeCounter <= 0.01f){
				FadeOut = false;
				FadeIn = true;
				FadedTooManyTimes += 1;
			}
		}

		if (HasGameStarted == true && FadeIn == true){
			fadeCounter += 0.05f;
			renderer.material.color = new Color(0,0,0,fadeCounter);
			if (fadeCounter >= 1f){
				FadeOut = true;
				FadeIn = false;
				FadedTooManyTimes += 1;
			}
		}

		if (FadedTooManyTimes == 5){
			HasGameStarted = false;
			fadeCounter = 0;
			renderer.material.color = new Color(0,0,0,0);
			FadedTooManyTimes = 0;
		}

		if (BlackMyScreen == true) {
			renderer.material.color = new Color(0,0,0,1);
			fadeCounter ++;
			if (fadeCounter == 48){
				renderer.material.color = new Color(0,0,0,0);
			}

		}
		if (Sleeping == true) {
			renderer.material.color = new Color(0,0,0,1); //the 1 stands for not being transparent at all
			fadeCounter ++;
			if (fadeCounter == 100){
				renderer.material.color = new Color(0,0,0,0); //while the 0 is totally transparent
			}
			
		}

		//renderer.material.color -= new Color(0,0,0,0.01f);//basically just telling the object, that the material to be rendered should be set to a new color.
		//that color then has it's alpha channel changed as the only thing.
	
	}
}
