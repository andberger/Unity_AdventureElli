using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {
	public GameObject hero;
	public Canvas canvas;
	public Reset reset;
	public Image flippers;
	public Image gOverImage;
	//public GUIStyle goStyle;
	public GameObject gameOverText;

	private HeroMovement heroMovement;


	// Use this for initialization
	void Start () {
		flippers.enabled = !flippers.enabled;
		heroMovement = hero.GetComponent<HeroMovement>();
		gameOverText.SetActive(false);

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

	public IEnumerator GameOver(){
		yield return new WaitForSeconds (3.0f);

		Color c = new Color(); 
		c.a = 1f;
		gOverImage.color = c;
		gameOverText.SetActive(true);
		int score = Score.getScore (Timer.counter);
		//Score s = new Score ();

		print ("Score:" + score);
	}

	void RestoreObjects(){
		reset.ResetPosition();
	}


}
