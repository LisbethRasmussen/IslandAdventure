using UnityEngine;
using System.Collections;

public class CampFireScript : MonoBehaviour {

	private float DistanceX;
	private float DistanceZ;
	private bool PersonalInRange = false;

	private static int FedXtimes = 0;

	public static int GetFedXtimes(){return FedXtimes;}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		DistanceX = Mathf.Abs (transform.position.x) - Mathf.Abs (Movement2.GetPlayerX());
		DistanceZ = Mathf.Abs (transform.position.z) - Mathf.Abs (Movement2.GetPlayerZ());

		if (DistanceX <= 2 && DistanceZ <= 2 && DistanceX >= -2 && DistanceZ >= -2){
			PersonalInRange = true;
		}
		else{
			PersonalInRange = false;
		}
		if (PersonalInRange == true && Movement2.GetFireWood() >= 1 && Input.GetKey(KeyCode.R)){
			Movement2.SetFireWood(Movement2.GetFireWood() - 1);
			FedXtimes ++;
		}
	
	}
	void OnGUI() {
		if (PersonalInRange == true && Movement2.GetFireWood() >=1f && Movement2.GetGatherFireWood() == true){
			GUI.Button (new Rect(480,350,250,100), "Press R to feed the fire");
		}
	}
}
