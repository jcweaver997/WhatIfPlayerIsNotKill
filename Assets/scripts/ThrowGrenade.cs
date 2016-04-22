using UnityEngine;
using System.Collections;

public class ThrowGrenade : MonoBehaviour {
	public int count;
	public float timeout;
	public Object grenadePrefab;
	public Vector2 offset;

	private float timeoutCounter;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		timeoutCounter += Time.deltaTime;
		if(Input.GetAxisRaw("Grenade")>0){
			Throw();
		}
	}
	public void Throw(){
				if (timeoutCounter >= timeout) {
						if (transform.rotation.eulerAngles.y == 0)
								GameObject.Instantiate (grenadePrefab,
			                       new Vector3 (transform.position.x + offset.x, transform.position.y + offset.y, transform.position.z),
			                       transform.rotation);
						else
								GameObject.Instantiate (grenadePrefab,
			                       new Vector3 (transform.position.x - offset.x, transform.position.y + offset.y, transform.position.z),
			                       transform.rotation);
						timeoutCounter = 0;

				}
		}
}
