using UnityEngine;
using System.Collections;

public class backgroundSoundBeach : MonoBehaviour {

	private bool FirstSoundShift = false;
	private bool EnterBeachGirl = false;
	private bool EnterBeachAfterMan = false;
	private bool EnterLastBeach = false;
	private float playerDistance;

	private AudioSource soundsource; //makes the object an audio source emitting sound
	public AudioClip BeachSound; //the clip, which can be applied inside the inspector

	// Use this for initialization
	void Start () {

		soundsource = (AudioSource)gameObject.AddComponent("AudioSource");
		soundsource.clip = BeachSound; //setting the sound to be emitted to the one which is placed in the inspector of the object
		
		soundsource.loop = true; //makes sure that the sound track loops when it has reached the end, if the player decides to go for that long a time period.
		soundsource.Play();
	}
	
	// Update is called once per frame
	void Update () {

		// When going out of the stone-island
		if(Movement2.GetPlayerX() <= 1195 && Movement2.GetPlayerX() >= 1162 && Movement2.GetPlayerZ() <= 1447 && Movement2.GetPlayerZ() >= 1407 && FirstSoundShift == false){
			playerDistance = (Movement2.GetPlayerX() - 1162)* 0.03f;
			audio.volume = Mathf.Abs(playerDistance);
			if (Mathf.Abs(playerDistance) <= 0){
				FirstSoundShift = true;
				soundsource.audio.volume = 0;
			}
		}

		// When entering the breach with the girl
		if(Movement2.GetPlayerX() <= 885 && Movement2.GetPlayerX() >= 855 && Movement2.GetPlayerZ() <= 1200 && Movement2.GetPlayerZ() >= 1150 && EnterBeachGirl == false){
			playerDistance = (855 - Movement2.GetPlayerX())* 0.03f;
			audio.volume =  1 + playerDistance;
			if (playerDistance >= 0){
				EnterBeachGirl = true;
				soundsource.audio.volume = 1.0f;
			}
		}

		// When going out after the girl
		if(Movement2.GetPlayerX() <= 861 && Movement2.GetPlayerX() >= 831 && Movement2.GetPlayerZ() <= 1100 && Movement2.GetPlayerZ() >= 1050 && EnterBeachGirl == true){
			playerDistance = (Movement2.GetPlayerX() - 861)* 0.03f;
			audio.volume = Mathf.Abs(playerDistance);
			if (Mathf.Abs(playerDistance) <= 0){
				EnterBeachGirl = false;
				soundsource.audio.volume = 0;
			}
		}

		// When entering the breach after meeting the dying man
		if(Movement2.GetPlayerX() <= 1135 && Movement2.GetPlayerX() >= 1105 && Movement2.GetPlayerZ() <= 1050 && Movement2.GetPlayerZ() >= 1010 && EnterBeachAfterMan == false){
			playerDistance = (1105 - Movement2.GetPlayerX())* 0.03f;
			audio.volume =  1 + playerDistance;
			if (playerDistance >= 0){
				EnterBeachAfterMan = true;
				soundsource.audio.volume = 1.0f;
			}
		}

		// When going out of the beach after seeing the boat
		if(Movement2.GetPlayerX() <= 1175 && Movement2.GetPlayerX() >= 1100 && Movement2.GetPlayerZ() <= 861 && Movement2.GetPlayerZ() >= 831 && EnterBeachAfterMan == true){
			playerDistance = (Movement2.GetPlayerZ() - 831)* 0.03f;
			audio.volume = Mathf.Abs(playerDistance);
			if (Mathf.Abs(playerDistance) <= 0){
				EnterBeachAfterMan = false;
				soundsource.audio.volume = 0;
			}
		}

		// When entering the breach after leaving or saving carl
		if(Movement2.GetPlayerX() <= 1200 && Movement2.GetPlayerX() >= 1170 && Movement2.GetPlayerZ() <= 610 && Movement2.GetPlayerZ() >= 560 && EnterLastBeach == false){
			playerDistance = (1170 - Movement2.GetPlayerX())* 0.03f;
			audio.volume =  1 + playerDistance;
			if (playerDistance >= 0){
				EnterLastBeach = true;
				soundsource.audio.volume = 1.0f;
			}
		}

	}
}
