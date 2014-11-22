using UnityEngine;
using System.Collections;

public class WallDeleterYpos : MonoBehaviour {

	private float Ypos;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Ypos = Movement2.GetPlayerY();


		if (Choices.GetWasChoiceMade(2) == true){
			if (Choices.GetChoice(2) == true && Ypos <= 21f){
				Movement2.SetAnimationOn(true);
				AnimationsOnOff.SetJumpInWater(true);
				Destroy(gameObject);
				Movement2.SetAnimationCounter(4);
			}
		}
		if (Choices.GetWasChoiceMade(2) == true){
			if (Choices.GetChoice(2) == false){
				Destroy(gameObject);
			}
		}
	
	}
}
