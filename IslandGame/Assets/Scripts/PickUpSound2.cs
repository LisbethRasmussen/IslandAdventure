using UnityEngine;
using System.Collections;

public class PickUpSound2 : MonoBehaviour {

	private AudioSource soundsource; //see the script walkingSOUND for further description
	public AudioClip ThePickUpSound;
	
	private static bool ItemPicked = false;
	private static bool FireWoodPicked = false;
	
	public static void SetItemPicked (bool x) {
		ItemPicked = x;
	}
	public static bool GetItemPicked(){
		return ItemPicked;
	}

	public static void SetFireWoodPicked (bool x) {
		FireWoodPicked = x;
	}
	public static bool GetFireWoodPicked(){
		return FireWoodPicked;
	}
	
	// Use this for initialization
	void Start () {
		
		soundsource = (AudioSource)gameObject.AddComponent("AudioSource");
		soundsource.clip = ThePickUpSound;
		
	}
	
	// Update is called once per frame
	void Update () {
		//using the getter from the PickUp script, so be aware if that variable is changed.
		
		
		if(ItemPicked == true){ //this value gets true when someone is in range of a pickup item and presses E
			audio.PlayOneShot(ThePickUpSound);
			ItemPicked = false; //set it false to make the script ready for the next sound.
		}
		if(FireWoodPicked == true){ //this value gets true when someone is in range of a pickup item and presses E
			audio.PlayOneShot(ThePickUpSound);
			FireWoodPicked = false; //set it false to make the script ready for the next sound.
		}
	}
}
