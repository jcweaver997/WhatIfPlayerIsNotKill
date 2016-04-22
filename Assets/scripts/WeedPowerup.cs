using UnityEngine;
using System.Collections;

public class WeedPowerup : Powerup{
	public float timeScale = .5f;
	public float length = 7;
	public override void OnPickup(GameObject player){
		GetComponent<BoxCollider2D>().enabled = false;
		GetComponent<SpriteRenderer>().enabled = false;
		StartCoroutine("slowmo");

	}

	IEnumerator slowmo(){
		Time.timeScale = timeScale;
		yield return new WaitForSeconds(length/2);
		Time.timeScale = 1;
		Destroy(gameObject,0f);
	}
}
