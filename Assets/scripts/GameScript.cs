using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameScript : MonoBehaviour {

	public static int score;
	public static int pointsForSecond;
	public int PointsForSecond;
	public Score scoreShow;
	public int zombiePoints;
	public GameObject character;
	public zSpawner spawner;
	public GameObject[] zombies;
	public RoundStatus roundStatus;

	private WaveScript wave;
	private Health phealth;

	void Start () {
		phealth = character.GetComponent<Health>();
		score = 0;
		wave = new WaveScript(spawner);
		wave.setZombies(zombies);
		wave.setRoundStatus(roundStatus);
		pointsForSecond = PointsForSecond;
	}

	void Update () {
		scoreShow.score = score;

		if (phealth.hasDied) {
			switch(SceneManager.GetActiveScene().buildIndex){
			case 1:
				// dust
				if(score > PlayerPrefs.GetInt("DustScore",0)){
					PlayerPrefs.SetInt("DustScore",score);
					PlayerPrefs.Save();
				}

				break;
			case 3:
				// mtn
				if(score > PlayerPrefs.GetInt("MtnScore",0)){
					PlayerPrefs.SetInt("MtnScore",score);
					PlayerPrefs.Save();
				}

				break;
			default:
				break;

			}

			SceneManager.LoadScene(2);
		}

		wave.update();

	}
	

	public void killedZombie(){
		score+=zombiePoints;
		wave.killedZombie();
	}

	public void hasDied(){
		Debug.Log("YOU ARE DEAD!!11!");
	}
	
}
