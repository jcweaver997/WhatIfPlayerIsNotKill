using UnityEngine;
using System.Collections;

public class zombie : MonoBehaviour {
	private Transform closest;
	private float timeTillTick = 3;
	private float counter = 0;
	public float speed;
	public float accel;
	public float airAccel;
	public float dFloor;
	public float dFollowTo;
	public int damage;
	public float powerupPercent;

	private Vector3 closestPad;
	private GameScript gs;
	private Health myHealth;
	private bool died;
	private Quaternion qright = Quaternion.Euler(0,0,0);
	private Quaternion qleft = Quaternion.Euler(0,180,0);
	// Use this for initialization
	void Start () {
		OnTick();
		myHealth = GetComponent<Health>();
		gs = GameObject.FindGameObjectWithTag("GC").GetComponent<GameScript>();
		closestPad = Vector3.zero;

	}

	// Update is called once per frame
	void Update () {
		if(died)return;
		if(myHealth.hasDied){
			gs.killedZombie();
			SpriteRenderer[] srs = GetComponentsInChildren<SpriteRenderer>();
			foreach(SpriteRenderer szxczc in srs){
				szxczc.enabled = false;
			}
			if(powerupPercent>Random.value)
			GameObject.FindGameObjectWithTag("Powerups").GetComponent<PowerupList>().SpawnPowerup(transform.position);
			GetComponent<SpriteRenderer>().enabled = false;
			GetComponent<BoxCollider2D>().enabled = false;
			GetComponent<CircleCollider2D>().enabled = false;
				Destroy(gameObject,2f);
			died = true;
			return;
		}
		StartCoroutine("FindClosestPad");

		counter += Time.deltaTime;
		if (counter>timeTillTick){
			OnTick();
			counter = 0;
		}

		Goto (closest.position);


	}
	void MoveX(float dif){
		bool grounded = IsGrounded ();
		
		if (dif > dFollowTo) {
			float move = accel*Time.deltaTime;
			if(!grounded) move *= airAccel;
			
			transform.rotation = qleft;
			
			GetComponent<Rigidbody2D>().velocity = new Vector2(
				GetComponent<Rigidbody2D>().velocity.x-move
				< -speed?-speed:GetComponent<Rigidbody2D>().velocity.x-move,
				GetComponent<Rigidbody2D>().velocity.y);
			
		} else if (dif < -dFollowTo){
			
			float move = accel*Time.deltaTime;
			if(!grounded) move *= airAccel;
			
			transform.rotation = qright;
			
			GetComponent<Rigidbody2D>().velocity = new Vector2(
				GetComponent<Rigidbody2D>().velocity.x+move
				> speed?speed:GetComponent<Rigidbody2D>().velocity.x+move,
				GetComponent<Rigidbody2D>().velocity.y);
		}
	}

	void Goto(Vector3 pos){
		if(Mathf.Abs(transform.position.y-pos.y)<.1f){
			//Debug.Log ("Player is on this layer because "+transform.position.y+"-"+pos.y+" = "+(Mathf.Abs(transform.position.y-pos.y)));
			MoveX(transform.position.x-pos.x);
		}else{
			//Debug.Log ("Player not on this layer, finding pad");
			MoveX(transform.position.x-closestPad.x);
		}
	}
	IEnumerator FindClosestPad(){
		string toLog = "";
		float minmag = 1000f;
		Vector3 min = closest.position;
		foreach(Vector3 v in jumpPab.pos){
			if(transform.position.y-v.y>1.5f || transform.position.y-v.y<-.5f){
				toLog+="pad on another layer; ";
			}else
			if(Mathf.Abs(closest.position.x-v.x)<minmag){
				min = v;
				minmag = Mathf.Abs(closest.position.x-v.x);
				toLog+="new minmag found at "+minmag+"; ";
			}
			yield return null;
		}
		toLog+="pad updated ;";
		//Debug.Log(toLog);
		closestPad = min;

	}


	void OnTick(){
		GameObject[] go = GameObject.FindGameObjectsWithTag("Player");
		if(go.Length == 0)
			closest = transform;
		else{
			int i = 0;
			float distance = Vector3.Magnitude(transform.position - go[0].transform.position);
			for(int r = 1; r < go.Length; i++){
				float tdis = Vector3.Magnitude(transform.position - go[r].transform.position);
				if (tdis < distance){
					i = r;
					distance = tdis;
				}
			}
			closest = go[i].transform;
		}
	}

	bool IsGrounded(){
		Vector2 pos = new Vector2 (transform.position.x, transform.position.y - dFloor);
		RaycastHit2D rc = Physics2D.Raycast (pos, -Vector2.up,.02f);
		if (rc.collider == null)
			return false;
		else
			return true;
	}


	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag.Equals("Player")){
			col.gameObject.GetComponent<Health>().doDamage(damage);
		}
	}
	void OnCollisionStay2D(Collision2D col){
		if (col.gameObject.tag.Equals("Player")){
			col.gameObject.GetComponent<Health>().doDamage(damage);
		}
	}




}
