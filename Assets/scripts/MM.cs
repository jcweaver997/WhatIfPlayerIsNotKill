using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MM : MonoBehaviour {
	public GameObject play, options, quit;
	private Camera cam;
	public box bplay, boptions, bquit;
	public pauseMenu pause;
	private AsyncOperation asc;
	void Start () {
		bplay = new box (play);
		boptions = new box (options);
		bquit = new box (quit);
		cam = Camera.main;
		DontDestroyOnLoad(cam.gameObject);

		//asc = Application.LoadLevelAsync(4);
		//asc.allowSceneActivation = false;
	}

	void Update () {
				Vector3 mp = Input.mousePosition;
				mp = cam.ScreenToWorldPoint (mp);
				if (Input.GetMouseButton(0))
				if (bplay.isIn (mp))
						mplay ();
				else if (boptions.isIn (mp))
						moptions ();
				else if (bquit.isIn (mp))
						mquit ();
		}

	void mplay(){
		//asc.allowSceneActivation = true;
		SceneManager.LoadScene(4);
	}
	void moptions(){
		pause.pause();
	}
	void mquit(){
		Application.Quit ();
	}
	public void Leaderboards(){
		SceneManager.LoadScene(6);
	}
}








