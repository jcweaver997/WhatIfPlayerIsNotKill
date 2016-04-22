using UnityEngine;
using System.Collections;

public class shoot : MonoBehaviour {
	public Gun[] guns;
	public int curGunNum;
	private Gun curGun;
	public Vector2 offset;

	private bool switched;
	private float counter;
	private Quaternion qright = Quaternion.Euler(0,0,0);
	private Quaternion qleft = Quaternion.Euler(0,180,0);

	void Start () {
		curGun = guns[curGunNum];
		curGun.numBullets = curGun.maxBullets;
		curGun.gameObject.GetComponent<SpriteRenderer>().enabled = true;
	}

	void Update () {
		counter -= Time.deltaTime;
		if (Input.GetAxisRaw("Fire1")==1)
						Check ();
		if (Input.GetAxisRaw("weaponSwitch")==1){
			if(!switched){
				SwitchWeapons();
				switched = true;
			}
		}else switched = false;

	}
	public void SwitchWeapons(){
		guns[curGunNum].gameObject.GetComponent<SpriteRenderer>().enabled = false;
		curGunNum++;
		if(curGunNum >= guns.Length)
			curGunNum = 0;
		curGun = guns[curGunNum];
		guns[curGunNum].gameObject.GetComponent<SpriteRenderer>().enabled = true;
	}

	public void Check(){
		if (counter <= 0)
			OnTick ();
	}

	void OnTick(){
		if (curGun.numBullets == 0)
						curGun.numBullets = curGun.maxBullets;
		curGun.numBullets--;
		shot ();
		curGun.Shoot();

		if (curGun.numBullets == 0)
						counter = curGun.reloadTime;
				else
						counter = curGun.waitTime;

	}

	void shot(){
		if (transform.rotation.eulerAngles.y == 0) {
			Instantiate (curGun.bullet, new Vector3 (transform.position.x + offset.x, transform.position.y+offset.y, transform.position.z), qright);
				} else {
			Instantiate (curGun.bullet,new Vector3(transform.position.x-offset.x,transform.position.y+offset.y,transform.position.z),qleft);
				}


	}
}
