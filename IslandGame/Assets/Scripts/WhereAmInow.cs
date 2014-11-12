using UnityEngine;
using System.Collections;

public class WhereAmInow : MonoBehaviour {

	private float DistanceX;
	private float DistanceZ;

	public GUIText WhereIam;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		DistanceX = Mathf.Abs (Movement2.GetPlayerX());
		DistanceZ = Mathf.Abs (Movement2.GetPlayerZ());

		WhereIam.text = DistanceX + "   " + DistanceZ;
	
	}
}
