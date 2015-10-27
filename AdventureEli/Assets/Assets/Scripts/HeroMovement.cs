using UnityEngine;
using System.Collections;

public class HeroMovement : MonoBehaviour {
	
	public float speed = 9.5f;
	public float climbSpeed = 0.5f;
	public float jumpHeight = 10f;
	public bool mayJump = false;
	public bool onWall = false;
	
	Vector2 movement;
	Rigidbody playerRigidbody;
	// Use this for initialization
	void Awake () {
		playerRigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float h = Input.GetAxisRaw("Horizontal");
		Move(h);
	}
	
	void Move(float h){
		movement.Set(h,0f);
		movement = movement.normalized * speed* Time.deltaTime;


		playerRigidbody.MovePosition (new Vector2(transform.position.x, transform.position.y) + movement);
	}

}

