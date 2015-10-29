using UnityEngine;
using System.Collections;

public class MoveCam : MonoBehaviour {

	public Transform hero;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Camera.main.transform.position = new Vector3(hero.position.x, hero.position.y, Camera.main.transform.position.z);
	}
}
