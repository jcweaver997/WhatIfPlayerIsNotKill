using UnityEngine;
using System.Collections;


public class jumpPab : MonoBehaviour {
	public static System.Collections.Generic.List<Vector3> pos;
	public bool enable = true;
	public float power, max;

	void Start(){
		if(pos==null){
			pos = new System.Collections.Generic.List<Vector3>();
		}
		pos.Add(transform.position);
	}


	void OnTriggerEnter2D(Collider2D col){
		Trigg (col);
	}

	void OnTriggerStay2D(Collider2D col){
		Trigg (col);
	}

	void Trigg(Collider2D col){
		if (!enable)
			return;
		if(col.tag.Equals("Bullet"))return;
		Rigidbody2D rc = col.attachedRigidbody;
		float npower = rc.velocity.y+(power*Time.fixedDeltaTime);
		rc.velocity = new Vector2(rc.velocity.x,npower > max ? max : npower);
	}
}
