using UnityEngine;
using System.Collections;

public class DustExplotion2 : MonoBehaviour {

	private float DistanceX; // this might not be necessary. It depends on the location really. Maybe it's the other one that will be obsolete.
	private float DistanceZ;
	private bool RunBefore1 = false;
	private bool RunBefore2 = false;
	private bool RunBefore3 = false;
	
	
	public GameObject invisibleDustcube; //recall, when this script is pulled onto something, the object in question needs to be added in the inspector.
	
	
	void Start () {
	}
	
	void Update () {
		DistanceX = Movement2.GetPlayerX();
		DistanceZ = Movement2.GetPlayerZ();
		
		if (DistanceZ >= 7 && DistanceX >= 0 && RunBefore1 == false){
			GameObject.Instantiate(invisibleDustcube, new Vector3(10f,0f,11f), transform.rotation);
			RunBefore1 = true;
		}
		if (DistanceZ >= 8 && DistanceX >= 0 && RunBefore2 == false){
			GameObject.Instantiate(invisibleDustcube, new Vector3(11f,0f,11f), transform.rotation);
			RunBefore2 = true;
		}
		if (DistanceZ >= 9 && DistanceX >= 0 && RunBefore3 == false){
			GameObject.Instantiate(invisibleDustcube, new Vector3(12f,0f,11f), transform.rotation);
			RunBefore3 = true;
		}
	}
}
