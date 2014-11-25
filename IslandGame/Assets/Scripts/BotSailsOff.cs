using UnityEngine;
using System.Collections;

public class BotSailsOff : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (TriggerNoBoat.GetGoodbyeBoat() == true){
			transform.position += new Vector3 (1,0,0);
		}

	}
}
