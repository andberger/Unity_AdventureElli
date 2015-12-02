using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {
	public GameObject hero;
	public Canvas canvas;
	public Reset reset;
	public Image flippers;
	public Image iceaxes;
	public GameObject key;
	public GameObject gameoverpanel;
	public GameObject winpanel;
	public int sec;
	public int min;
	public Text text;
	public Text winText;
	public bool keepCounting = true;
	
	private HeroMovement heroMovement;

	// Use this for initialization
	void Start () {
		flippers.enabled = !flippers.enabled;
		iceaxes.enabled = !iceaxes.enabled;
		gameoverpanel.SetActive(false);
		winpanel.SetActive(false);
		heroMovement = hero.GetComponent<HeroMovement>();
		sec = 0;
		min = 0;
		text.text = "0";
	}

	// Update is called once per frame
	void Update () {
		if(heroMovement.holdingFlippers){
			flippers.enabled = true;
		}
		else{
			flippers.enabled = false;
		}
		if(heroMovement.holdingIceaxes){
			iceaxes.enabled = true;
		}
		else{
			iceaxes.enabled = false;
		}
		if(keepCounting){
			sec = (int)Mathf.Floor(Time.timeSinceLevelLoad%60);
			min = (int)Mathf.Floor(Time.timeSinceLevelLoad/60);
			text.fontSize = 24;
			text.text = min.ToString("00")+":"+sec.ToString("00");
		}
	}

	//Reset level.
	public IEnumerator RestartLevel(){
		yield return new WaitForSeconds(3.0f);
		RestoreObjects();
	}

	//Win the game.
	public void WinGame(){
		keepCounting = false;
		winpanel.SetActive(true);
		winText.text = winText.text + " "+min.ToString("00")+":"+sec.ToString("00");
	}

	//Back to main menu,
	public void BackToMainMenu(){
		keepCounting = false;
		gameoverpanel.SetActive(true);
	}

	//Loads main menu.
	public void LoadMainMenu(){
		Application.LoadLevel("MainMenu");
	}	

	//Resets the positions of relevant objects when resetting the level.
	void RestoreObjects(){
		reset.ResetHeroPosition();
		reset.ResetKeyPosition();
		reset.ResetEnemyActivation();
	}
}
