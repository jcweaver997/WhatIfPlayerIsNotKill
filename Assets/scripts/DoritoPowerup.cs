using UnityEngine;
using System.Collections;

public class DoritoPowerup : Powerup{
	public Object shield;
	public override void OnPickup(GameObject player){
		GameObject s = (GameObject)Instantiate(shield,player.transform.position,player.transform.rotation);
		s.GetComponent<DoritoShield>().followTransform = player.transform;
		Destroy(gameObject,0);
	}
}
