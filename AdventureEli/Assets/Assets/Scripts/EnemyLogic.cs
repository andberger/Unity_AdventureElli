using UnityEngine;
using System.Collections;

public class EnemyLogic : MonoBehaviour {

	public bool isEnemyDead = false;
	public bool enemyMayMove = true;
	public GameObject enemyGameObject;

	private float movement;
	private EdgeCollider2D edge;
	private Rigidbody2D enemyRigidbody;
	private BoxCollider2D enemyBoxCollider;

	
	// Use this for initialization
	void Start () {
		movement = 10f;
		enemyRigidbody = GetComponent<Rigidbody2D>();
		edge = GetComponent<EdgeCollider2D>();
		enemyBoxCollider = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if(enemyMayMove){
			Move();
		}
		if(isEnemyDead){
			enemyMayMove = false;
			enemyRigidbody.velocity = new Vector2(12.5f, 20f);
			enemyBoxCollider.enabled = !enemyBoxCollider.enabled;
			edge.enabled = !edge.enabled;
			isEnemyDead = false;
		}
	}

	//Logic
	void Move(){
		enemyRigidbody.velocity = new Vector2(movement,enemyRigidbody.velocity.y);
	}

	void enemyDie(){
		isEnemyDead = true;
		Destroy(enemyGameObject,3f);
	}



	//Collisisons
	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.CompareTag("Player") && edge.IsTouching(col.collider)){
			enemyDie();
		}
		//For Special Movement Enemy.
		if(col.gameObject.name == "BrownGrass_special" || col.gameObject.name == "BrownGrass_special2"){
			enemyRigidbody.velocity = new Vector2(0f, 20f);
		}
	}


	//Triggers
	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.CompareTag("Ground") && movement < 0){
			movement = 10f;
		}
		else{
			movement = -10f;
		}
	}




	//For Special Movement Enemy.
	void OnCollisionStay2D(Collision2D col){
		if(col.gameObject.name == "BrownGrass_special" || col.gameObject.name == "BrownGrass_special2"){
			enemyRigidbody.velocity = new Vector2(0f, 20f);
		}
	}
	void OnCollisionExit2D(Collision2D col){
		if(col.gameObject.name == "BrownGrass_special" || col.gameObject.name == "BrownGrass_special2"){
			enemyRigidbody.velocity = new Vector2(0f, 20f);
		}
	}


}
