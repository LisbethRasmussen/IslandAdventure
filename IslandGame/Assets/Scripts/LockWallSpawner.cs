using UnityEngine;
using System.Collections;
//place this script on any object on the island.
//Make invisible prefabs, which already have a Y-rotation fit to the place they are supposed to be placed.
//This script will block the player from going back when certain objectives have been completed.
public class LockWallSpawner : MonoBehaviour {

	private float DistanceX;
	private float DistanceZ;
	private float CarlDistanceX;
	private float CarlDistanceZ;

	public GameObject objectiveOne;
	/*public GameObject objectiveTwo;
	//public GameObject objectiveThree; //this and its followers is not needed, as these are set in the movement script.
	public GameObject objectiveFour;
	public GameObject objectiveFive;
	public GameObject objectiveSix;*/

	private bool objectiveOneB = false; //ultimately these values should be obtained from another script by the use of a getter.
	private bool objectiveTwoB = false; //they should be linked to the choice script.
	//private bool objectiveThreeB = false;
	private bool objectiveFourB = false;
	private bool objectiveFiveB = false;
	private bool objectiveSixB = false;

	// Use this for initialization
	void Start () {

		objectiveOne.SetActive (false);
		/*objectiveTwo.SetActive (false);
		//objectiveThree.SetActive (false);
		objectiveFour.SetActive (false);
		objectiveFive.SetActive (false);
		objectiveSix.SetActive (false);*/
	
	}
	
	// Update is called once per frame
	void Update () {

		DistanceX = Mathf.Abs (Movement2.GetPlayerX()); //setting the values to the player values. It is not really necessary, but it looks prettyer not writing mathf. abs constantly
		DistanceZ = Mathf.Abs (Movement2.GetPlayerZ());

		CarlDistanceX = Mathf.Abs (Ib.GetPosX ());
		CarlDistanceZ = Mathf.Abs (Ib.GetPosZ ());



		if (DistanceX <= 1197f && CarlDistanceX <= 1195f){
				objectiveOne.SetActive(true);
		}
		/*if (DistanceX >= 2 && DistanceZ >= 2){
			if (objectiveTwoB == true){
				GameObject.Instantiate(objectiveTwo, new Vector3(1f,0f,1f), transform.rotation);
			}
		}*/
		/*if (DistanceX >= 2 && DistanceZ >= 2){
			if (objectiveThreeB == true){
				GameObject.Instantiate(objectiveThree, new Vector3(1f,0f,1f), transform.rotation);
			}
		}*/
		/*if (DistanceX >= 2 && DistanceZ >= 2){
			if (objectiveFourB == true){
				GameObject.Instantiate(objectiveFour, new Vector3(1f,0f,1f), transform.rotation);
			}
		}
		if (DistanceX >= 2 && DistanceZ >= 2){
			if (objectiveFiveB == true){
				GameObject.Instantiate(objectiveFive, new Vector3(1f,0f,1f), transform.rotation);
			}
		}
		if (DistanceX >= 2 && DistanceZ >= 2){
			if (objectiveSixB == true){
				GameObject.Instantiate(objectiveSix, new Vector3(1f,0f,1f), transform.rotation);
			}
		}*/
	
	}
}
