using UnityEngine;
using System.Collections;

public abstract class Powerup : MonoBehaviour{

	public abstract void OnPickup(GameObject player);
	public void OnTriggerEnter2D(Collider2D other){
		if(!other.gameObject.tag.Equals("Player"))
			return;
		OnPickup(other.gameObject);
	}
}
