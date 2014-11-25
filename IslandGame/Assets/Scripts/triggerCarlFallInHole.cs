using UnityEngine;
using System.Collections;

public class triggerCarlFallInHole : MonoBehaviour {

	public GameObject ThePlayer;
	public GameObject DissaperaingTerrain;

	private static bool CarlHasFallen = false;
	public static bool GetCarlHasFallen(){return CarlHasFallen;}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider ThePlayer) {//this function runs when the an object named ThePlayer collides with the object which this script is palced upon.
		CarlHasFallen = true;
		DissaperaingTerrain.SetActive (false);
		Destroy(gameObject); //destroying the trigger object so we don't suddenly get multiple pictures
		Choices.SetChoiceNumber(6);
	}
}
