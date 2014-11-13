using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {

	public float myValue = 100;//test
	
	public static float Speed = 100.0f;
	
	public static float GetSpeed(){
		return Speed;
	}
	public static void SetSpeed (float x) {
		Speed = x;
	}
}
