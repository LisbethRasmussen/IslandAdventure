using UnityEngine;
using System.Collections;

public class backgroundsoundjungle : MonoBehaviour {

	private bool EnterJungleCave = false;
	private bool EnterJungleDyingMan = false;
	private bool EnterJungleHoles = false;
	private float playerDistance;

	private AudioSource soundsource; //makes the object an audio source emitting sound
	public AudioClip JungleSound; //the clip, which can be applied inside the inspector

	// Use this for initialization
	void Start () {

		soundsource = (AudioSource)gameObject.AddComponent("AudioSource");
		soundsource.clip = JungleSound; //setting the sound to be emitted to the one which is placed in the inspector of the object
		
		soundsource.loop = true; //makes sure that the sound track loops when it has reached the end, if the player decides to go for that long a time period.
		soundsource.Play();
		soundsource.audio.volume = 0;
	}
	
	// Update is called once per frame
	void Update () {

		// When going out of the stone-island
		if(Movement2.GetPlayerX() <= 1195 && Movement2.GetPlayerX() >= 1162 && Movement2.GetPlayerZ() <= 1447 && Movement2.GetPlayerZ() >= 1407 && EnterJungleCave == false){
			playerDistance = (1162 - Movement2.GetPlayerX())* 0.03f;
			audio.volume = 1 + playerDistance;
			if (playerDistance >= 0){
				EnterJungleCave = true;
				soundsource.audio.volume = 1.0f;
			}
		}

		// When Leaving the cave area
		if(Movement2.GetPlayerX() <= 885 && Movement2.GetPlayerX() >= 855 && Movement2.GetPlayerZ() <= 1200 && Movement2.GetPlayerZ() >= 1150 && EnterJungleCave == true){
			playerDistance = (Movement2.GetPlayerX() - 855)* 0.03f;
			audio.volume = Mathf.Abs(playerDistance);
			if (Mathf.Abs(playerDistance) <= 0){
				EnterJungleCave = false;
				soundsource.audio.volume = 0;
			}
		}
		
		// When entering the jungle after the girl
		if(Movement2.GetPlayerX() <= 861 && Movement2.GetPlayerX() >= 831 && Movement2.GetPlayerZ() <= 1100 && Movement2.GetPlayerZ() >= 1050 && EnterJungleDyingMan == false){
			playerDistance = (861 - Movement2.GetPlayerX())* 0.03f;
			audio.volume = Mathf.Abs(playerDistance);
			if (playerDistance >= 0){
				EnterJungleDyingMan = true;
				soundsource.audio.volume = 1.0f;
			}
		}
		
		// When entering the breach after meeting the dying man
		if(Movement2.GetPlayerX() <= 1135 && Movement2.GetPlayerX() >= 1105 && Movement2.GetPlayerZ() <= 1050 && Movement2.GetPlayerZ() >= 1010 && EnterJungleDyingMan == true){
			playerDistance = (Movement2.GetPlayerX() - 1105)* 0.03f;
			audio.volume = Mathf.Abs(playerDistance);
			if (Mathf.Abs(playerDistance) <= 0){
				EnterJungleDyingMan = false;
				soundsource.audio.volume = 0;
			}
		}
		
		// When entering the jungle with the holes
		if(Movement2.GetPlayerX() <= 1175 && Movement2.GetPlayerX() >= 1100 && Movement2.GetPlayerZ() <= 861 && Movement2.GetPlayerZ() >= 831 && EnterJungleHoles == false){
			playerDistance = (831 - Movement2.GetPlayerZ())* 0.03f;
			audio.volume = Mathf.Abs(playerDistance);
			if (playerDistance >= 0){
				EnterJungleHoles = true;
				soundsource.audio.volume = 1.0f;
			}
		}
		
		// When leaving the jungle after leaving or saving carl
		if(Movement2.GetPlayerX() <= 1200 && Movement2.GetPlayerX() >= 1170 && Movement2.GetPlayerZ() <= 610 && Movement2.GetPlayerZ() >= 560 && EnterJungleHoles == true){
			playerDistance = (Movement2.GetPlayerX() - 1170)* 0.03f;
			audio.volume = Mathf.Abs(playerDistance);
			if (Mathf.Abs(playerDistance) <= 0){
				EnterJungleHoles = false;
				soundsource.audio.volume = 0;
			}
		}
	}
}
