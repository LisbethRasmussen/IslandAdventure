using UnityEngine;
using System.Collections;

public class PlayerHolderScript : MonoBehaviour {

	public GameObject Player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Movement2.GetAnimationOn () == true){
			Player.transform.parent = null;
		}
		if (Movement2.GetAnimationOn () == false){
			Player.transform.parent = transform;
		}
	
	}
}
