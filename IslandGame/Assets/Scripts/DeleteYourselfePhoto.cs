﻿using UnityEngine;
using System.Collections;

public class DeleteYourselfePhoto : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (transform.position.y <= 20){
			Destroy(gameObject);
			ActivateFloatingPic.SetBeActive(true);
		}
	
	}
}
