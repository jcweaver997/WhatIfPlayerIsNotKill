using UnityEngine;
using System.Collections;

public class PillPowerup : Powerup {
	public override void OnPickup(GameObject player){
		GetComponent<BoxCollider2D>().enabled = false;
		GetComponent<SpriteRenderer>().enabled = false;
		StartCoroutine("inv", player);
	}
	IEnumerator inv(GameObject player){
		StartCoroutine ("colors",player);
		float dto = player.GetComponent<Health>().damageTimeout;
		player.GetComponent<Health>().damageTimeout = 100000;
		yield return new WaitForSeconds(6f);
		StopCoroutine ("colors");
		player.GetComponent<Health>().damageTimeout = dto;
		player.GetComponent<SpriteRenderer>().color = new Color(1,1,1);
		Destroy(gameObject,0f);
	}
	IEnumerator colors(GameObject player){
		SpriteRenderer sr = player.GetComponent<SpriteRenderer>();
		for(;;){
			sr.color = new Color(Mathf.PerlinNoise(Time.time,0),Mathf.PerlinNoise(Time.time*2,0),Mathf.PerlinNoise(Time.time/2,0),.5f);
			yield return null;
		}
	}
}
