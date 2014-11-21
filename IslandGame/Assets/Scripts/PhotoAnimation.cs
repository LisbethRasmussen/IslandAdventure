using UnityEngine;
using System.Collections;

public class PhotoAnimation : MonoBehaviour {

	public GameObject Player;
	public float animSpeed = 1.5f;
	public Animator anim;

	private AnimatorStateInfo currentBaseState;
	private bool ActivateAnimationOne = false;

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
				ActivateAnimationOne = true;
			}
		}
		if (ActivateAnimationOne == true){
			anim.SetInteger("AnimationNumber", 2);
			PhotoAnimNr = 2;
			if (this.anim.GetCurrentAnimatorStateInfo(0).IsName("Picture2") && this.anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1){

			}
		}

	
	}
}
