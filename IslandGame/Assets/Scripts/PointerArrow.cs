using UnityEngine;
using System.Collections;

public class PointerArrow : MonoBehaviour {
	//---------------------------------------------- Put the foodboxes here
	public GameObject Arrow1;
	private float counter = 0.0f;

	private bool GoUp = true;
	private bool GoDown = false;
	//---------------------------------------------- Go to this area here
	public GameObject Arrow2;
	private float counter2 = 0.0f;
	
	private bool GoUp2 = true;
	private bool GoDown2 = false;
	//---------------------------------------------- Go to the dead girl
	public GameObject Arrow3;
	private float counter3 = 0.0f;
	
	private bool GoUp3 = true;
	private bool GoDown3 = false;
	//---------------------------------------------- Go to the dying guy
	public GameObject Arrow4;
	private float counter4 = 0.0f;
	
	private bool GoUp4 = true;
	private bool GoDown4 = false;
	//----------------------------------------------
	// Use this for initialization
	void Start () {
		Arrow1.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {

		//----------------------------------------------------------------------------ONE, boxes
		//print (Mathf.Sin (counter) + 30);
		if (Movement2.GetMiniGameOn() == true && GoUp == true){
			Arrow1.SetActive(true);
			counter+= 0.1f;
			//Arrow1.transform.position = new Vector3 (1278.723f,Mathf.Sin(counter*Time.deltaTime)+30,1433.122f);
			Arrow1.transform.position += new Vector3 (0,0.1f,0);
			if (counter >= 3){
				GoUp = false;
				GoDown = true;
				counter = 0;
			}
		}
		if (Movement2.GetMiniGameOn() == true && GoDown == true){
			Arrow1.SetActive(true);
			counter+= 0.1f;
			//Arrow1.transform.position = new Vector3 (1278.723f,Mathf.Sin(counter*Time.deltaTime)+30,1433.122f);
			Arrow1.transform.position -= new Vector3 (0,0.1f,0);
			if (counter >= 3){
				GoUp = true;
				GoDown = false;
				counter = 0;
			}
		}
		if (Movement2.GetMiniGameOn() == false){
			Arrow1.SetActive(false);
		}
		//---------------------------------------------------------------------------------TWO, foodarea
		if (GoUp2 == true){
			Arrow2.SetActive(true);
			counter2+= 0.1f;
			Arrow2.transform.position += new Vector3 (0,0.1f,0);
			if (counter2 >= 3){
				GoUp2 = false;
				GoDown2 = true;
				counter2 = 0;
			}
		}
		if (GoDown2 == true){
			Arrow2.SetActive(true);
			counter2+= 0.1f;
			Arrow2.transform.position -= new Vector3 (0,0.1f,0);
			if (counter2 >= 3){
				GoUp2 = true;
				GoDown2 = false;
				counter2 = 0;
			}
		}
		if(Movement2.GetPlayerX() >= 1076 && Movement2.GetPlayerX() <= 1080 && Movement2.GetPlayerZ() <= 1335 && Movement2.GetPlayerZ() >= 1297){
			Arrow2.SetActive(false);
		}
		//----------------------------------------------------------------------------------Three, girl
		if (GoUp3 == true){
			Arrow3.SetActive(true);
			counter3+= 0.1f;
			Arrow3.transform.position += new Vector3 (0,0.1f,0);
			if (counter3 >= 3){
				GoUp3 = false;
				GoDown3 = true;
				counter3 = 0;
			}
		}
		if (GoDown3 == true){
			Arrow3.SetActive(true);
			counter3+= 0.1f;
			Arrow3.transform.position -= new Vector3 (0,0.1f,0);
			if (counter3 >= 3){
				GoUp3 = true;
				GoDown3 = false;
				counter3 = 0;
			}
		}
		if (Choices.GetWasChoiceMade(4) == true){
			Arrow3.SetActive(false);
		}
		//---------------------------------------------------------------------------------------Four, dying male
		if (GoUp4 == true){
			Arrow4.SetActive(true);
			counter4+= 0.1f;
			Arrow4.transform.position += new Vector3 (0,0.1f,0);
			if (counter4 >= 3){
				GoUp4 = false;
				GoDown4 = true;
				counter4 = 0;
			}
		}
		if (GoDown4 == true){
			Arrow4.SetActive(true);
			counter4+= 0.1f;
			Arrow4.transform.position -= new Vector3 (0,0.1f,0);
			if (counter4 >= 3){
				GoUp4 = true;
				GoDown4 = false;
				counter4 = 0;
			}
		}
		if (Choices.GetWasChoiceMade(5)){
			Arrow4.SetActive(false);
		}
	}
}
