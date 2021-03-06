﻿using UnityEngine;
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

	private static bool LastConversationWithBoatman = false;
	public static bool GetLastConversationWithBoatman(){return LastConversationWithBoatman;}

	private float WeLoveCounters = 0;
	private static bool YouEndAllAloneScreen = false;

	private bool RunOnce = false;
	private bool RunOnce3 = false;
	private bool RunOnce4 = false;
	private bool RunOnce5 = false;
	private bool RunOnce6 = false;
	private bool RunOnce7 = false;
	private bool RunOnce8 = false;

	private float PlayerTrackerX;
	private float PlayerTrackerZ;
	private bool LookDownTheHole = false;

	private static bool WeDidNotSaveCarl = false;
	private static bool CarlHasCookedHisFood = false;
	public static void SetWeDidNotSaveCarl(bool x){WeDidNotSaveCarl = x;}
	public static bool GetCarlHasCookedHisFood(){return CarlHasCookedHisFood;}
	private static bool WeSaveCarl = false;
	public static bool GetWeSaveCarl(){return WeSaveCarl;}
	private static bool WeHaveSavedCarl = false;
	public static bool GetWeHaveSavedCarl(){return WeHaveSavedCarl;}
	public static void SetWeHaveSavedCarl(bool x){WeHaveSavedCarl = x;}
	public GameObject Carl;
	private static bool WePullCarlUpNow = false;
	public static void SetWePullCarlUpNow (bool x){WePullCarlUpNow = x;}

	private bool FadeOut = true; //we need two different kinds of states on the cube. One where it gets lighter
	private bool FadeIn = false; //and one where it gets darker.
	public static bool HasGameStarted = false; //this may need to be deleted accoring to what the bool on the starting script does.
	private float fadeCounter = 1;
	private float frameCounter = 0;
	private bool SleepNow = false;
	public GameObject Subtitle05;
	public GameObject Subtitle071;
	public GameObject Subtitle081;
	public GameObject Subtitle091;

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

	private static bool GirlBuriedYet = false;
	public static bool GetGirlBuriedYet(){return GirlBuriedYet;}
	private bool RunOnce2 = false;

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

		PlayerTrackerX = Movement2.GetPlayerX ();
		PlayerTrackerZ = Movement2.GetPlayerZ ();

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
			}
		}
		if (GetReadyAgainBlackMyScreen == false){
			PrivateBlackMyScreen = false;
			GetReadyAgainBlackMyScreen = true;
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
		if (Movement2.GetSubtitleCounter() == 11){
			Ib.SetBallIsActive1(false);
			Movement2.SetCarlActive(true);
			Carl.SetActive(true);
		}
		if (Choices.GetChoice(3) == false && Choices.GetWasChoiceMade(3) && WeSaveCarl == false){
			renderer.material.color = new Color(0,0,0,1);
			WeSaveCarl = true;
		}
		if (WeHaveSavedCarl == true && RunOnce == false){
			renderer.material.color = new Color(0,0,0,0);
			RunOnce = true;
		}
		if (WeDidNotSaveCarl == true && RunOnce == false){
			renderer.material.color = new Color(0,0,0,1);
			if (CarlHasCookedHisFood == true){
				renderer.material.color = new Color(0,0,0,0);
				RunOnce = true;
				Movement2.SetGoFaster(true);
			}
		}
		if (Choices.GetWasChoiceMade(4) == true && Choices.GetChoice(4) == false && GirlBuriedYet == false){
			renderer.material.color = new Color(0,0,0,1);
			Movement2.SetDoNotMove (true);
		}
		if (GirlBuriedYet == true && RunOnce2 == false){
			renderer.material.color = new Color(0,0,0,0);
			Movement2.SetDoNotMove (false);
			Choices.SetDecisionToBeMade(false);
			if (Choices.GetChoice(3) == true){
				Movement2.SetGoFaster(true);
				RunOnce2 = true;
			}
			if (Choices.GetChoice(3) == false){
				Movement2.SetLegBroken(true);
				RunOnce2 = true;
			}
		}
		if (Choices.GetWasChoiceMade(5) == true){
			Subtitle081.SetActive(true);
		}
		if (PlayerTrackerX >= 1036 && PlayerTrackerX <= 1075 && PlayerTrackerZ >= 735 && PlayerTrackerZ <= 740){
			LookDownTheHole = true;
		}
		/*if (DustExplotion2.GetTheFirstDustCloudeIsSeen() == true && RunOnce6 == false && LookDownTheHole == true){
			renderer.material.color = new Color(0,0,0,1);
			Movement2.SetDoNotMove (true);
		}*/
		if (triggerCarlFallInHole.GetCarlHasFallen() == true && RunOnce3 == false){
			renderer.material.color = new Color(0,0,0,1);
			Movement2.SetDoNotMove (true);
		}
		//---------------------------------------------------------------------------------------
		if (GUIDialogue.GetConversation15Done() == true && RunOnce5 == false){
			renderer.material.color = new Color(0,0,0,1);
			Movement2.SetDoNotMove (true);
		}
		if (GUIDialogue.GetConversation16Done() == true && RunOnce7 == false) {
			renderer.material.color = new Color(0,0,0,1);
			Movement2.SetDoNotMove (true);
		}
		//------------------------------------------------------------------------------------------
		if (WePullCarlUpNow == true && RunOnce4 == false){
			renderer.material.color = new Color(0,0,0,1);
			Movement2.SetDoNotMove (true);
		}
		if (TriggerNoBoat.GetGoodbyeBoat() == true && RunOnce8 == false && YouEndAllAloneScreen == false){
			WeLoveCounters++;
			if (WeLoveCounters >= 300){
				YouEndAllAloneScreen = true;
				WeLoveCounters = 0;
			}
		}
		if (YouEndAllAloneScreen == true && RunOnce8 == false){
			renderer.material.color = new Color(0,0,0,1);
			Movement2.SetDoNotMove (true);
		}

		//renderer.material.color -= new Color(0,0,0,0.01f);//basically just telling the object, that the material to be rendered should be set to a new color.
		//that color then has it's alpha channel changed as the only thing.
	
	}

	void OnGUI(){
		if (WeSaveCarl == true && WeHaveSavedCarl == false){
			GUI.Box (new Rect(Screen.width/2-300, Screen.height/2-300, 600, 600),

			         "\n\n\n\n"
			         + "You go out to look for Carl and move down the path in which he disappeared."
			         + "\n"
			         + "Moving forward the sounds of a fight reaches your ear and around the corner"
			         + "\n"
			         + "of the next cliff Carl is seen fighting a young wild boar. HELP ME, shouts"
			         + "\n"
			         + "Carl and you rush in to get the boar away. Disturbed by your presence the"
			         + "\n"
			         + "wild boar charges towards you instead, leaving Carl unharmed. The boar slams"
			         + "\n"
			         + "into your leg, throwing you on your back. Meanwhile Carl is now on his feet,"
			         + "\n"
			         + "rushing in with the hooked stick and slams the hook down in the head of the boar."
			         + "\n"
			         + "Rageing, Carl keeps slamming the boars head untill the beast stops moving."
			         + "\n\n"
			         + "You congratulate each other for surviving the beast's attack and head back"
			         + "\n"
			         + "to the cave, where you sleep untill morning."

			         );
			Carl.SetActive(true);
			if (GUI.Button (new Rect(Screen.width/2-50, Screen.height-100, 100, 25), "Next")){
				WeHaveSavedCarl = true;
				Movement2.SetLegBroken(true); //may not even need this here, as I've set so many if'ies in the GUIDialogue script.
				Movement2.SetProceedFromTheCave(true);
				GUIDialogue.SetDialogueON(false);
				Movement2.SetDoNotMove(false);
				Movement2.SetChoiceScreenOn(false);
				Movement2.SetAnimationOn(false);
				Ib.SetBallIsActive1(false);
				Movement2.SetCarlActive(true);

			}
		}
		if (WeDidNotSaveCarl == true && CarlHasCookedHisFood == false){
			GUI.Box (new Rect(Screen.width/2-300, Screen.height/2-300, 600, 600),
			         "\n\n\n\n"
			         + "Carl cooks the small animal he found and eats it all by himself,"
			         + "not leaving anything for you!");
			if (GUI.Button (new Rect(Screen.width/2-50, Screen.height-100, 100, 25), "Next")){
				CarlHasCookedHisFood = true;
				Movement2.SetDoNotMove(false);
				Movement2.SetChoiceScreenOn(false);
				Movement2.SetAnimationOn(false);
				Movement2.SetGoFaster(true);
			}
		}
		if (Choices.GetWasChoiceMade(4) == true && Choices.GetChoice(4) == false && Choices.GetChoice(3) == true && GirlBuriedYet == false){
			GUI.Box (new Rect(Screen.width/2-300, Screen.height/2-300, 600, 600),
			         "\n\n\n\n"
			         + "You manage to dig a hole which is almost 1 meter deep and put the girl in."
			         + "\n"
			         + "Carl dos nothing to help you and wathces while you push the sandpil in the hole."
			         + "\n"
			         + "For a moment you stand still and glance over the sand grave.");
			if (GUI.Button (new Rect(Screen.width/2-50, Screen.height-100, 100, 25), "Next")){
				GirlBuriedYet = true;
				Subtitle071.SetActive(true);
			}
		}
		if (Choices.GetWasChoiceMade(4) == true && Choices.GetChoice(4) == false && Choices.GetChoice(3) == false && GirlBuriedYet == false){
			GUI.Box (new Rect(Screen.width/2-300, Screen.height/2-300, 600, 600),
			         "\n\n\n\n"
			         + "Together you manage to dig a hole about 1 meter deep and put the girl in."
			         + "\n"
			         + "It is easy to pushe the sand over the girl and afterwards you stand still"
			         + "\n"
			         + "while you wathces the grave for a bit.");
			if (GUI.Button (new Rect(Screen.width/2-50, Screen.height-100, 100, 25), "Next")){
				GirlBuriedYet = true;
				Subtitle071.SetActive(true);
			}
		}
		//----------------------------------------------------------------------------------
		/*if (DustExplotion2.GetTheFirstDustCloudeIsSeen() == true && RunOnce6 == false && LookDownTheHole == true){
			GUI.Box (new Rect(Screen.width/2-300, Screen.height/2-300, 600, 600),
			         "\n\n\n\n"
			         + "When the dust cloude has settle you and Carl go over to look at the newly appeared hole."
			         + "\n"
			         + "It's almost too dark to see down the hole, but it appears that there is a form of cave system"
			         + "\n"
			         + "down there. The noise of hisses aproach you as you lean in over the hole."
			         + "\n"
			         + "Carl, apparently having a better vision says that he spots snakes in the hole."
			         + "\n"
			         + "You both figure that it would be best to stay away from the holes and be carefull when"
			         + "\n"
			         + "proceeding onward as it appears that the ground you walk on is somewhat fragile.");
			if (GUI.Button (new Rect(Screen.width/2-50, Screen.height-100, 100, 25), "Next")){
				renderer.material.color = new Color(0,0,0,0);
				Movement2.SetDoNotMove (false);
				RunOnce6 = true;
			}
		}*/
		//----------------------------------------------------------------------------------

		if (triggerCarlFallInHole.GetCarlHasFallen() == true && RunOnce3 == false){
			GUI.Box (new Rect(Screen.width/2-300, Screen.height/2-300, 600, 600),
			         "\n\n\n\n"
			         + "You hear a loud crahs and Carl screaming as he falls down a sinkhole behind you"
			         + "\n"
			         + "The snakes which most likely are down in the hole could attack Carl at any moment."
			         + "\n"
			         + "But the boat on the beach might also be about to sail and leave you behind.");
			if (GUI.Button (new Rect(Screen.width/2-50, Screen.height-100, 100, 25), "Next")){
				RunOnce3 = true;
				renderer.material.color = new Color(0,0,0,0);
				Choices.SetDecisionToBeMade(true);
				Movement2.SetDoNotMove(false);
				if (Choices.GetChoice(3) == true){
					Movement2.SetGoFaster(true);
				}
				if (Choices.GetChoice(3) == false){
					Movement2.SetGoNormal(true);
					Subtitle091.SetActive(true);
				}
			}

		}
		//-----------------------------------------------------------------------------
		if (GUIDialogue.GetConversation15Done() == true && RunOnce5 == false){
			print ("Hello Unity!");
			GUI.Box (new Rect(Screen.width/2-300, Screen.height/2-300, 600, 600),
			         "\n\n\n\n"
			         + "The two men from the boat go over to help Carl at the sinkhole. You stay by the boat"
			         + "\n"
			         + "and whatch them as they go. At the hole it appears that one of the men is shaking his"
			         + "\n"
			         + "head as he looks down the hole. The other one shouts CARL! down the hole."
			         + "\n"
			         + "They appears to give up after a while and go back towards you."
			         );
			if (GUI.Button (new Rect(Screen.width/2-50, Screen.height-100, 100, 25), "Next")){
				renderer.material.color = new Color(0,0,0,0);
				RunOnce5 = true;
				LastConversationWithBoatman = true;
			}
		}
		//------------------------------------------------------------------------------
		if (WePullCarlUpNow == true && RunOnce4 == false){
			GUI.Box (new Rect(Screen.width/2-300, Screen.height/2-300, 600, 600),
			         "\n\n\n\n"
			         + "You Pull Carl Up with all you strength. As you turn around to get to the boat"
			         +"\n"
			         +" you see that it is sailing away from the island."
			         +"\n"
			         +" You are never going to leave the island and are stuck with Carl for the rest of your life."
			         +"\n\n\n"
			         +"Thank you for playing! Now please get hold of us so we can give you a questionnaire :)");
		}
		if (GUIDialogue.GetConversation16Done() == true && RunOnce7 == false){
			GUI.Box (new Rect(Screen.width/2-300, Screen.height/2-300, 600, 600),
			         "\n\n\n\n"
			         + "You leave the island with the men in the boat and return to the mainland at last."
			         +"\n"
			         +"A search and rescue party was send out to the island as fast as possible, but it was of"
			         +"\n"
			         +"no effort. There were no more living castaway people on the island."
			         +"\n\n\n"
			         +"Thank you for playing! Now please get hold of us so we can give you a questionnaire :)");
		}
		if (YouEndAllAloneScreen == true && RunOnce8 == false){
			GUI.Box (new Rect(Screen.width/2-300, Screen.height/2-300, 600, 600),
			         "\n\n\n\n"
			         + "You soon loose the boat off sight in the distance. It is clear that they are not be"
			         +"\n"
			         +"Able to hear you. You hurry back to Carl to see what has become of him. Down in the"
			         +"\n"
			         +"hole you spot Carl lying all still with several snakes moving around him. You call out"
			         +"\n"
			         +"His name, but you soon realizes that he is already dead. If were from the fall or the"
			         +"\n"
			         +"snake is unknown to you. You are now stuck on the island alone forever."
					 +"\n\n\n"
			         +"Thank you for playing! Now please get hold of us so we can give you a questionnaire :)");
		}
	}
}
