using UnityEngine;
using System.Collections;

public class Letusdrink2 : MonoBehaviour {
	
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
		
		PlayerDistanceX = Mathf.Abs ((Movement2.GetPlayerX()) - (transform.position.x));
		PlayerDistanceY = Mathf.Abs ((Movement2.GetPlayerY()) - (transform.position.y));
		PlayerDistanceZ = Mathf.Abs ((Movement2.GetPlayerZ()) - (transform.position.z));
		
		if (PlayerDistanceX <= 16 && PlayerDistanceZ <= 16){
			PersonalInRange = true;
			Drink = true;
		}
		if (DoneDrinking == true){
			Destroy(gameObject);
			Drink = false;
		}
		
	}
	void OnGUI() {
		if (PersonalInRange == true){
			GUI.Button (new Rect(480,350,250,100), "Press E to drink");
		}
	}
}