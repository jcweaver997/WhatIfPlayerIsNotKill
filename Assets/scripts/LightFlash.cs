using UnityEngine;
using System.Collections;

public class LightFlash : MonoBehaviour {
	public bool enable;
	public float lerp;
	public float min,max;
	private Light myLight;
	// Use this for initialization
	void Start () {
		myLight = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!enable)
		{
			if(myLight.enabled==true)myLight.enabled = false;
			return;
		}
		if(myLight.enabled==false)myLight.enabled = true;
		myLight.intensity = Mathf.PerlinNoise (Time.time*lerp,0)*(max-min)+min;
	}
}
