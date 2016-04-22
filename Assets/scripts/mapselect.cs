using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class mapselect : MonoBehaviour {
	public GameObject dustytoo, mtndoo;
	public Camera cam;
	public float timer = .2f;
	public box bd, bm;
	
	void Start () {
		bd = new box (dustytoo);
		bm = new box (mtndoo);
		cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
	}
	
	void Update () {
		timer -= Time.deltaTime;
		if(timer > 0)return;

		Vector3 mp = Input.mousePosition;
		mp = cam.ScreenToWorldPoint (mp);
		if (Input.GetMouseButton(0))
			if (bd.isIn (mp))
				md ();
		else if (bm.isIn (mp))
			mm ();
	}
	
	void md(){
		Destroy(cam.gameObject,0f);
		SceneManager.LoadScene(1);
	}
	void mm(){
		Destroy(cam.gameObject,0f);
		SceneManager.LoadScene(3);
	}
}
