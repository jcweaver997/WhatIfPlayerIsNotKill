using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EuphoriaColor : MonoBehaviour {
	Image screen;
	void Start(){
		screen = GetComponentInChildren<Image>();
	}

	void Update () {
		screen.color = new Color(Mathf.PerlinNoise(Time.time,0),Mathf.PerlinNoise(Time.time*2,0),Mathf.PerlinNoise(Time.time/2,0),.5f);
	}
}
