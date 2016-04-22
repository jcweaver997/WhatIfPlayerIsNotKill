using UnityEngine;
using System.Collections;

public class HealthPack : MonoBehaviour {
	public int healthRestored;

	void OnTriggerEnter2D(Collider2D coll) {
		Health h = coll.gameObject.GetComponent<Health> ();
		if (h != null) {
			GameObject.Destroy(gameObject,0f);
			h.doDamage(-healthRestored);
				}
	}
}
