using UnityEngine;
using System.Collections;
//[System.Serializable]
public abstract class Bullet : MonoBehaviour {
	public float bulletSpeed;
	public int bulletDamage;
	protected bool facingRight;

	// Use this for initialization
	void Start () {
		facingRight = transform.rotation.eulerAngles.y == 0;
		Destroy(gameObject,10f);
		OnStart();
	}
	void Update(){
		OnUpdate();
	}

	protected virtual void OnStart(){

	}
	protected virtual void OnUpdate(){

	}
	protected virtual void OnWorldHit(){

	}
	protected virtual void OnEnemyHit(){

	}

	void OnCollisionEnter2D(Collision2D coll) {
		if(coll.gameObject.tag.Equals("Map"))
			OnWorldHit();
		else
		if(coll.gameObject.tag.Equals("Zombie")){
			Health zom = coll.gameObject.GetComponent<Health>();
			if(bulletDamage>0)
			zom.doDamage(bulletDamage);
			OnEnemyHit();
		}
	}
}
