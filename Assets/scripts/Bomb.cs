using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {
	public float radius;
	public float damage;
	public float damageReduction; // 0 = don't do this, 1 = 50% out gets 50% dmg, .5 = 50% out gets 75% dmg
	public float timeDet;
	public Sprite explosion;

	private float countDown;
	void Start () {
		if (damageReduction == 0)
			damageReduction = 1;
	}

	void Update () {
		countDown+=Time.deltaTime;
		if(countDown>=timeDet){
			Det();
		}
	}

	void Det(){

		RaycastHit2D[] rays = Physics2D.CircleCastAll(transform.position, radius, Vector2.zero);
		foreach(RaycastHit2D ray in rays){
			Health h = ray.collider.gameObject.GetComponent<Health>();
			if(h != null){
				float distance = Mathf.Abs(Vector3.Magnitude(ray.collider.gameObject.transform.position - transform.position));
				float perOut = distance/radius;
				if(perOut >1) perOut = 1;
				h.doDamage((int)(((1-perOut)/damageReduction)*damage));
				Debug.Log("did "+((int)(((1-perOut)/damageReduction)*damage))+" to "+ray.collider.gameObject.name);
			}
		}

		SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
		sr.sprite = explosion;
		GameObject.Destroy(gameObject, 1f);

	}
}
