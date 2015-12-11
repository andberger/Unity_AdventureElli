using UnityEngine;
using System.Collections;

public class EnemyLogic : MonoBehaviour {

	public bool isEnemyDead = false;
	public bool enemyMayMove = true;
	public GameObject enemyGameObject;
	public GameManager gameManager;

	private float movement;
	private EdgeCollider2D edge;
	private Rigidbody2D enemyRigidbody;
	private PolygonCollider2D enemyPolyCollider;

	
	// Use this for initialization
	void Start () {
		movement = 10f;
		enemyRigidbody = GetComponent<Rigidbody2D>();
		edge = GetComponent<EdgeCollider2D>();
		enemyPolyCollider = GetComponent<PolygonCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if(enemyMayMove){
			Move();
		}
		if(isEnemyDead){
			enemyMayMove = false;
			enemyRigidbody.velocity = new Vector2(12.5f, 20f);
			enemyPolyCollider.enabled = !enemyPolyCollider.enabled;
			edge.enabled = !edge.enabled;
			StartCoroutine(enemyDeactivate());
			isEnemyDead = false;
			enemyMayMove = true;
		}
	}

	//Logic
	void Move(){
		enemyRigidbody.velocity = new Vector2(movement,enemyRigidbody.velocity.y);
		if(movement > 0f){
			enemyGameObject.transform.eulerAngles = new Vector2(0, 0);
		}
		if(movement < 0f){
			enemyGameObject.transform.eulerAngles = new Vector2(0, 180);
		}
	}

	void enemyDie(){
		isEnemyDead = true;
	}

	public IEnumerator enemyDeactivate(){
		yield return new WaitForSeconds(2.5f);
		gameManager.reset.ResetEnemyPosition();
		enemyGameObject.SetActive(false);
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
