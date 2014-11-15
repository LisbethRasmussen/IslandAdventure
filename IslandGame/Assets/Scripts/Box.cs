using UnityEngine;
using System.Collections;

public class Box : MonoBehaviour {

	private float DistanceX;
	private float DistanceZ;
	private float DistanceY;
	private static bool inRange = false;
	private bool PrivateInRange = false;

	public static bool GetInRange(){
		return inRange;
	}
	public static void SetInRange(bool x){
		inRange = x;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//this.DistanceX = Mathf.Abs(transform.position.x - Hook.GetPosX());
		//this.DistanceZ = Mathf.Abs(transform.position.z - Hook.GetPosZ());

		DistanceX = Mathf.Abs(transform.position.x - Hook.GetPosX());
		DistanceZ = Mathf.Abs(transform.position.z - Hook.GetPosZ());
		DistanceY = Mathf.Abs(transform.position.y - Hook.GetPosY());

		if (DistanceX <= 0.5f && DistanceZ <= 0.5f && DistanceY <= 0.5f){
			inRange = true;
			PrivateInRange = true;
		}
		if (PrivateInRange == true){
			gameObject.SetActive(false);
		}

	}

	/*void OnCollisionEnter(Collision other){
		if (other.gameObject.name == "Island surface"){	// If the box hits the island's surface object then:
			gameObject.transform.parent = null;			// Releases the box from being the child of the hook!
			gameObject.rigidbody.useGravity = true;		// Gravity is restored on the box!
		}
	}*/
}
