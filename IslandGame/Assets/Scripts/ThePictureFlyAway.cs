using UnityEngine;
using System.Collections;

//this script is to be placed on an object which the player cannot avoid walking into when trying to cross the stone path
//the object must be invisible, and have no mesh renderer component.

public class ThePictureFlyAway : MonoBehaviour {

	public GameObject ThePlayer; //we need to know that it is the player who is the trigger
	public GameObject ThePhoto; //we need a photo to spawn
	private float SPX; //Spawn point X
	private float SPY; //Y
	private float SPZ; //Z
	public GameObject InvisibleWall; //We need to disable the invisible wall as well.

	public static bool PhotoActive = false;

	public static bool GetPhotoActive(){return PhotoActive;}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		SPX = Movement2.GetPlayerX(); //the picture needs to be spawned close to the player.
		SPY = Movement2.GetPlayerY(); //There fore the player coordinates are the base of the spawn point.
		SPZ = Movement2.GetPlayerZ();
	}
	void OnTriggerEnter(Collider ThePlayer) {//this function runs when the an object named ThePlayer collides with the object which this script is palced upon.

		Destroy(gameObject); //destroying the trigger object so we don't suddenly get multiple pictures

		GameObject.Instantiate(ThePhoto, new Vector3(SPX -= 1243.6f,SPY -= 35.7f,SPZ -= 1438.7f), transform.rotation); //spawn the photo!

		InvisibleWall.SetActive (false);//we need to allow the player to go in the water after loosing the picture.
		PhotoActive = true;

		BackPack2.SetHaveBackpack (false);
	}
}
