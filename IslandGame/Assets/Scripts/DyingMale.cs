using UnityEngine;
using System.Collections;

public class DyingMale : MonoBehaviour {

	public GameObject SittingMale;
	public GameObject LyingMale;

	private float PlayerDistanceX;
	private float PlayerDistanceY;
	private float PlayerDistanceZ;

	private static bool CloseEnoughToDyingMale = false;
	public static bool GetCloseEnoughToDyingMale (){return CloseEnoughToDyingMale;}

	// Use this for initialization
	void Start () {
		LyingMale.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {

		PlayerDistanceX = Mathf.Abs ((Movement2.GetPlayerX()) - (transform.position.x));
		PlayerDistanceY = Mathf.Abs ((Movement2.GetPlayerY()) - (transform.position.y));
		PlayerDistanceZ = Mathf.Abs ((Movement2.GetPlayerZ()) - (transform.position.z));

		if (PlayerDistanceX <= 7 && PlayerDistanceZ <= 7) {
			CloseEnoughToDyingMale = true;
		}
		if (PlayerDistanceX >= 14 && PlayerDistanceZ >= 14 && Choices.GetWasChoiceMade(5) == true){
			SittingMale.SetActive(false);
			LyingMale.SetActive(true);
		}
	
	}
}
