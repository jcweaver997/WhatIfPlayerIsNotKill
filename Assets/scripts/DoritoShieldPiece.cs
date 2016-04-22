using UnityEngine;
using System.Collections;

public class DoritoShieldPiece : MonoBehaviour {
	public float theta{get;set;}
	public float radius{get;set;}
	public float speed{get;set;}
	public int dmg{get;set;}

	void Update () {
		theta+=speed*Time.deltaTime;
		transform.localPosition = new Vector3(radius*Mathf.Cos (theta),radius*Mathf.Sin(theta),0);
	}
	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag.Equals("Zombie")){
			Health h = col.GetComponent<Health>();
			h.doDamage(dmg);
			GetComponentInParent<DoritoShield>().LostDorito();
			Destroy(gameObject);
		}
	}
}
