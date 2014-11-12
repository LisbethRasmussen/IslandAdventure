using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private static float playerPosX;	// Ib's X position in world space (Z is below)
	private static float playerPosZ;
	public GameObject myStick;			// I need mah stick!

	public static float GetPlayerX () {
		return playerPosX;
	}
	
	public static float GetPlayerZ () {
		return playerPosZ;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		playerPosX = transform.position.x;
		playerPosZ = transform.position.z;

		if (Input.GetKey(KeyCode.T) && myStick.activeSelf == true){	// ".activeSelf" checks if the object is active or not
			myStick.transform.Rotate(Vector3.left * 20 * Time.deltaTime);	// Makes the stick rotate up! don't ask why it is .left and not .up
		}
		if (Input.GetKey(KeyCode.G) && myStick.activeSelf == true){
			myStick.transform.Rotate(Vector3.right * 20 * Time.deltaTime);	// Makes the stick rotate down! don't ask why it is .right and not .down
		}

		if (Input.GetKey(KeyCode.O)){
			myStick.SetActive(false);	// This deactivates the stick! Making it disappear form the scene and makes it inaffective (but it still "follows" he player's position)
		}
		if (Input.GetKey(KeyCode.P)){
			myStick.SetActive(true);	// Same as before just with activating it!
		}


	}
}
