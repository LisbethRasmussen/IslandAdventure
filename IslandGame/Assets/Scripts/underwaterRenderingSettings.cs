using UnityEngine;
using System.Collections;
//put this on main camera. Recall to set the WaterLevel in the inspector to the y value which the water surface has inside the game.
public class underwaterRenderingSettings : MonoBehaviour {

	public float WaterLevel;
	private Color above;
	private Color below;


	// Use this for initialization
	void Start () {

		above = new Color (0.4f, 0.5f, 0.7f, 0.5f);
		below = new Color (0.2f, 0.38f, 0.55f, 0.5f);
		RenderSettings.fog = true;


	
	}
	
	// Update is called once per frame
	void Update () {

		if (transform.position.y <= WaterLevel){
			RenderSettings.fogColor = below;
			RenderSettings.fogDensity = 0.1f;


		}
		if (transform.position.y > WaterLevel){
			RenderSettings.fogColor = above;
			RenderSettings.fogDensity = 0.002f;

		}

	}
}
