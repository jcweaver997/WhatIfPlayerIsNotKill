using UnityEngine;
using System.Collections;

public class zSpawner : MonoBehaviour {
	public Transform[] locations;
	public float timer;
	public float divisor;
	public float divy;
	public Object zombie;
	public stype type;
	public bool allowSpawning = true;


	private float counter;
	private int roundNum = 0;
	private Quaternion zero = Quaternion.Euler(0,0,0);

	public enum stype{
		roundRobin,random
	}
	

	void Update () {
		if(!allowSpawning)
			return;
		counter += Time.deltaTime;
		if (counter > timer) {
			counter = 0;
			if(locations.Length > 0)Spawn();
				}

	}

	public void setSpawn(GameObject go){
		zombie = go;
	}

	public GameObject Spawn(){
		GameObject go = null;
		timer /= divisor;
		divisor = (divisor - 1)/divy;
		divisor+=1;
		switch (type) {
		case stype.roundRobin:
			go = (GameObject)Instantiate(zombie,locations[roundNum].position,zero);
			roundNum++;
			if(roundNum >= locations.Length)roundNum = 0;
			break;
		case stype.random:
			go = (GameObject)Instantiate(zombie,locations[(int)(Random.value*(locations.Length))].position,zero);
			break;
		}
		return go;
	}
}
