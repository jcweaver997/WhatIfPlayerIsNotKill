using UnityEngine;
using System.Collections;

public class VolSetter : MonoBehaviour {
	public bool isMusic;
	private AudioSource aus;


	// Use this for initialization
	void Start () {
		aus = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if(isMusic){
			if(aus.volume!=Volume.Music)aus.volume = Volume.Music;
		}else{
			if(aus.volume!=Volume.Effect)aus.volume = Volume.Effect;
		}
	}
}
