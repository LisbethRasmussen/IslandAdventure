﻿using UnityEngine;
using System.Collections;

public class AnimationPositionTest : MonoBehaviour {

	Vector3  localPos;
	bool wasPlaying;
	
	void Awake ()
	{
		localPos = transform.position ;
		wasPlaying = false;
	}
	
	void LateUpdate ()
	{
		if (!animation.isPlaying && !wasPlaying)
			return;
		
		transform.localPosition  += localPos;
		
		wasPlaying = animation.isPlaying;
	}
}
