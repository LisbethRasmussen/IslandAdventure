using UnityEngine;
using System.Collections;

//Important notes: First of all, one needs to create a gameobject->other->guitexture and pull it on the game screen.
//It is vital that "background" textures have their Z value set to 0, this is done in the inspector of the guiobject
//other stuff should have their Z value set to 1 for them to appear "above" the background. Otherwise the chances are that it spawns like a phailwhale.

//this script is to be put on the player (not that it really matter where it is put), and the guiobjects on the scene
//needs to be applied in the inspector of the player object.

//note that the coordinates of the guiobjects' inspector are to be THE SAME FOR ALL, only with the variance of the Z value.
//This makes it easier to set the coordinates in here, as these script-coords are added/substracted from the coords in the inspector.

//the coordinates in unity for GUI is the same as a 2D x,y coordinate system, meaning that point 0,0 is in the lower left corner.
//It is always the bottom left corner of the image which is placed in the coords descriped.

public class Conversations : MonoBehaviour {

	private float DistanceX;
	private float DistanceZ;
	private bool DecisionToBeMade;
	private float lengthOfBar = 300;

	public GUITexture barBACK;
	public GUITexture barFRONT;

	public GUITexture DialougeBackground; //the guiobject holding the picture for this needs to be added in the inspector.

	public GUITexture PlayerFaceHappy;//obviously more variables are needed for the facial expressions.

	public GUITexture NPCFaceHappy;

	// Use this for initialization
	void Start () {
		
		DialougeBackground.pixelInset = new Rect (0,0, 600, 600);//size to be changed accordingly to the correct pictures to be used.

		PlayerFaceHappy.pixelInset = new Rect (20, 100, 100, 100); //(x,y,width,Heigth)

		NPCFaceHappy.pixelInset = new Rect (20, 450, 100, 100);

		barBACK.enabled = false;
		barFRONT.enabled = false;
		
	}
	
	// Update is called once per frame
	void Update () {

		DistanceX = Mathf.Abs (Movement2.GetPlayerX());
		DistanceZ = Mathf.Abs (Movement2.GetPlayerZ());

		//the if functions should also check for other circumstances
		if (DistanceX >= 10 && DistanceX <=25 && DistanceZ >= 10 && DistanceZ <=25){//values needs to be changed for where the dialouge is to be had.
			DialougeBackground.enabled = true;
			PlayerFaceHappy.enabled = true;
			NPCFaceHappy.enabled = true;

			DecisionToBeMade = true; //this is a place holder. This particular code needs to be places somewhere else.
		}
		else{//this else function should be filled with all the pictures which are to be displayed through if statements.
			DialougeBackground.enabled = false;
			PlayerFaceHappy.enabled = false;
			NPCFaceHappy.enabled = false;
		}

		if (DecisionToBeMade == true){

			lengthOfBar-=0.3f;

			barBACK.enabled = true;
			barFRONT.enabled = true;

			barBACK.pixelInset = new Rect (300, 300, 320, 40);
			barFRONT.pixelInset = new Rect (310, 310, lengthOfBar, 20);

			if (lengthOfBar <= 0.1){
				barBACK.enabled = false;
				barFRONT.enabled = false;
				lengthOfBar = 300;
				DecisionToBeMade = false;
			}
		}
	
	}
}
