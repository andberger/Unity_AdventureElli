using UnityEngine;
using System.Collections;

public class HeroMovement : MonoBehaviour {
	
	public float speed = 10f;
	public bool isJumping = false;
	public bool climbStairs = false;
	public bool inWater = false;
	public bool holdingKey = false;
	public bool holdingFlippers = false;
	public bool mayMove = true;
	
	public GameObject key;
	public GameObject Flippers;
	public HeroHealth health;
	private Rigidbody2D heroRigidbody;
	private Transform heroTransform;

	private Vector2 movement;	

	// Use this for initialization
	void Start () {
		heroRigidbody = GetComponent<Rigidbody2D>();
		heroTransform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		//Move
		float h = Input.GetAxisRaw("Horizontal");
		if(mayMove){
			Move (h);
		}
		//Jump
		if(!isJumping && Input.GetKeyDown(KeyCode.Space) && !inWater && mayMove){
			heroRigidbody.velocity = new Vector2(0f, 30f);
			isJumping = true;
		}

		//Climb and swim
		float v = Input.GetAxisRaw("Vertical");
		if(climbStairs || inWater){
			ClimbStairs(v);
			Dive(v);
		}
	}


	//Movements
	
	void Move(float h){
		heroRigidbody.velocity = new Vector2(h * speed,heroRigidbody.velocity.y);
		if(holdingKey){
			key.transform.position = new Vector3(heroTransform.position.x, heroTransform.position.y + 3, heroTransform.position.z);
		}
		if(holdingFlippers){
			key.SetActive(false);
			Flippers.transform.position = new Vector3(heroTransform.position.x, heroTransform.position.y + 3, heroTransform.position.z);
		}
	}

	void ClimbStairs(float v){
		heroRigidbody.velocity = new Vector2(heroRigidbody.velocity.x, v*0.5f*speed);
	}

	void Dive(float v){
		heroRigidbody.velocity = new Vector2(heroRigidbody.velocity.x, v*speed);
	}



	//Collisisons

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.CompareTag("Ground")){
			isJumping = false;
		}

		if(col.gameObject.CompareTag("Blockage") && holdingKey){
			col.gameObject.SetActive(false);
		}
	}






	//Triggers

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.CompareTag("Stairs")){
			climbStairs = true;
		}

		if(col.gameObject.CompareTag("Water")){
			heroRigidbody.velocity = new Vector2(0f, heroRigidbody.velocity.y*2f);
		}

		if (col.gameObject.CompareTag("Key")){
			holdingKey = true;
		}
		if (col.gameObject.CompareTag("Flippers")){
			holdingFlippers = true;
		}
	}

	void OnTriggerStay2D(Collider2D col){
		if(col.gameObject.CompareTag("Water")){
			if(holdingFlippers){
				heroRigidbody.drag = 10f;
				isJumping = true;
				inWater = true;
			}
			else{
				health.Die();
			}
		}
	}

	void OnTriggerExit2D(Collider2D col){
		if(col.gameObject.CompareTag("Stairs")){
			climbStairs = false;
		}

		if(col.gameObject.CompareTag("Water")){
			heroRigidbody.drag = 0f;
			isJumping = false;
			inWater = false;
		}
	}

}

