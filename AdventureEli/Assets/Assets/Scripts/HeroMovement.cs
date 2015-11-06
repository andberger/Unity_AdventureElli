using UnityEngine;
using System.Collections;

public class HeroMovement : MonoBehaviour {
	
	public float speed = 10f;
	public bool isJumping = false;
	public bool climbStairs = false;
	public bool inWater = false;
	public bool holdingKey = false;

	public GameObject key;
	private Rigidbody2D playerRigidbody;
	private Transform playerTransform;

	private Vector2 movement;	

	// Use this for initialization
	void Start () {
		playerRigidbody = GetComponent<Rigidbody2D>();
		playerTransform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		float h = Input.GetAxisRaw("Horizontal");
		Move (h);

		if(!isJumping && Input.GetKeyDown(KeyCode.Space) && !inWater){
			playerRigidbody.velocity = new Vector2(0f, 30f);
			isJumping = true;
		}

		float v = Input.GetAxisRaw("Vertical");
		if(climbStairs || inWater){
			ClimbStairs(v);
			Dive(v);
		}
	}


	//Movements
	
	void Move(float h){
		playerRigidbody.velocity = new Vector2(h * speed,playerRigidbody.velocity.y);
		if(holdingKey){
			key.transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y + 3, playerTransform.position.z);
		}
	}

	void ClimbStairs(float v){
		playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, v*0.5f*speed);
	}

	void Dive(float v){
		playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, v*speed);
	}



	//Collisisons

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.CompareTag("Ground")){
			isJumping = false;
		}
	}






	//Triggers

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.CompareTag("Stairs")){
			climbStairs = true;
		}

		if(col.gameObject.CompareTag("Water")){
			playerRigidbody.velocity = new Vector2(0f, playerRigidbody.velocity.y*2f);
		}

		if (col.gameObject.CompareTag("Key")){
			holdingKey = true;
		}

	}

	void OnTriggerStay2D(Collider2D col){
		if(col.gameObject.CompareTag("Water")){
			playerRigidbody.drag = 10f;
			isJumping = true;
			inWater = true;
		}
	}

	void OnTriggerExit2D(Collider2D col){
		if(col.gameObject.CompareTag("Stairs")){
			climbStairs = false;
		}

		if(col.gameObject.CompareTag("Water")){
			playerRigidbody.drag = 0f;
			isJumping = false;
			inWater = false;
		}
	}

}

