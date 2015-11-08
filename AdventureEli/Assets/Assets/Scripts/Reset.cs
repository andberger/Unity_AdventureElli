using UnityEngine;
using System.Collections;

public class Reset : MonoBehaviour {
	private Vector3 origPosition;
	private Vector3 origVelocity;
	private bool origBoxColliderStatus;
	private bool origMayMove;

	public HeroMovement heroMovement;
	private Transform transform;
	private Rigidbody2D rigidbody;
	private BoxCollider2D boxCollider;

	// Use this for initialization
	void Start () {
		transform = GetComponent<Transform>();
		rigidbody = GetComponent<Rigidbody2D>();
		boxCollider = GetComponent<BoxCollider2D>();
		origPosition = transform.position;
		origVelocity = rigidbody.velocity;
		origBoxColliderStatus = boxCollider.enabled;
		origMayMove = heroMovement.mayMove;
	}
	
	public void ResetPosition(){
		transform.position = origPosition;
		rigidbody.velocity = origVelocity;
		boxCollider.enabled = origBoxColliderStatus;
		heroMovement.mayMove = origMayMove;
	}
}
