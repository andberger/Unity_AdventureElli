using UnityEngine;
using System.Collections;

public class HeroMovement : MonoBehaviour {
	
	public float speed = 10f;
	public bool isJumping = false;
	public bool climbStairs = false;

	private Rigidbody2D playerRigidbody;

	private Vector2 movement;	

	// Use this for initialization
	void Start () {
		playerRigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		float h = Input.GetAxisRaw("Horizontal");
		Move (h);

		if(!isJumping && Input.GetKeyDown(KeyCode.Space)){
			playerRigidbody.velocity = new Vector2(0f, 30f);
			isJumping = true;
		}

		float v = Input.GetAxisRaw("Vertical");
		if(climbStairs){
			ClimbStairs(v);
		}
	}
	
	void Move(float h){
		playerRigidbody.velocity = new Vector2(h * speed,playerRigidbody.velocity.y);
	}

	void ClimbStairs(float v){
		playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, v*0.5f*speed);
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.CompareTag("Ground")){
			isJumping = false;
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		climbStairs = true;
	}

	void OnTriggerExit2D(Collider2D col){
		climbStairs = false;
	}

}

