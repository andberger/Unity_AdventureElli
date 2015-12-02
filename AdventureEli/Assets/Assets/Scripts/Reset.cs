using UnityEngine;
using System.Collections;

public class Reset : MonoBehaviour {
	private Vector3 origPosition;
	private Vector3 origKeyPosition;
	private Vector3 origEOnePosition;
	private Vector3 origETwoPosition;
	private Vector3 origEThreePosition;
	private Vector3 origVelocity;
	private bool origPolyColliderStatus;
	private bool origMayMove;

	public HeroMovement heroMovement;
	public HeroHealth heroHealth;
	public GameObject key;
	public GameObject enemy1;
	public GameObject enemy2;
	public GameObject enemy3;
	private Transform transform;
	private Rigidbody2D rigidbody;
	private PolygonCollider2D polyCollider;

	// Use this for initialization
	void Start () {
		transform = GetComponent<Transform>();
		rigidbody = GetComponent<Rigidbody2D>();
		polyCollider = GetComponent<PolygonCollider2D>();
		origPosition = transform.position;
		origVelocity = rigidbody.velocity;
		origPolyColliderStatus = polyCollider.enabled;
		origMayMove = heroMovement.mayMove;
		origKeyPosition = key.transform.position;
		origEOnePosition = enemy1.transform.position;
		origETwoPosition = enemy2.transform.position;
		origEThreePosition = enemy3.transform.position;
	}
	
	public void ResetHeroPosition(){
		transform.position = origPosition;
		rigidbody.velocity = origVelocity;
		polyCollider.enabled = origPolyColliderStatus;
		if(heroHealth.numLifes == 0){
			heroMovement.mayMove = false;
		}
		else{
			heroMovement.mayMove = origMayMove;
		}
	}

	public void ResetKeyPosition(){
		key.transform.position = origKeyPosition;
	}

	public void ResetEnemyPosition(){
		enemy1.transform.position = origEOnePosition;
		enemy2.transform.position = origETwoPosition;
		enemy3.transform.position = origEThreePosition;
	}

	public void ResetEnemyActivation(){
		enemy1.SetActive(true);
		enemy2.SetActive(true);
		enemy3.SetActive(true);
		
		PolygonCollider2D polyE1 = enemy1.GetComponent<PolygonCollider2D>();
		EdgeCollider2D edgeE1 = enemy1.GetComponent<EdgeCollider2D>();
		polyE1.enabled = true;
		edgeE1.enabled = true;
		
		PolygonCollider2D polyE2 = enemy2.GetComponent<PolygonCollider2D>();
		EdgeCollider2D edgeE2 = enemy2.GetComponent<EdgeCollider2D>();
		polyE2.enabled = true;
		edgeE2.enabled = true;
		
		PolygonCollider2D polyE3 = enemy3.GetComponent<PolygonCollider2D>();
		EdgeCollider2D edgeE3 = enemy3.GetComponent<EdgeCollider2D>();
		polyE3.enabled = true;
		edgeE3.enabled = true;
	}
}
