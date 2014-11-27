using UnityEngine;
using System.Collections;

public class BotSailsOff : MonoBehaviour {

	public GameObject StandingGuy1;
	public GameObject SittingGuy1;

	public GameObject BeachGuyBlack;
	public GameObject BeachGuyWhite;

	// Use this for initialization
	void Start () {
		StandingGuy1.SetActive (false);
		SittingGuy1.SetActive (false);
	
	}
	
	// Update is called once per frame
	void Update () {

		if (TriggerNoBoat.GetGoodbyeBoat() == true){
			transform.position += new Vector3 (1,0,0);
			BeachGuyBlack.SetActive(false);
			BeachGuyWhite.SetActive(false);

			StandingGuy1.SetActive(true);
			SittingGuy1.SetActive(false);
		}

	}
}
