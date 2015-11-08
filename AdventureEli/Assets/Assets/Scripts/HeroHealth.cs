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
	private BoxCollider2D heroBoxCollider;

	// Use this for initialization
	void Start () {
		heroRigidbody = GetComponent<Rigidbody2D>();
		heroBoxCollider = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		//Dead
		if(isDead){
			heroMovement.mayMove = false;
			heroRigidbody.velocity = new Vector2(-12.5f, 20f);
			heroBoxCollider.enabled = !heroBoxCollider.enabled;
			isDead = false;
		}
	}

	void Die(){
		isDead = true;
		numLifes = numLifes - 1;
		faded.a = 0f;
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
		}

	}

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.CompareTag("Enemy") && col.collider.GetType().Equals(typeof(BoxCollider2D)) && !isDead){
			Die();
		}
	}

}
