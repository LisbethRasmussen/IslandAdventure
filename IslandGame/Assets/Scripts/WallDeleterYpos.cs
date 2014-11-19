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

		if (Ypos <= 22.0f){
			Destroy(gameObject);
		}
		if (Choices.GetChoice(1) == false){
			Destroy(gameObject);
		}
	
	}
}
