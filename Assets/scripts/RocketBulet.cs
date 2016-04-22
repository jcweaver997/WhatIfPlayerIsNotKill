using UnityEngine;
using System.Collections;

public class RocketBulet : Bullet{
	public float radius;
	public float playerDamageReduction;
	public float pushForce;
	public Vector2 initialVelocity;
	
	// Use this for initialization
	protected override void OnStart () {
		GetComponent<Rigidbody2D>().velocity = new Vector2(initialVelocity.x*(facingRight?1:-1),initialVelocity.y);
	}

	protected override void OnWorldHit(){
		Det ();
	}
	protected override void OnEnemyHit(){
		Det ();
	}

	void Det(){

		RaycastHit2D[] rays = Physics2D.CircleCastAll(transform.position, radius, Vector2.zero);
		foreach(RaycastHit2D ray in rays){
			Health h = ray.collider.gameObject.GetComponent<Health>();
			if(h != null){
				float distance = Mathf.Abs(Vector3.Magnitude(ray.collider.gameObject.transform.position - transform.position));
				float perOut = distance/radius;
				if(perOut >1) perOut = 1;
				float damagetodo = (1-perOut)*bulletDamage;
				if(ray.collider.tag.Equals("Player")){
					h.doDamage((int)(damagetodo*playerDamageReduction));
				}else{
					h.doDamage((int)damagetodo);
				}
			}
			Rigidbody2D r = ray.collider.gameObject.GetComponent<Rigidbody2D>();
			if(r!=null){
				Vector3 dif = r.gameObject.transform.position - transform.position;
				float mag = dif.magnitude/(radius*1.5f);
				if(mag >1) mag = 1;
				float forcemag = (1-mag)*pushForce;
				Vector3 unitv = dif.normalized;
				Vector2 force = new Vector2(unitv.x,unitv.y)*forcemag;
				r.AddForce(force);
				
			}
		}
		GameObject.Destroy(gameObject, 0f);
		
	}




}
