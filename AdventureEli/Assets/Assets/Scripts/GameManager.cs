using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {
	public GameObject hero;
	public Canvas canvas;
	public Reset reset;
	public Image flippers;

	private HeroMovement heroMovement;

	// Use this for initialization
	void Start () {
		flippers.enabled = !flippers.enabled;
		heroMovement = hero.GetComponent<HeroMovement>();
	}

	// Update is called once per frame
	void Update () {
		if(heroMovement.holdingFlippers){
			flippers.enabled = true;
		}
	}

	public IEnumerator RestartLevel(){
		yield return new WaitForSeconds(3.0f);
		RestoreObjects();
	}

	void RestoreObjects(){
		reset.ResetPosition();
	}
}
