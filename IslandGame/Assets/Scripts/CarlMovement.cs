using UnityEngine;
using System.Collections;

//code in this script have mainly been copy pasted from a tutorial about moving an animated character through the
//mecanim. Link to youtube (in which the download can be found): https://www.youtube.com/watch?v=Xx21y9eJq1U
//The link and the video was last checked and working: 15/11/2014

// Require these components when using this script
[RequireComponent(typeof (Animator))]
[RequireComponent(typeof (CapsuleCollider))]
[RequireComponent(typeof (Rigidbody))]

public class CarlMovement : MonoBehaviour {

	public float animSpeed = 10.0f; 				// a public setting for overall animator animation speed

	private Animator anim;						// a reference to the animator on the character
	private AnimatorStateInfo currentBaseState;	// a reference to the current state of the animator, used for base layer


	//static int idleState = Animator.StringToHash("Base Layer.Idle"); 			// these integers are references to our animator's states
	//static int WalkState = Animator.StringToHash("Base Layer.WalkingForward");	// and are used to check state for various actions to occur
																				// within our Update() function below

	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator>();					  				
	}
	
	// Update is called once per frame
	void Update () {
		//We just need some scripting to control when the animators controllers conditions are correct  for either of the
		//animations to play. I created a variable called Speed within the animator, and set the conditions so that
		//whenever the other script "Ib" has its bool PauseMovement set to true, Speed will be set to a specific float value.
		//this value is either "greater" or "lesser" than the value I set and will therefore activate the animation.

		//basically: if this value is greater than this, then run this animation.
					//if this value is lower than that, then run that animation.

		//I could have called the variable "noONEeatsCAKEanymore" and set the values to
		//greater than 100 and lesser than -1, and simply adjusted the if-statments below to set the variable to
		// 400 and -30.000.

		//It's just easier to remember what the value is for when calling it speed instead.

		if (Ib.GetPauseMovement() == true){
			//anim.SetBool("WalkingForward", true); //walking animation on. This also makes the char moving forward, so no need for other speed variables.
			anim.SetFloat("Speed", 0.2f); //this is send to the animator component, telling it that a float value we created inside this is set to this value, which makes the condition for changing between the animation happens.
		}
		if (Ib.GetPauseMovement() == false){ //the value here is gotten from the Ib script, which measures if the player is close enough (no walking is needed) or too far away (walking needed)
			//anim.SetBool("Idle", true);
			anim.SetFloat("Speed", 0.001f); //this value is also used in the inbuild if statement of the animator controller.
		}
	}
}
