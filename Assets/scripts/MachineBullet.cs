using UnityEngine;
using System.Collections;

public class MachineBullet : Bullet{
	// Update is called once per frame
	protected override void OnUpdate () {

		if(facingRight)
			transform.position = new Vector3(transform.position.x+(bulletSpeed*Time.deltaTime), transform.position.y, transform.position.z);
		else
		transform.position = new Vector3(transform.position.x-(bulletSpeed*Time.deltaTime), transform.position.y, transform.position.z);
	}
	protected override void OnWorldHit(){
		Destroy(gameObject,0f);
	}
	protected override void OnEnemyHit(){
		Destroy(gameObject,0f);
	}


}
