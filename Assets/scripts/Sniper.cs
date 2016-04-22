using UnityEngine;
using System.Collections;

public class Sniper : Gun{
	public Object casing;
	public Vector2 casingOffset;
	public SpriteRenderer msr;
	protected override void OnShoot(){
		GameObject k = (GameObject)Instantiate(casing,transform.position, Quaternion.Euler(0,0,0));
		k.GetComponent<Rigidbody2D>().angularVelocity = Random.value*6000-3000;
		k.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.value*2-1,Random.value);
		Destroy(k,5f);

		StartCoroutine ("muzzleFlash");
	}
	IEnumerator muzzleFlash(){
		msr.enabled = true;
		yield return new WaitForSeconds (.1f);
		msr.enabled = false;
		}
}
