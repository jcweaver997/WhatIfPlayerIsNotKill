using UnityEngine;
using System.Collections;

public class doritoFall : MonoBehaviour {
	public RoundStatus rs;
	public LightFlash lf1,lf2;
	public Light main;
	private ParticleSystem ps;
	private bool startPS;
	void Start(){
		ps = GetComponent<ParticleSystem>();
	}
	void Update () {
		if(rs.curRound >3){
			if(!startPS)
			{
				ps.Play();
				startPS = true;
			}
				if(rs.curRound>4){
				main.enabled = false;
				lf1.enable = true;
				lf2.enable = true;
			}
		}
	}
}
