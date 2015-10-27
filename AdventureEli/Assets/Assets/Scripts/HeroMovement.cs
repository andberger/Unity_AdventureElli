using UnityEngine;
using System.Collections;

public class HeroMovement : MonoBehaviour {
	
	public float speed = 10f;

	private Rigidbody2D playerRigidbody;

	private Vector2 movement;	

	// Use this for initialization
	void Start () {
		playerRigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		float h = Input.GetAxisRaw("Horizontal");
		Move (h);

		if(Input.GetKeyDown(KeyCode.Space)){
			playerRigidbody.velocity = new Vector2(0f, 30f);
		}
	}
	
	void Move(float h){
		playerRigidbody.velocity = new Vector2(h * speed,playerRigidbody.velocity.y);
	}

}

