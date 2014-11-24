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

	private static bool WeSaveCarl = false;
	public static bool GetWeSaveCarl(){return WeSaveCarl;}
	private static bool WeHaveSavedCarl = false;
	public static bool GetWeHaveSavedCarl(){return WeHaveSavedCarl;}
	public static void SetWeHaveSavedCarl(bool x){WeHaveSavedCarl = x;}
	public GameObject Carl;

	private bool FadeOut = true; //we need two different kinds of states on the cube. One where it gets lighter
	private bool FadeIn = false; //and one where it gets darker.
	public static bool HasGameStarted = false; //this may need to be deleted accoring to what the bool on the starting script does.
	private float fadeCounter = 1;
	private float frameCounter = 0;
	private bool SleepNow = false;
	public GameObject Subtitle05;

	private int FadedTooManyTimes = 0; //we only want the scene to fade a certain number of times.
	private static bool BlackMyScreen = false; //we need a "glitch" so the player knows that a cutscene is happening
	private static int HowManyBlackFrames = 0; //because different animations take different times to set themselves in position.
	private static bool Sleeping = false; //not matter what a sleeping scene occures, so the screen also needs to be black there.
	private bool PrivateBlackMyScreen = false;
	private static bool GetReadyAgainBlackMyScreen = true;

	public static void SetFogBegin(bool x){HasGameStarted = x;}
	public static void SetBlackMyScreen (bool x){BlackMyScreen = x;}
	public static void SetHowManyBlackFrames (int x){HowManyBlackFrames = x;}
	public static void SetGetReadyAgainBlackMyScreen (bool x){GetReadyAgainBlackMyScreen = x;}

	public static bool GetSleep (){//need a returner to send a message to a sound script with snorring (maybe not necessary).
		return Sleeping;
	}
	public static void SetSleep (bool x){//same as the others.
		Sleeping = x;
	}

	// Use this for initialization
	void Start () {
		//HasGameStarted = true;//this needs to be deleted later on.
	}
	
	// Update is called once per frame
	void Update () {

		if (HasGameStarted == true && FadeOut == true){ //we want to start with this one, which is why it has already been set to true in the beginning (before the start function)
			fadeCounter -= 0.01f;
			renderer.material.color = new Color(0,0,0,fadeCounter); //as this runs every fram, the counter runs down in value, which makes the cube more transparent.
			if (fadeCounter <= 0.01f){ //when the cube reaches a certain level of transparency, we don't want it to be more invisible.
				FadeOut = false; //and therefore we exchange the values of the bools, thereby setting off the other if statements.
				FadeIn = true;
				FadedTooManyTimes += 1; //and we add a one to the counter so we can keep track of the number of times the screen has faded in and out.
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

		if (BlackMyScreen == true && Movement2.GetAnimationOn() == true && PrivateBlackMyScreen == false) {
			renderer.material.color = new Color(0,0,0,1);
			fadeCounter ++;
			if (fadeCounter >= HowManyBlackFrames){
				renderer.material.color = new Color(0,0,0,0);
				PrivateBlackMyScreen = true;
				fadeCounter = 0;
				print ("stop this");
			}
		}
		if (GetReadyAgainBlackMyScreen == false){
			PrivateBlackMyScreen = false;
			GetReadyAgainBlackMyScreen = true;
			print ("get ready");
		}
		if (Sleeping == true) { //change this with the GUI dialogue script and the Choices script
			fadeCounter += 0.03f;
			renderer.material.color = new Color(0,0,0,fadeCounter); //the 1 stands for not being transparent at all
			if (fadeCounter >= 1){
				frameCounter ++;
				if (frameCounter >= 50){
					Subtitle05.SetActive(true);
					renderer.material.color = new Color(0,0,0,0); //while the 0 is totally transparent
					Sleeping = false;
					fadeCounter = 0;
					Movement2.SetChoiceScreenOn(false);
					fadeCounter = 0;
				}
			}
		}
		if (Movement2.GetSubtitleCounter() == 9){
			Ib.SetBallIsActive1(false);
			Movement2.SetCarlActive(true);
			Carl.SetActive(true);
		}
		if (Choices.GetChoice(3) == false && Choices.GetWasChoiceMade(3) && WeSaveCarl == false){
			renderer.material.color = new Color(0,0,0,1);
			WeSaveCarl = true;
		}
		if (WeHaveSavedCarl == true){
			renderer.material.color = new Color(0,0,0,0);
		}

		//renderer.material.color -= new Color(0,0,0,0.01f);//basically just telling the object, that the material to be rendered should be set to a new color.
		//that color then has it's alpha channel changed as the only thing.
	
	}

	void OnGUI(){
		if (WeSaveCarl == true && WeHaveSavedCarl == false){
			print ("Haj");
			GUI.Box (new Rect(Screen.width/2-300, Screen.height/2-300, 600, 600), "Hello your piece of shit");
			if (GUI.Button (new Rect(Screen.width/2-50, Screen.height-100, 100, 25), "Next")){
				WeHaveSavedCarl = true;
			}
		}
	}
}
