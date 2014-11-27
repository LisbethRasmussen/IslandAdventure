using UnityEngine;
using System.Collections;

public class BoatTrigger : MonoBehaviour {

	private float DistanceX;
	private float DistanceZ;

	private static bool BoatInRange = false;
	public static bool GetBoatInRange(){return BoatInRange;}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		DistanceX = Mathf.Abs ((Movement2.GetPlayerX()) - (transform.position.x));
		DistanceZ = Mathf.Abs ((Movement2.GetPlayerZ()) - (transform.position.z));

		if (DistanceX <= 35 && DistanceZ <= 35){
			BoatInRange = true;
		}
		else{
			BoatInRange = false;
		}
	
	}
}
