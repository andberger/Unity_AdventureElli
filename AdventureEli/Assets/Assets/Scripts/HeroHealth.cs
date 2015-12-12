using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HeroHealth : MonoBehaviour {

	public int numLifes;
	public bool isDead = false;
	public Color faded = new Color(255f,255f,255f,0f);
	public HeroMovement heroMovement;
	public GameManager gameManager;

	public Image heart1;
	public Image heart2;
	public Image heart3;

	private Rigidbody2D heroRigidbody;
	private PolygonCollider2D heroPolyCollider;

	// Use this for initialization
	void Start () {
		heroRigidbody = GetComponent<Rigidbody2D>();
		heroPolyCollider = GetComponent<PolygonCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		//Dead
		if(isDead){
			heroMovement.mayMove = false;
			heroRigidbody.velocity = new Vector2(-12.5f, 20f);
			heroPolyCollider.enabled = !heroPolyCollider.enabled;
			heroMovement.holdingKey = false;
			heroMovement.holdingFlippers = false;
			heroMovement.holdingIceaxes = false;
			heroMovement.Flippers.SetActive(true);
			heroMovement.Iceaxes.SetActive(true);
			heroMovement.Blockage.SetActive(true);
			heroMovement.key.SetActive(true);
			isDead = false;
		}
	}

	public void Die(){
		transform.eulerAngles = new Vector3(0, transform.rotation.y, 270);
		isDead = true;
		numLifes = numLifes - 1;
		if(numLifes == 2){
			heart3.color = faded;
			StartCoroutine(gameManager.RestartLevel());
		}
		if(numLifes == 1){
			heart2.color = faded;
			StartCoroutine(gameManager.RestartLevel());
		}
		if(numLifes == 0){
			heart1.color = faded;
			StartCoroutine(gameManager.RestartLevel());
			gameManager.BackToMainMenu();
			heroMovement.mayMove = false;
		}

	}

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.CompareTag("Enemy") && col.collider.GetType().Equals(typeof(PolygonCollider2D)) && !isDead){
			Die();
		}
		if(col.gameObject.CompareTag("Spikes")){
			Die ();
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.CompareTag("OutOfMap")){
			Die ();
		}
	}

}
