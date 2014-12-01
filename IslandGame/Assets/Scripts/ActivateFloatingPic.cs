using UnityEngine;
using System.Collections;

public class ActivateFloatingPic : MonoBehaviour {

	public GameObject ThePhoto;

	private static bool BeActive = false;
	public static void SetBeActive(bool x){BeActive = x;}

	// Use this for initialization
	void Start () {

		ThePhoto.SetActive (false);
	
	}
	
	// Update is called once per frame
	void Update () {

		if (BeActive == true){
			ThePhoto.SetActive(true);
		}
	
	}
}
