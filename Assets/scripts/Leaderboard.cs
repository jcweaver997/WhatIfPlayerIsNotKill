using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class Leaderboard : MonoBehaviour {
	public Text dust, mtn;
	// Use this for initialization
	void Start () {
		dust.text += PlayerPrefs.GetInt ("DustScore",0);
		mtn.text += PlayerPrefs.GetInt ("MtnScore",0);
	}
	public void GotoMenu(){
		SceneManager.LoadScene(0);
	}
}
