﻿using UnityEngine;
using System.Collections;

public class SharkBait2 : MonoBehaviour {

	private static float baitPosX;
	
	public static float GetBaitX() {
		return baitPosX;
	}
	
	void Update () {
		baitPosX = transform.position.x;
	}
}