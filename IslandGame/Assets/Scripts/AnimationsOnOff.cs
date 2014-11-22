using UnityEngine;
using System.Collections;
//This script needs to be on the player character. For further information about the code, check CarlMovement scriptet
public class AnimationsOnOff : MonoBehaviour {

	public GameObject Carl;
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

	public static bool Idlle = false;
	public static void SetIdlle (bool x){ Idlle = x;}

	//Vector3 startPosition;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		//startPosition = transform.localPosition += new Vector3(1263f, 35f, 1421f);;


		print (Movement2.GetAnimationCounter ());
		if (PhotoAnimation.GetPhotoAnim()==2){
			ValueHolder = true;
		}
		/*if (Input.GetKey(KeyCode.W)){
			anim.SetInteger("NumberOfAnimation", 0);
		}*/

		/*if (Movement2.GetAnimationOn() == true && Idlle == true){
			anim.SetInteger("NumberOfAnimation", 0);
		}*/
		if (Movement2.GetAnimationCounter() == 1 && Movement2.GetAnimationOn() == true && Idlle == false){
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

		if (Movement2.GetAnimationCounter() == 2 && Movement2.GetAnimationOn() == true && Idlle == false){
			anim.SetInteger("NumberOfAnimation", 2);//animation: player looks over water and jumps back
			if (this.anim.GetCurrentAnimatorStateInfo(0).IsName("BoatWater") && this.anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1){
				print ("Hello fucking world!");
				Movement2.SetAnimationOn(false);
				Movement2.SetGoNormal(true);
				Movement2.SetAnimationCounter(Movement2.GetAnimationCounter() + 1);
				Conversation2Active = true;
			}
		}
		if (Movement2.GetAnimationCounter() == 3 && Movement2.GetAnimationOn() == true && ValueHolder == true && Choices.GetChoice(2) == false && Choices.GetWasChoiceMade(2) == true && Idlle == false){
			anim.SetInteger("NumberOfAnimation", 3); //player jumps into water

			if (this.anim.GetCurrentAnimatorStateInfo(0).IsName("JumpWater") && this.anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1){
				Movement2.SetAnimationCounter(Movement2.GetAnimationCounter() + 1);
				BackPack2.SetHaveBackpack(false);
				Movement2.SetFoodCount(0);
				JumpInWater = true;
			}
		}
		if ((Movement2.GetAnimationOn() == true && JumpInWater == true) || (Movement2.GetAnimationOn() == true && Choices.GetChoice(2) == true && Movement2.GetPlayerY() <=21) && Idlle == false){
			anim.SetInteger("NumberOfAnimation", 4);
			if (this.anim.GetCurrentAnimatorStateInfo(0).IsName("InWater") && this.anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1){
				Movement2.SetAnimationCounter(Movement2.GetAnimationCounter() + 1);
				if (Choices.GetChoice(2) == true){
					Movement2.SetAnimationOn(false);
					Movement2.SetGoNormal(true);
					Carl.SetActive(true);
				}
				if (Choices.GetChoice(2) == false){
					Movement2.SetAnimationOn(false);
					Movement2.SetGoFaster(true);
					Carl.SetActive(true);
				}
			}
		}
	}

	void LateUpdate() {
		//transform.localPosition += startPosition;

	}

	/*void LateUpdate () {
		transform.localPosition .x += Movement2.GetPlayerX();
		transform.localPosition .y += Movement2.GetPlayerY();
		transform.localPosition .z += Movement2.GetPlayerZ();
	}*/
}

