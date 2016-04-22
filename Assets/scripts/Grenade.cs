using UnityEngine;
using System.Collections;

public class Grenade : MonoBehaviour {
	public float radius;
	public float damage;
	public float playerDamageReduction;
	public float timeDet;
	public float pushForce;
	public Vector2 initialVel;

	public Sprite explosion;

	private bool exploded = false;
	private float countDown;
	void Start () {
		if(transform.rotation.eulerAngles.y == 0){
			GetComponent<Rigidbody2D>().velocity = initialVel;
		}else{
			GetComponent<Rigidbody2D>().velocity = new Vector2(-initialVel.x,initialVel.y);
		}

	}
	
	void Update () {
		if(exploded)
			return;
		countDown+=Time.deltaTime;
		if(countDown>=timeDet){
			Det();
		}
	}
	
	void Det(){
		exploded = true;
		RaycastHit2D[] rays = Physics2D.CircleCastAll(transform.position, radius, Vector2.zero);
		foreach(RaycastHit2D ray in rays){
			Health h = ray.collider.gameObject.GetComponent<Health>();
			if(h != null){
				float distance = Mathf.Abs(Vector3.Magnitude(ray.collider.gameObject.transform.position - transform.position));
				float perOut = distance/radius;
				if(perOut >1) perOut = 1;
				float damagetodo = (1-perOut)*damage;
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
		
		SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
		sr.sprite = explosion;
		GameObject.Destroy(gameObject, .5f);
		
	}
}
