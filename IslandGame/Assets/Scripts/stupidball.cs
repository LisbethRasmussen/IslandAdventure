using UnityEngine;
using System.Collections;

public class stupidball : MonoBehaviour {

	private static bool LightFire = false;

	private bool GoNow = false;

	private static float PosX;
	private static float PosZ;

	public static float GetPosX(){
		return PosX;
	}
	public static float GetPosZ(){
		return PosZ;
	}
	public static bool GetLightFire(){return LightFire;}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		PosX = transform.position.x;		
		PosZ = transform.position.z;

		if (LightFire == false && Ib.GetBallIsActive() == true){
			Movement2.SetCarlActive(false);
			//transform.position += new Vector3 (-0.07f,0,-0.02f);
			if (/*PosX <= 1031 && PosZ <= 1331*/ Ib.GetPauseMovement()== false){
				LightFire = true;
				Movement2.SetCampfireOn(true);
				Movement2.SetCarlActive(true);
				Ib.SetBallIsActive(false);
				//Destroy(gameObject);
			}
		}
	}
}
