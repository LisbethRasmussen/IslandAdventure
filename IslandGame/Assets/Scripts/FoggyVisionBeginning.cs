using UnityEngine;
using System.Collections;

public class FoggyVisionBeginning : MonoBehaviour {

	private Color FogColor;
	public static bool HasGameStarten = false; //need this to initialize the fog and to tell the other script about the water fog when to begin working.
	private bool Foggier = true; //bool for when the fog is to increase
	private bool LessFoggier = false; //bool for when the fog is to decrease
	private float FogIntensityCounter = 0; //need to have a variable storer which sets the intensity of the fog. Notice that fully fog is equal to 1, and no fog is equal to 0.

	private int fogVisionCounter = 0; //We only need this to occure some times before we want the effect to dissappear. So we need to know how many times it has been working.

	public static bool GetBeginningFog(){ //this sends the messages to the other fog script, telling that it dose not have to work when this is false.
		return HasGameStarten;
	}

	// Use this for initialization
	void Start () {
		FogColor = new Color (0.4f, 0.5f, 0.7f, 0.5f); //setting the fog color to gray
		FogColor.a = 0.0f;
		RenderSettings.fog = true; //basically stating that yes, we need to render the fog
		HasGameStarten = true;
	}
	
	// Update is called once per frame
	void Update () {




		if (HasGameStarten == true && Foggier == true){ //so, if the game has starten, and we need more fog
			FogIntensityCounter += 0.005f; //the fog will increase by this number every frame
			RenderSettings.fogDensity = FogIntensityCounter; //and the number will replace the intensity of the fog
			print (FogIntensityCounter); //I needed this for debug.
			if (FogIntensityCounter >= 0.5){ //so, when the fog has reached this level of intensity, we don't want any more of it.
				Foggier = false; //therefore this is set to false so the if statement stops working.
				LessFoggier = true; //and set this to true, so the other one begins working.
				fogVisionCounter += 1; //and now we have run this 1 time, which is added to our counter, which is to check how many times we do this.
			}
		}

		if (HasGameStarten == true && LessFoggier == true){ //same as the above, but less foggier instead.
			FogIntensityCounter -= 0.005f;
			RenderSettings.fogDensity = FogIntensityCounter;
			print (FogIntensityCounter);
			if (FogIntensityCounter <= 0.03){
				LessFoggier = false;
				Foggier = true;
				fogVisionCounter += 1;
			}
		}

		if (fogVisionCounter == 5){ //when we have run the if statements above 5 times (not each, but as a total)
			HasGameStarten = false; //we set this to false, meaning that the above if statements are not true, and can therefore not work.
		}//also this sends the message to the other fog script, which makes it work.
	}
}

