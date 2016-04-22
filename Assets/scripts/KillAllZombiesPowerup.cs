using UnityEngine;
using System.Collections;

public class KillAllZombiesPowerup : Powerup{
	public int dmg = 10;
	public override void OnPickup(GameObject player){
		GameObject[] zombies = GameObject.FindGameObjectsWithTag("Zombie");
		foreach(GameObject zombie in zombies){
			zombie.GetComponent<Health>().doDamage(dmg);
		}
		Destroy(gameObject);
	}
}
