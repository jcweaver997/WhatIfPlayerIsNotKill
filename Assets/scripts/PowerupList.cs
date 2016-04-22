using UnityEngine;
using System.Collections;

public class PowerupList : MonoBehaviour {
	public Object[] powerups;
	public void SpawnPowerup(Vector3 pos){
		Instantiate(powerups[Random.Range(0,powerups.Length)],pos,Quaternion.Euler(Vector3.zero));
	}
}
