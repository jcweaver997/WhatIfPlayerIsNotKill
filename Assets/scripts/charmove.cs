

//#undef Andriod
//#define Computer
#define Andriod
#undef Computer

using UnityEngine;
using System.Collections;

public class charmove : MonoBehaviour {
	public float maxSpeed;
	public float accel;
	public float airaccel;
	public float jump;
	public float dFloor;
	public Rect mleft,mright,mshoot,mgrenade, mswitch, mup;
	public SpriteRenderer sleft, sright, sshoot, sgrenade, sswitch, sup;
	public Vector2 buttonSize;
	public float sbDrawZ;

	private bool swapped, swapwasin;
	private box rleft,rright,rshoot,rgrenade, rswitch, rup;
	private Quaternion qright = Quaternion.Euler(0,0,0);
	private Quaternion qleft = Quaternion.Euler(0,180,0);
	private bool isFacingRight;
	private Camera cam;
	private shoot shot;
	private ThrowGrenade throwGrenade;
	void Start(){
		deadScreen.loadAd();

		Physics2D.IgnoreLayerCollision(11,12);
		Physics2D.IgnoreLayerCollision(12,12);

#if Computer
		sleft.enabled = false;
		sright.enabled = false;
		sshoot.enabled = false;
		sgrenade.enabled = false;
		sswitch.enabled = false;
		rsup.enabled = false;
#endif
		#if Andriod
		cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
		shot = GetComponent<shoot>();
		throwGrenade = GetComponent<ThrowGrenade>();


		sleft.transform.position =pw3(new Vector3(mleft.x,mleft.y,2));
		sright.transform.position = pw3(new Vector3(mright.x,mright.y,2));
		sgrenade.transform.position = pw3(new Vector3(mgrenade.x,mgrenade.y,2));
		sshoot.transform.position = pw3(new Vector3(mshoot.x,mshoot.y,2));
		sswitch.transform.position = pw3(new Vector3(mswitch.x,mswitch.y,2));
		sup.transform.position = pw3(new Vector3(mup.x,mup.y,2));

		sleft.transform.localScale = getScale(new Vector2(mleft.width,mleft.height));
		sright.transform.localScale = getScale(new Vector2(mright.width,mright.height));
		sgrenade.transform.localScale = getScale(new Vector2(mgrenade.width,mgrenade.height));
		sshoot.transform.localScale = getScale(new Vector2(mshoot.width,mshoot.height));
		sswitch.transform.localScale = getScale(new Vector2(mswitch.width,mswitch.height));
		sup.transform.localScale = getScale(new Vector2(mup.width,mup.height));

		rleft = new box(mleft);
		rright = new box(mright);
		rgrenade = new box(mgrenade);
		rshoot = new box(mshoot);
		rswitch = new box(mswitch);
		rup = new box(mup);



#endif

		}



	void Update () {
		CompControls();
#if Andriod
		AndControls();
#endif
#if Computer

#endif
	}

	void AndControls(){

		int touchesNum = Input.touchCount;
		swapwasin = false;
		for(int i = 0; i < touchesNum; i ++){

			Vector3 mp = new Vector3(Input.GetTouch(i).position.x,Input.GetTouch(i).position.y,0);
			mp = ps3 (mp);
			if (rleft.isIn (mp)) {
				MoveLeft();
			}
			if (rright.isIn (mp)) {
				MoveRight();
			}
			if (rgrenade.isIn (mp)) {
				throwGrenade.Throw();
			}
			if (rshoot.isIn (mp)) {
				shot.Check();
			}
			if (rup.isIn (mp) && IsGrounded()) {
				GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x,jump);
			}
			if (rswitch.isIn(mp)){
				swapwasin = true;
				if(swapped == false)
				shot.SwitchWeapons();
			}else{

			}
		}
		swapped = swapwasin;

	}

	void CompControls(){
		bool grounded = IsGrounded ();
		if (Input.GetAxisRaw ("Horizontal") > 0) {
			MoveRight();
		} else if (Input.GetAxisRaw ("Horizontal") < 0) {
			MoveLeft();
		}
		if (Input.GetAxisRaw ("Jump")>0 && grounded) {
			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x,jump);
		}
		}

	void MoveLeft(){
		bool grounded = IsGrounded ();
		float move = accel*Time.deltaTime;
		if(!grounded) move *= airaccel;
		
		transform.rotation = qleft;
		
		GetComponent<Rigidbody2D>().velocity = new Vector2(
			GetComponent<Rigidbody2D>().velocity.x-move
			< -maxSpeed?-maxSpeed:GetComponent<Rigidbody2D>().velocity.x-move,
			GetComponent<Rigidbody2D>().velocity.y);
	}
	void MoveRight(){
		bool grounded = IsGrounded ();
		float move = accel*Time.deltaTime;
		if(!grounded) move *= airaccel;
		
		transform.rotation = qright;
		
		GetComponent<Rigidbody2D>().velocity = new Vector2(
			GetComponent<Rigidbody2D>().velocity.x+move
			> maxSpeed?maxSpeed:GetComponent<Rigidbody2D>().velocity.x+move,
			GetComponent<Rigidbody2D>().velocity.y);
		
	}

	Vector3 pw3(Vector3 p){
		Vector3 stw = cam.ScreenToWorldPoint (new Vector3 (Screen.width * p.x, Screen.height * p.y, sbDrawZ));
		return stw;
	}
	Vector3 ps3(Vector3 p){
		return new Vector3 (p.x / Screen.width,p.y / Screen.height,p.z);
		}

	Vector3 getScale(Vector2 scale){
		Vector3 wp = cam.ScreenToWorldPoint(new Vector3(scale.x*Screen.height,scale.y*Screen.height,0));
		Vector3 swp = cam.ScreenToWorldPoint(Vector3.zero);
		return (wp - swp)*(1.0f/buttonSize.x);
	}

	bool IsGrounded(){
		Vector2 pos = new Vector2 (transform.position.x, transform.position.y - dFloor);
		RaycastHit2D rc = Physics2D.Raycast (pos, -Vector2.up,.02f);
		if (rc.collider == null)
						return false;
				else
						return true;
	}

}
