using UnityEngine;
using System.Collections;

public class PointerArrow : MonoBehaviour {

	public GameObject Arrow1;
	private float counter = 0.0f;

	private bool GoUp = true;
	private bool GoDown = false;

	// Use this for initialization
	void Start () {
		Arrow1.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
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
	}
}
