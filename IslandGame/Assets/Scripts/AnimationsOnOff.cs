using UnityEngine;
using System.Collections;
//This script needs to be on the player character. For further information about the code, check CarlMovement scriptet
public class AnimationsOnOff : MonoBehaviour {

	public GameObject Player;
	private int FrameCounter = 0;

	public float animSpeed = 1.5f;
	private static bool AnimON = true;
	public Animator anim;

	private AnimatorStateInfo currentBaseState;

	private bool Animation1 = false;
	private bool Animation2 = false;
	private bool Animation3 = false;
	private bool Animation4 = false;
	private bool Animation5 = false;
	private bool Animation6 = false;
	private bool Animation7 = false;
	private bool Animation8 = false;
	private bool Animation9 = false;
	private bool Animation10 = false;
	private bool Animation11 = false;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		/*if (Movement2.GetAnimationOn() == true){
			Player.transform.parent = transform;
		}
		if (Movement2.GetAnimationOn() == false){
			Player.transform.parent = null;
		}*/

		if (Movement2.GetAnimationOn() == false){
			anim.SetInteger("NumberOfAnimation", 1);
		}
		if (Animation1 == false && Movement2.GetAnimationOn() == true){
			anim.SetInteger("NumberOfAnimation", 2);
			FrameCounter++;
			print (FrameCounter);
			if (FrameCounter >= 260){
				Animation1 = true;
				Movement2.SetAnimationOn(false);
				Movement2.SetGoNormal(true);
				FrameCounter = 0;
			}
		}
		if (Animation2 == false && Movement2.GetAnimationOn() == true && Animation1 == true){
			anim.SetInteger("NumberOfAnimation", 3);
			if (FrameCounter >= 4350){
				Animation2 = true;
				Movement2.SetAnimationOn(false);
			}
		}
		if (Animation3 == false && Movement2.GetAnimationOn() == true && Animation2 == true){
			anim.SetInteger("NumberOfAnimation", 4);
			if (FrameCounter >= 4983){
				Animation3 = true;
				Movement2.SetAnimationOn(false);
			}
		}
	
	}
}
