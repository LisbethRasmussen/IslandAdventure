using UnityEngine;
using System.Collections;

public class AnimPlayOnceOnly : MonoBehaviour {

	// Use this for initialization
	void Start () {
		animation["newAnimPhotoTest"].wrapMode = WrapMode.Once;
		print ("yes");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
