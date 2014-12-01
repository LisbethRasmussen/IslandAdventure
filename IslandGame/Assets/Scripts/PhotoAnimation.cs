using UnityEngine;
using System.Collections;

public class PhotoAnimation : MonoBehaviour {

	public GameObject Player;
	public GameObject Carl;
	public GameObject ThePhoto;
	public float animSpeed = 1.5f;
	public Animator anim;
	private float Counter = 0;

	private AnimatorStateInfo currentBaseState;
	private bool ActivateAnimationOne = false;
	private bool ActivateAnimationTwo = false;

	public static int PhotoAnimNr = 0;

	public static int GetPhotoAnim(){return PhotoAnimNr;}

	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator> ();
	
	}
	
	// Update is called once per frame
	void Update () {
		if (ThePictureFlyAway.GetPhotoActive() == true && ActivateAnimationOne == false){
			anim.SetInteger("AnimationNumber", 1);
			if(this.anim.GetCurrentAnimatorStateInfo(0).IsName("Picture1") && this.anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1){
				/*Movement2.SetAnimationOn(true);
				AnimationsOnOff.SetIdlle(true);*/
				ActivateAnimationOne = true;
				/*Choices.SetDecisionToBeMade(true);
				Choices.SetChoiceNumber(2);*/
				Movement2.SetDoNotMove(true);
				Carl.SetActive(false);
			}
		}
		if (ActivateAnimationOne == true && ActivateAnimationTwo == false){
			anim.SetInteger("AnimationNumber", 2);
			PhotoAnimNr = 2;
			if (Choices.GetWasChoiceMade(2) == true){
				Counter++;
				if (Counter >= 100){
					anim.SetInteger("AnimationNumber", 3);
					ActivateAnimationTwo = true;
					Destroy(ThePhoto);
				}
			}
		}

	
	}
}
