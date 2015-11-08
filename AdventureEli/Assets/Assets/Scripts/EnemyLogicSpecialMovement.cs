using UnityEngine;
using System.Collections;

public class EnemyLogicSpecialMovement : MonoBehaviour {
	
	public float movement;
	
	private Rigidbody2D enemyRigidbody;
	
	
	// Use this for initialization
	void Start () {
		movement = 10f;
		enemyRigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		Move();
	}
	
	void Move(){
		enemyRigidbody.velocity = new Vector2(movement,enemyRigidbody.velocity.y);
	}
	
	
	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.CompareTag("Ground") && movement < 0){
			movement = 10f;
		}
		else{
			movement = -10f;
		}
	}
	
	//For Special Movement Enemy.
	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.name == "BrownGrass_special" || col.gameObject.name == "BrownGrass_special2"){
			enemyRigidbody.velocity = new Vector2(0f, 20f);
		}
	}
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
