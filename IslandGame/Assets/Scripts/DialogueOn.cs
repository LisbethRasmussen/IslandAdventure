using UnityEngine;
using System.Collections;

public class DialogueOn : MonoBehaviour {

	public GameObject Dialogue1;	// The game objects there shall contain each dialogue empty objects
	public GameObject Dialogue2;
	public GameObject Dialogue3;
	public GameObject Dialogue4;
	public GameObject Dialogue5;
	public GameObject Dialogue6;
	public GameObject Dialogue7;
	public GameObject Dialogue8;
	public GameObject Dialogue9;
	public GameObject Dialogue10;
	public GameObject Dialogue11;
	public GameObject Dialogue12;
	public GameObject Dialogue13;
	public GameObject Dialogue14;
	public GameObject Dialogue15;
	public GameObject Dialogue16;
	public GameObject Dialogue17;
	public GameObject Dialogue18;
	public GameObject Dialogue19;

	private bool[] Trigger;	// A trigger for letting a dialogue only trigger once

	// Use this for initialization
	void Start () {
		Trigger = new bool[19];
		for (int i = 0; i < 19; i++) {
			Trigger[i] = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Ib.GetDialogueTrigger1() == true && Trigger[1-1] == true) {
			GUIDialogue.SetDialogueON(true);
			Dialogue1.SetActive(true);
			Trigger[1-1] = false;
		}
	}
}
