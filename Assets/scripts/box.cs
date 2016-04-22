using UnityEngine;
using System.Collections;

public class box{
	private Rect r;
	public box(Rect r){
		this.r = new Rect (r.x-r.width/4f,r.y-r.height/2f,r.width/2,r.height);
		}
	public box(GameObject go){
		BoxCollider2D bc = go.GetComponent<BoxCollider2D> ();
		r = new Rect (
			go.transform.position.x-(bc.size.x*go.transform.localScale.x)/2,
			go.transform.position.y-(bc.size.y*go.transform.localScale.y)/2,
			bc.size.x*go.transform.localScale.x,
			bc.size.y*go.transform.localScale.y);
		}
	public box(Vector3 pos, Vector2 size){
		r = new Rect (
			pos.x-size.x/2,
			pos.y-size.y/2,
			size.x,
			size.y);
	}
	public bool isIn(Vector3 mouse){
		//Debug.Log("test "+mouse.ToString() + " is inside "+ r.ToString());
		if(mouse.x > r.x && mouse.x < r.x + r.width && mouse.y > r.y && mouse.y < r.y + r.height)
			return true;
		return false;
	}
}
