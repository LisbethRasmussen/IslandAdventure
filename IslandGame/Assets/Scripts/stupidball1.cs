using UnityEngine;
using System.Collections;

public class stupidball1 : MonoBehaviour {

	public GameObject Carl;

	private static float PosX;
	private static float PosZ;
	private float DistanceX;
	private float DistanceZ;

	private bool StopNow = false;
	
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

		DistanceX = Mathf.Abs (PosX - Ib.GetPosX ());
		DistanceZ = Mathf.Abs (PosZ - Ib.GetPosZ ());
	
		if (stupidball.GetLightFire() == true && Movement2.GetGatherFood() == true && StopNow == false){
			Movement2.SetCarlActive(false);
			Ib.SetBallIsActive1(true);
			//transform.position += new Vector3 (-0.05f,0,+0.05f);
			if (DistanceX <= 7.0f && DistanceZ <= 7.0f && Ib.GetPauseMovement() == false){
				StopNow = true;
				Carl.SetActive(false);
			}
		}
	}
}