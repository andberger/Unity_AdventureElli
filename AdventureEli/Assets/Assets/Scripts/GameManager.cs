using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public GameObject hero;
	public Canvas canvas;
	public Reset reset;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
	
	}

	public IEnumerator RestartLevel(){
		yield return new WaitForSeconds(3.0f);
		RestoreObjects();
	}

	void RestoreObjects(){
		reset.ResetPosition();
	}
}
