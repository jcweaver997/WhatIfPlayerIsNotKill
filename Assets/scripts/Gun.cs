using UnityEngine;
using System.Collections;

public abstract class Gun : MonoBehaviour{
	public float waitTime;
	public float reloadTime;
	public int maxBullets;
	public Object bullet;
	public int numBullets;

	protected float counter;
	protected Quaternion qright = Quaternion.Euler(0,0,0);
	protected Quaternion qleft = Quaternion.Euler(0,180,0);

	protected abstract void OnShoot();
	public void Shoot(){
		OnShoot();
	}


}
