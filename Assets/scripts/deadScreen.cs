using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;
using System.Collections;
using System;
public class deadScreen : MonoBehaviour {

	public float lockTime;

	private float counter;
	private bool wasLoaded;

	void Start(){
		wasLoaded = false;
		counter = 0;
	}

	public static void loadAd(){
		Advertisement.Initialize("1031573");
	}
	
	// Update is called once per frame
	void Update () {
		if(wasLoaded) return;
		counter+=Time.deltaTime;
		if(Input.anyKey && counter >= lockTime){

			if (Advertisement.IsReady()) {
				Camera.main.GetComponent<AudioSource>().Stop();
				Advertisement.Show("video", new ShowOptions{resultCallback = adclosed});
				wasLoaded=true;
			}else{
				SceneManager.LoadScene(0);
			}

		}
		}
	static void adclosed(ShowResult sr){
		SceneManager.LoadScene(0);
	}
}
