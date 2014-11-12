using UnityEngine;
using System.Collections;

public class Hook : MonoBehaviour {

	private static float PosX;	// The Hook's X position in origin (Z is below)
	private static float PosZ;
	public Vector3 WorldPos;	// The Hook's position in world space
	public GameObject myBox;	// Need a box to grab!

	public static float GetPosX(){
		return PosX;
	}
	public static float GetPosZ(){
		return PosZ;
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		WorldPos = transform.TransformPoint(Vector3.right * 0.16f);	// This transform the Hook's position from origion to world space, the 0.16f is for the scaling as this transformation do not affect how the object is scaled
		PosX = WorldPos.x;	// Sets this world position to overwrite the original origin position (X (Z is below))
		PosZ = WorldPos.z;

		if (Box.GetInRange() == true){			// If the hook is in range of the box:
			myBox.transform.parent = transform;	// Makes the hook become a parent of the box!
			myBox.rigidbody.useGravity = false;	// Gravitiy will be disabled to we can lift it up! Careful it can now float away D:
		}
	}
}
