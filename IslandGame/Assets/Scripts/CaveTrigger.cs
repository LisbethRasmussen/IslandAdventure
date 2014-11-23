using UnityEngine;
using System.Collections;

public class CaveTrigger : MonoBehaviour {
	
	private bool PlayerIsAtCave = false;
	private bool CarlIsAtCave = false;
	private static bool BothAreAtCave = false;

	public static bool GetBothAreAtCave(){return BothAreAtCave;}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerIsAtCave == true && CarlIsAtCave == true){
			BothAreAtCave = true;
			Destroy(gameObject);
			Ib.SetBallIsActive(true);
		}
	}
	void OnTriggerEnter(Collider other) {//this function runs when the an object named ThePlayer collides with the object which this script is palced upon.
		if (other.gameObject.name == "Player"){
			PlayerIsAtCave = true;
		}

		if (other.gameObject.name == "Carl"){
			CarlIsAtCave = true;
		}
	}
}
