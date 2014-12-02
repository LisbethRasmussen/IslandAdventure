using UnityEngine;
using System.Collections;

public class WhereAmInow : MonoBehaviour {

	private float DistanceX;
	private float DistanceY;
	private float DistanceZ;

	public GUIText WhereIam;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		DistanceX = Mathf.Abs (Movement2.GetPlayerX());
		DistanceY = Mathf.Abs (Movement2.GetPlayerY());
		DistanceZ = Mathf.Abs (Movement2.GetPlayerZ());

		//WhereIam.text = DistanceX + "   " + DistanceY + "   " + DistanceZ;
	
	}
}
