using UnityEngine;
using System.Collections;

public class TriggerNoBoat : MonoBehaviour {

	private static bool GoodbyeBoat = false;
	public static bool GetGoodbyeBoat (){return GoodbyeBoat;}

	public GameObject ThePlayer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider ThePlayer) {//this function runs when the an object named ThePlayer collides with the object which this script is palced upon.
		if (Choices.GetChoice(3) == false){
			Destroy(gameObject);
			GoodbyeBoat = true;
		}
		if (Choices.GetChoice(3) == true){
			Destroy(gameObject);
		}

	}
}
