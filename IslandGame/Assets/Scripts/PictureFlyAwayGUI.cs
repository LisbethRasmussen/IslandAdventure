using UnityEngine;
using System.Collections;

public class PictureFlyAwayGUI : MonoBehaviour {

	public GameObject Carl;
	private bool GUION = false;
	private bool triggerOnce = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		print(Movement2.GetPlayerX());
		if (Movement2.GetPlayerX() < 1230 && triggerOnce == false){
			GUION = true;
			Carl.SetActive(false);
			Movement2.SetDoNotMove(true);
		}
	}

	void OnGUI() {
		if (GUION == true && triggerOnce == false){
			GUI.Box (new Rect (Screen.width/2-100, Screen.height/2-100, 200, 200), "A strong gust rips the photo\nof your daughter away from you\nand slowly floats over to the ocean.");
			if (GUI.Button (new Rect (Screen.width/2-50, Screen.height/2+100, 100, 25), "Next")){
				Choices.SetDecisionToBeMade(true);
				Choices.SetChoiceNumber(2);
				triggerOnce = true;
			}
		}
	}

}
