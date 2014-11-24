using UnityEngine;
using System.Collections;

public class DeadGirl : MonoBehaviour {

	public GameObject TheDeadGirl;
	public GameObject Grave;

	private float PosX;
	private float PosZ;

	private float DistanceX;
	private float DistanceZ;

	private static bool DeadGirlInRange = false;
	public static bool GetDeadGirlInRange (){return DeadGirlInRange;}

	// Use this for initialization
	void Start () {
		Grave.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {

		PosX = transform.position.x;
		PosZ = transform.position.z;

		DistanceX = Mathf.Abs (Movement2.GetPlayerX () - PosX);
		DistanceZ = Mathf.Abs (Movement2.GetPlayerZ () - PosZ);

		if (DistanceX <= 4.0f && DistanceZ <= 4.0f && LetUsGoInvisible.GetGirlBuriedYet() == false){
			DeadGirlInRange = true;
		}

		if (Choices.GetWasChoiceMade(4) == true && Choices.GetChoice(4) == false){
			TheDeadGirl.SetActive(false);
			Grave.SetActive(true);
		}
	}
}
