using UnityEngine;
using System.Collections;

public class EnemyLogic : MonoBehaviour {

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
}
