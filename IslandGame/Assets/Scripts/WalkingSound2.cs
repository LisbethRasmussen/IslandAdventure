using UnityEngine;
using System.Collections;

public class WalkingSound2 : MonoBehaviour {

	private AudioSource soundsource; //makes the object an audio source emitting sound
	public AudioClip SteppingSound; //the clip, which can be applied inside the inspector
	private float counter = 0;
	
	// Use this for initialization
	void Start () {
		soundsource = (AudioSource)gameObject.AddComponent("AudioSource");
		soundsource.clip = SteppingSound; //setting the sound to be emitted to the one which is placed in the inspector of the object
		
		soundsource.loop = true; //makes sure that the sound track loops when it has reached the end, if the player decides to go for that long a time period.
		
	}
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.S)) {
			counter++;//to be sure that it is only started one time, in case the double frame problem occurs.
			if (counter == 1){
				soundsource.Play();//starts when counter is equal to 1
			}
		}
		else{
			soundsource.Stop();
			counter = 0; //stops everything if the above do not apply.
		}
	}
}
