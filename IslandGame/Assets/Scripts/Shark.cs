using UnityEngine;
using System.Collections;

public class Shark : MonoBehaviour {

	private float sharkDistanceX; //distance from bait to shark
	private float safeRange = 1.0f;
	private static float sharkPosX;

	void Update () {
		sharkPosX = transform.position.x;

		sharkDistanceX = Mathf.Abs(sharkPosX - SharkBait.GetBaitX());

		transform.LookAt (GameObject.Find ("SharkBox").transform);	// Makes the Shark look towards the object named "SharkBox"

		if (sharkDistanceX >= safeRange){
			transform.position += transform.forward * 10 * Time.deltaTime;
		}

	}
}
