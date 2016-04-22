using UnityEngine;
using System.Collections;

public class FedoraPowerup : Powerup {
	public override void OnPickup(GameObject player){
		GetComponent<BoxCollider2D>().enabled = false;
		GetComponent<Rigidbody2D> ().isKinematic = true;
		GameObject eu = GameObject.FindGameObjectWithTag("Euphoria");
		eu.GetComponent<Canvas>().enabled = true;
		eu.GetComponent<EuphoriaColor>().enabled = true;
		gameObject.transform.parent = player.transform;
		gameObject.transform.localPosition = new Vector3(0.037f,0.319f,0);
		gameObject.transform.localScale = new Vector3 (.4f,.4f,1);
		gameObject.transform.localRotation = Quaternion.Euler(0,180,0);
	}
}
