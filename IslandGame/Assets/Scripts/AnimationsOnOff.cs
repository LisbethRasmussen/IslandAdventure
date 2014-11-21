using UnityEngine;
using System.Collections;
//This script needs to be on the player character. For further information about the code, check CarlMovement scriptet
public class AnimationsOnOff : MonoBehaviour {

	public GameObject Carl;
	private int FrameCounter = 0;
	public static bool Conversation2Active = false;
	public static bool JumpInWater = false;
	private bool ValueHolder = false;

	public float animSpeed = 1.5f;
	private static bool AnimON = true;
	public Animator anim;

	private AnimatorStateInfo currentBaseState;

	public static bool GetConversation2Active(){return Conversation2Active;}
	public static bool GetJumpInWater(){return JumpInWater;}
	public static void SetJumpInWater(bool x){JumpInWater = x;}

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (PhotoAnimation.GetPhotoAnim()==2){
			ValueHolder = true
		}

		if (Movement2.GetAnimationOn() == false){
			anim.SetInteger("NumberOfAnimation", 0);
		}
		if (Movement2.GetAnimationCounter() == 1 && Movement2.GetAnimationOn() == true){
			anim.SetInteger("NumberOfAnimation", 1); //animation: player wakes up and stands
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
			anim.SetInteger("NumberOfAnimation", 2);//animation: player looks over water and jumps back
			if (this.anim.GetCurrentAnimatorStateInfo(0).IsName("BoatWater") && this.anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1){
				Movement2.SetAnimationOn(false);
				Movement2.SetGoNormal(true);
				Movement2.SetAnimationCounter(Movement2.GetAnimationCounter() + 1);
				Conversation2Active = true;
			}
		}
		if (Movement2.GetAnimationCounter() == 3 && Movement2.GetAnimationOn() == true && ValueHolder == true && Choices.GetChoice(2) == false){
			anim.SetInteger("NumberOfAnimation", 3); //player jumps into water
			if (this.anim.GetCurrentAnimatorStateInfo(0).IsName("JumpWater") && this.anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1){
				Movement2.SetAnimationCounter(Movement2.GetAnimationCounter() + 1);
				BackPack2.SetHaveBackpack(false);
				Movement2.SetFoodCount(0);
				JumpInWater = true;
				Movement2.SetAnimationCounter(Movement2.GetAnimationCounter() + 1);
			}
		}
		if (JumpInWater == true && Movement2.GetAnimationOn() == true && ValueHolder == true && Choices.GetChoice(2) == false){

	}
}

