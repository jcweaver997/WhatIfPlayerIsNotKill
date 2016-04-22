using UnityEngine;
using System.Collections;

public class DmgPowerup : Powerup{
	public float time = 7f;
	public override void OnPickup(GameObject player){
		GetComponent<BoxCollider2D>().enabled = false;
		GetComponent<SpriteRenderer>().enabled = false;
		StartCoroutine("doubleDamage");
	}
	IEnumerator doubleDamage(){
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		shoot s = player.GetComponent<shoot>();
		foreach(Gun g in s.guns){
			GameObject bullet = (GameObject)g.bullet;
			bullet.GetComponent<Bullet>().bulletDamage *=2;
			bullet.GetComponent<SpriteRenderer>().color = new Color(1,0,0);
		}

		yield return new WaitForSeconds(time);
		foreach(Gun g in s.guns){
			GameObject bullet = (GameObject)g.bullet;
			bullet.GetComponent<Bullet>().bulletDamage /=2;
			bullet.GetComponent<SpriteRenderer>().color = new Color(1,1,1);
		}
		Destroy(gameObject);
	}
}
