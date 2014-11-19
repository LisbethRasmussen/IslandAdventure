using UnityEngine;
using System.Collections;

public class FireWood : MonoBehaviour {

	private float DistanceX;
	private float DistanceZ;
	private bool PersonalInRange = false;
	
	//recall, when something is declared static, it has one, and ONE alone, place in the memory of the computer. This means that
	//whatever happens to this value, it will OVERWRITE every single time the value is changed.
	
	
	
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
		if (Input.GetKey (KeyCode.E) && PersonalInRange == true){
			PickUpSound2.SetFireWoodPicked(true); //this value is used in the pickupsound script.
			Destroy (gameObject); //this destroys the game object on which this script is attached.
		}
		
	}
	void OnGUI() {
		if (PersonalInRange == true){
			GUI.Button (new Rect(480,350,250,100), "Press E to pick up");
		}
	}
}