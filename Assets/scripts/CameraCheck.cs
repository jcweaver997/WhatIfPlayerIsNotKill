using UnityEngine;
using System.Collections;

public class CameraCheck : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (!Camera.main.Equals (GetComponent<Camera> ())) {
			Destroy(gameObject,0f);
		}
	}
}
