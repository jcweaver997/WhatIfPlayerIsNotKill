using UnityEngine;
using System.Collections;

public class DoritoShield : MonoBehaviour {
	public int numDoritos;
	public float radius;
	public float speed;
	public int dmg;
	public Object dorito;
	public Transform followTransform{get;set;}

	void Start () {
		for(int i = 0; i < numDoritos; i++){
			GameObject dori = (GameObject)Instantiate(dorito,transform.position,transform.rotation);
			dori.transform.parent = transform;
			DoritoShieldPiece dsp = dori.GetComponent<DoritoShieldPiece>();
			dsp.radius = radius;
			dsp.theta = 2*Mathf.PI*(i/(float)numDoritos);
			dsp.speed = speed;
			dsp.dmg = dmg;
		}
	}
	public void LostDorito(){
		numDoritos--;
	}

	void Update () {
		if(numDoritos <= 0){
			Destroy(gameObject);
		}
		transform.position = followTransform.position;
	}
}
