using UnityEngine;
using System.Collections;

public class LetUsDrink : MonoBehaviour {

	private float PlayerDistanceX;
	private float PlayerDistanceY;
	private float PlayerDistanceZ;

	private bool PersonalInRange = false;
	private static bool Drink = false;
	private static bool DoneDrinking = false;

	public static bool GetDrink (){
		return Drink;
	}
	public static void SetDrink (bool x){
		Drink = x;
	}
	public static void SetDoneDrinking (bool x){
		DoneDrinking = x;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		PlayerDistanceX = Mathf.Abs (transform.position.x) - Mathf.Abs (Movement2.GetPlayerX());
		PlayerDistanceY = Mathf.Abs (transform.position.y) - Mathf.Abs (Movement2.GetPlayerY());
		PlayerDistanceZ = Mathf.Abs (transform.position.z) - Mathf.Abs (Movement2.GetPlayerZ());

		if (PlayerDistanceX <= 16 && PlayerDistanceZ <= 16){
			PersonalInRange = true;
			Drink = true;
		}
		if (DoneDrinking == true){
			Destroy(gameObject);
		}
	
	}
	void OnGUI() {
		if (PersonalInRange == true){
			GUI.Button (new Rect(480,350,250,100), "Press E to drink");
		}
	}
}
