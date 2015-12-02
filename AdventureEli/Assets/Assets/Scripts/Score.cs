using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {

	public static float score;
	private static bool isDead = false;
	private static int c;
	private static bool gameov = false;
	Text text;

	// Use this for initialization
	void Awake () {
		text = GetComponent <Text> ();
		score = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if (!isDead || !gameov) {
			score += score * Timer.counter * 31;
			c= (int) score;
			gameov = true; 
		} 

		text.text = "Game Over\nScore:"+ c;

	}

	public static void getScore(float timer){
		isDead = true;
		
	}


}