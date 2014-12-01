using UnityEngine;
using System.Collections;

public class SoundInverterFromTo : MonoBehaviour {

	public GameObject object1;
	public GameObject object2;
	public GameObject object3;

	public GameObject object4;
	public GameObject object5;
	public GameObject object6;

	private static float PosX1;
	private static float PosZ1;

	private static float PosX2;
	private static float PosZ2;

	private static float PosX3;
	private static float PosZ3;

	private static float PosX4;
	private static float PosZ4;

	private static float PosX5;
	private static float PosZ5;

	private static float PosX6;
	private static float PosZ6;

	public static float GetPosX1(){return PosX1;}
	public static float GetPosZ1(){return PosZ1;}

	public static float GetPosX2(){return PosX2;}
	public static float GetPosZ2(){return PosZ2;}

	public static float GetPosX3(){return PosX3;}
	public static float GetPosZ3(){return PosZ3;}

	public static float GetPosX4(){return PosX4;}
	public static float GetPosZ4(){return PosZ4;}

	public static float GetPosX5(){return PosX5;}
	public static float GetPosZ5(){return PosZ5;}

	public static float GetPosX6(){return PosX6;}
	public static float GetPosZ6(){return PosZ6;}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		PosX1 = object1.transform.position.x;
		PosZ1 = object1.transform.position.z;

		PosX2 = object2.transform.position.x;
		PosZ2 = object2.transform.position.z;

		PosX3 = object3.transform.position.x;
		PosZ3 = object3.transform.position.z;

		PosX4 = object4.transform.position.x;
		PosZ4 = object4.transform.position.z;

		PosX5 = object5.transform.position.x;
		PosZ5 = object5.transform.position.z;

		PosX6 = object6.transform.position.x;
		PosZ6 = object6.transform.position.z;
	
	}
}
