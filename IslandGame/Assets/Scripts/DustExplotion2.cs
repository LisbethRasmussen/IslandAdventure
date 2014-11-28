using UnityEngine;
using System.Collections;

public class DustExplotion2 : MonoBehaviour {

	private float DistanceX; // this might not be necessary. It depends on the location really. Maybe it's the other one that will be obsolete.
	private float DistanceZ;
	private bool RunBefore1 = false;
	private bool RunBefore2 = false;
	private bool RunBefore3 = false;

	private static bool TheFirstDustCloudeIsSeen = false;
	public static bool GetTheFirstDustCloudeIsSeen(){return TheFirstDustCloudeIsSeen;}
	
	public GameObject invisibleDustcube1; //recall, when this script is pulled onto something, the object in question needs to be added in the inspector.
	public GameObject invisibleDustcube2;
	public GameObject invisibleDustcube3;
	
	void Start () {
		invisibleDustcube1.SetActive (false);
		invisibleDustcube2.SetActive (false);
		invisibleDustcube3.SetActive (false);
	}
	
	void Update () {
		DistanceX = Movement2.GetPlayerX();
		DistanceZ = Movement2.GetPlayerZ();
		
		if (DistanceZ >= 764 && DistanceZ <= 781 && DistanceX >= 1073 && DistanceX <= 1090 && RunBefore1 == false){
			invisibleDustcube1.SetActive (true);
			RunBefore1 = true;
			TheFirstDustCloudeIsSeen = true;

		}
		if (DistanceZ >= 753 && DistanceZ <= 758 && DistanceX >= 1043 && DistanceX <= 1062 && RunBefore2 == false){
			invisibleDustcube2.SetActive (true);
			RunBefore2 = true;
		}
		if (DistanceZ >= 654 && DistanceZ <= 675 && DistanceX >= 1039 && DistanceX <= 1053 && RunBefore3 == false){
			invisibleDustcube3.SetActive (true);
			RunBefore3 = true;
		}
	}
}
