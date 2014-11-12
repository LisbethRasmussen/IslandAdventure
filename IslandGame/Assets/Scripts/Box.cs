using UnityEngine;
using System.Collections;

public class Box : MonoBehaviour {

	private float DistanceX;
	private float DistanceZ;
	private static bool inRange = false;

	public static bool GetInRange(){
		return inRange;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.DistanceX = Mathf.Abs(transform.position.x - Hook.GetPosX());
		this.DistanceZ = Mathf.Abs(transform.position.z - Hook.GetPosZ());

		if (this.DistanceX <= 0.5f && this.DistanceZ <= 0.5f){
			inRange = true;
		}
		else{
			inRange = false;
		}

	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.name == "Island surface"){	// If the box hits the island's surface object then:
			gameObject.transform.parent = null;			// Releases the box from being the child of the hook!
			gameObject.rigidbody.useGravity = true;		// Gravity is restored on the box!
		}
	}
}
