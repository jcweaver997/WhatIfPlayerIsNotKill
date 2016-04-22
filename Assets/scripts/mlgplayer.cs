using UnityEngine;
using System.Collections;

public class mlgplayer : MonoBehaviour {
	public int numThreads;
	public AudioClip clip;
	private int lastPlayed;
	private AudioSource[] sources;
	public void Start(){
		sources = new AudioSource[numThreads];
		for(int i = 0; i < numThreads; i++){
			sources[i] = gameObject.AddComponent<AudioSource>();
			sources[i].clip = clip;
			sources[i].volume = Volume.Music;
		}
	}

public void play(){
		lastPlayed++;
		if(lastPlayed >= numThreads)lastPlayed = 0;
		sources[lastPlayed].Stop();
		sources[lastPlayed].pitch = Random.value+.5f;
		sources[lastPlayed].volume = Volume.Effect;
		sources[lastPlayed].Play();
	}
}
