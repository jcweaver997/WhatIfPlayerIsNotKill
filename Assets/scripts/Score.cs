using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {

	public int score;

	public Text text;
	private int lastScore;
	// Use this for initialization
	void Start () {
		score = GameScript.score;
		text.text = "SCORE: "+score;
		lastScore = score;
	}
	
	// Update is called once per frame
	void Update () {
		if (lastScore != score)
		{
			text.text = "SCORE: "+score;
			lastScore = score;
		}

	}

}
