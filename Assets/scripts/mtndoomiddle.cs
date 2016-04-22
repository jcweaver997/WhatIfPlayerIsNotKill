using UnityEngine;
using System.Collections;

public class mtndoomiddle : MonoBehaviour {
	public float top,bottom;
	public float maxSpeed;
	public float accel;
	public float timeTop, timeBot;
	public jumpPab pad1, pad2;

	private float speed;
	private float counter;
	private State curState;
	private spikes spike;
	private enum State{
		Top,Bottom,Rising,Lowering
	}
	// Use this for initialization
	void Start () {
		curState = State.Top;
		counter = 0;
		spike = GetComponentInChildren<spikes>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		counter-=Time.fixedDeltaTime;
		if (counter <= 0){
			switch(curState){
			case State.Bottom:
				pad1.enable = false;
				pad2.enable = false;
				spike.enable = false;
				curState = State.Rising;
				break;
			case State.Top:
				spike.enable = true;
				curState = State.Lowering;
				break;
			default:
				break;
			}
		}
		if(curState == State.Rising){
			speed += accel * Time.fixedDeltaTime;
			if(speed > maxSpeed) speed = maxSpeed;
			transform.position = new Vector3(transform.position.x,transform.position.y + speed, transform.position.z);
			if(transform.position.y >= top){
				transform.position = new Vector3(transform.position.x,top, transform.position.z);
				curState = State.Top;
				counter = timeTop;
				speed = 0;
			}
		}else
		if(curState == State.Lowering){
			speed -= accel * Time.deltaTime;
			if(speed < -maxSpeed) speed = -maxSpeed;
			transform.position = new Vector3(transform.position.x,transform.position.y + speed, transform.position.z);
			if(transform.position.y <= bottom){
				transform.position = new Vector3(transform.position.x,bottom, transform.position.z);
				curState = State.Bottom;
				pad1.enable = true;
				pad2.enable = true;
				counter = timeBot;
				speed = 0;
			}
		}

	
	}
}
