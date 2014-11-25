using UnityEngine;
using System.Collections;

public class PointerArrow : MonoBehaviour {

	public GameObject Arrow1;
	private float counter = 0.0f;

	// Use this for initialization
	void Start () {
		Arrow1.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		//print (Mathf.Sin (counter) + 30);
		if (Movement2.GetMiniGameOn() == true){
			Arrow1.SetActive(true);
			counter++;
			Arrow1.transform.position = new Vector3 (1278.723f,Mathf.Sin(counter*Time.deltaTime)+30,1433.122f);
		}
	}
}
