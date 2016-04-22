using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class pauseMenu : MonoBehaviour {
	public MM mm;
	public charmove cm;
	public Slider MusicSlider, EffectSlider;
	private Canvas can;
	// Use this for initialization
	void Start () {
		can = gameObject.GetComponent<Canvas>();
		can.enabled = false;
		MusicSlider.value = PlayerPrefs.GetFloat("Music",1f);
		EffectSlider.value = PlayerPrefs.GetFloat("Effect",1f);

	}
	
	// Update is called once per frame
	void Update () {
	if(Input.GetKeyDown("escape")){
			pause();
		}
	}
	public void pause(){
		PlayerPrefs.SetFloat("Music",MusicSlider.value);
		PlayerPrefs.SetFloat("Effect",EffectSlider.value);
		PlayerPrefs.Save();
		if(mm!=null)mm.enabled = !mm.enabled;
		if(cm!=null)cm.enabled = !cm.enabled;
		can.enabled = !can.enabled;
		Slider[] sliders = GetComponentsInChildren<Slider>();
		foreach(Slider slider in sliders){
			slider.enabled = can.enabled;
		}
		Time.timeScale = Time.timeScale==0?1:0;


	}
	public void quit(){
		if (SceneManager.GetActiveScene().buildIndex != 0){
			Time.timeScale = 1;
			SceneManager.LoadScene(0);
		}else{
			Application.Quit();
		}
	}
}
