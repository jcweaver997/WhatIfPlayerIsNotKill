using UnityEngine;
using System.Collections;

public class camFollow : MonoBehaviour {
	public GameObject cam;
	public Transform topLeft, botRight;
	public float lerpval;

	private Vector3 wptl;
	private Vector3 wpbr;
	// Use this for initialization
	void Start () {
		wptl = cam.GetComponent<Camera>().ScreenToWorldPoint (new Vector3(0,Screen.height,0));
		wpbr = cam.GetComponent<Camera>().ScreenToWorldPoint (new Vector3(Screen.width,0,0));
	}
	
	// Update is called once per frame
	void Update () {
		float distance = Vector3.Magnitude(cam.transform.position - transform.position);
		float oldx=cam.transform.position.x, oldy=cam.transform.position.y;
		cam.transform.position = Vector3.Lerp(new Vector3(oldx,oldy,-10),
		                                      new Vector3(transform.position.x,transform.position.y,-10),distance*lerpval*Time.deltaTime);



		wptl = cam.GetComponent<Camera>().ScreenToWorldPoint (new Vector3(0,Screen.height,0));
		wpbr = cam.GetComponent<Camera>().ScreenToWorldPoint (new Vector3(Screen.width,0,0));


		cam.transform.position = new Vector3 (oldx, oldy, -10);

		float newx;
		float newy;


		if (wptl.x < topLeft.position.x ||  wpbr.x > botRight.position.x) {
			newx = oldx;
		} else {
			newx = transform.position.x;
		}
		if ( wptl.y > topLeft.position.y || wpbr.y < botRight.position.y) {
			newy = oldy;
		} else {
			newy = transform.position.y;
		}

		cam.transform.position = Vector3.Lerp(new Vector3(oldx,oldy,-10),
		                                      new Vector3(newx,newy,-10),distance*lerpval*Time.deltaTime);
	}
}
