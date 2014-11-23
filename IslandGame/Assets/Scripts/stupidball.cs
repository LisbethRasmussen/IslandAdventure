using UnityEngine;
using System.Collections;

public class stupidball : MonoBehaviour {

	private bool LightFire = false;
	private bool FindFood = false;
	private bool CookFood = false;

	private bool GoNow = false;

	private static float PosX;
	private static float PosZ;

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

		PosX = transform.position.x;		
		PosZ = transform.position.z;

		if (LightFire == false && Ib.GetBallIsActive() == true){
			Movement2.SetCarlActive(false);
			transform.position += new Vector3 (-0.5f,0,-0.1f);
			if (PosX <= 1031 && PosZ <= 1331){
				LightFire = true;
				Movement2.SetCampfireOn(true);
				Movement2.SetCarlActive(true);
				Ib.SetBallIsActive(false);
			}
		}
		if (FindFood == false && LightFire == true && Movement2.GetGatherFood() == true){
			Movement2.SetCarlActive(false);
			Ib.SetBallIsActive(true);
			if (GoNow = false){
				transform.position = new Vector3 (1030,43,1346);
				GoNow = true;
			}
			if (GoNow == true){
				transform.position += new Vector3 (-0.5f,0,+0.5f);
				if (PosX <= 1010 && PosZ >= 1370){
					transform.position += new Vector3 (-0.5f,0,0);
					if (PosX <= 978){
						FindFood = true;
					}
				}
			}
		}
	
	}
}
