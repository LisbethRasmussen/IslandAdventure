using UnityEngine;
using System.Collections;

//place this script on the invisible cube which are made to spawn dustcloudes.

public class IDeleteMySelfe : MonoBehaviour {

	private int saftyCounter = 0;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		saftyCounter++;
		if (saftyCounter == 200) {
			Destroy (gameObject);
			saftyCounter = 0;
		}//maybe need to use *deltatime, to make sure that the smoke comes at the same speed on all comsputers
	}
}
