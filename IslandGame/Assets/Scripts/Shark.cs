using UnityEngine;
using System.Collections;

public class Shark : MonoBehaviour {

	private float sharkDistanceX; //distance from bait to shark
	private float safeRange = 1.0f;
	private static float sharkPosX;
	public int sharkBaitNumber;

	void Update () {
		sharkPosX = transform.position.x;

		if(sharkBaitNumber == 1){
			transform.LookAt (GameObject.Find ("SharkBait1").transform);	// Makes the Shark look towards the object named "SharkBox"
			sharkDistanceX = Mathf.Abs(sharkPosX - SharkBait1.GetBaitX());
		}

		if (sharkBaitNumber == 2) {
			transform.LookAt (GameObject.Find ("SharkBait2").transform);
			sharkDistanceX = Mathf.Abs(sharkPosX - SharkBait2.GetBaitX());
		}

		if (sharkBaitNumber == 3) {
			transform.LookAt (GameObject.Find ("SharkBait3").transform);
			sharkDistanceX = Mathf.Abs(sharkPosX - SharkBait3.GetBaitX());
		}

		if (sharkBaitNumber == 4) {
			transform.LookAt (GameObject.Find ("SharkBait4").transform);
			sharkDistanceX = Mathf.Abs(sharkPosX - SharkBait4.GetBaitX());
		}

		if (sharkBaitNumber == 5) {
			transform.LookAt (GameObject.Find ("SharkBait5").transform);
			sharkDistanceX = Mathf.Abs(sharkPosX - SharkBait5.GetBaitX());
		}

		if (sharkBaitNumber == 6) {
			transform.LookAt (GameObject.Find ("SharkBait6").transform);
			sharkDistanceX = Mathf.Abs(sharkPosX - SharkBait6.GetBaitX());
		}

		if (sharkDistanceX >= safeRange){
			transform.position += transform.forward * 10 * Time.deltaTime;
		}

	}
}
