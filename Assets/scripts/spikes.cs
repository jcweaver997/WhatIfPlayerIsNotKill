using UnityEngine;
using System.Collections;

public class spikes : MonoBehaviour {
	public int dmg;
	public bool enable{get;set;}
	void Start(){
		enable = true;
	}
	void OnCollisionEnter2D(Collision2D coll) {
		if(!enable)return;
		Health h = coll.collider.gameObject.GetComponent<Health>();
		if(h!=null){
			h.doDamage(dmg);
		}
	}
	void OnCollisionStay2D(Collision2D coll) {
		if(!enable)return;
		Health h = coll.collider.gameObject.GetComponent<Health>();
		if(h!=null){
			h.doDamage(dmg);
		}
	}
}
