using UnityEngine;
using System.Collections;

public class Shark : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt (GameObject.Find ("SharkBox").transform);	// Makes the Shark look towards the object named "SharkBox"
	}
}
