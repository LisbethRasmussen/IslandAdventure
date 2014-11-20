using UnityEngine;
using System.Collections;
//This script needs to be on the player character. For further information about the code, check CarlMovement scriptet
public class AnimationsOnOff : MonoBehaviour {

	public GameObject Carl;
	private int FrameCounter = 0;

	public float animSpeed = 1.5f;
	private static bool AnimON = true;
	public Animator anim;

	private AnimatorStateInfo currentBaseState;
	//static int PlayerStartState = Animator.StringToHash("Base Layer.PlayerStart");
	//static int PlayerStartState = Animator.StringToHash("Base Layer.PlayerStart");

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {


		if (Movement2.GetAnimationOn() == false){
			anim.SetInteger("NumberOfAnimation", 0);
		}
		if (Movement2.GetAnimationCounter() == 1 && Movement2.GetAnimationOn() == true){
			anim.SetInteger("NumberOfAnimation", 1);
			//if (this.anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0)){
			if(this.anim.GetCurrentAnimatorStateInfo(0).IsName("PlayerStart") && this.anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1){
				Movement2.SetAnimationOn(false);
				Movement2.SetGoNormal(true);
				Carl.SetActive(true);
				Movement2.SetCarlActive(true);
				Movement2.SetAnimationCounter(Movement2.GetAnimationCounter() + 1);
			}
		}

		if (Movement2.GetAnimationCounter() == 2 && Movement2.GetAnimationOn() == true){
			anim.SetInteger("NumberOfAnimation", 2);
			if (this.anim.GetCurrentAnimatorStateInfo(0).IsName("BoatWater") && this.anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1){
				Movement2.SetAnimationOn(false);
				Movement2.SetGoNormal(true);
				print ("hej");
				Movement2.SetAnimationCounter(Movement2.GetAnimationCounter() + 1);
			}
		}
		if (Movement2.GetAnimationCounter() == 3 && Movement2.GetAnimationOn() == true){
			anim.SetInteger("NumberOfAnimation", 3);
			FrameCounter++;
			print (FrameCounter);
			if (FrameCounter >= 50){
				Movement2.SetAnimationOn(false);
				Movement2.SetGoNormal(true);//recall to revisit this later for because of the walking speed.
				FrameCounter = 0;
				Movement2.SetAnimationCounter(Movement2.GetAnimationCounter() + 1);
			}
		}
	
	}
}

