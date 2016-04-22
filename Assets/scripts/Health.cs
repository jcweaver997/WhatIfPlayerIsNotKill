using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	public int maxHealth;
	public float regenTime;
	public int health;
	public float damageTimeout;
	public GameObject healthBarRed, healthBarGreen;
	public ParticleSystem blood;
	public Vector2 healthBarSize;
	public bool hasDied{get;set;}
	public mlgplayer audsource;
	
	private float scale;
	private float regenCounter;
	private float damageCounter;

	// Use this for initialization
	void Start () {
		scale = healthBarRed.transform.localScale.x;
		healthBarSize *= scale;
		GameObject go = GameObject.FindGameObjectWithTag("mlg");
		if(go!=null)
		audsource = go.GetComponent<mlgplayer>();

		health = maxHealth;


	}

	public void doDamage(int dmg){
		if(damageCounter>=damageTimeout){
		health= health - dmg;
			damageCounter = 0;
			if(dmg>0){
				if (audsource!=null){
					audsource.play();
				}
				spawnBlood(dmg*2);
			}
		}

		if (health < 0) health = 0;
		if (health > maxHealth)
						health = maxHealth;
		if(health == 0) hasDied = true;

	}

	void spawnBlood(int num){
		/*
		for(int i = 0; i < num; i++){
			GameObject k = (GameObject)Instantiate(blood,transform.position,transform.rotation);
			k.GetComponent<Rigidbody2D>().angularVelocity = Random.value*6000-3000;
			k.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.value*6-3, Random.value*3);
			Destroy(k,Random.value*4+1);
		}
		*/
		blood.Emit(num);
	}

	// Update is called once per frame
	void Update () {

		float mult = (1 - (float)health / maxHealth);

		healthBarRed.transform.position = new Vector3(healthBarRed.transform.position.x,healthBarRed.transform.position.y,.0f);
		healthBarGreen.transform.position = new Vector3(healthBarGreen.transform.position.x,healthBarGreen.transform.position.y,.0f);
		healthBarRed.transform.localScale = new Vector3 (scale*mult,scale,scale);

		healthBarRed.transform.position = new Vector3(healthBarSize.x/2-(mult*scale*healthBarSize.x)+healthBarGreen.transform.position.x,
		                                              healthBarRed.transform.position.y,
		                                              healthBarRed.transform.position.z);

		damageCounter+=Time.deltaTime;

		regenCounter+=Time.deltaTime;
		if(regenCounter>=regenTime){
			regenCounter = 0;
			if (health < maxHealth && health != 0)
				health++;
		}
	}
}
