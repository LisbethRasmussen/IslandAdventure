﻿using UnityEngine;
using System.Collections;

public class SharkBait6 : MonoBehaviour {

	private static float baitPosX;
	
	public static float GetBaitX() {
		return baitPosX;
	}
	
	void Update () {
		baitPosX = transform.position.x;
	}
}
