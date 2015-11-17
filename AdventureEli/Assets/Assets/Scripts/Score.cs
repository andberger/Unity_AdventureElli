using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {

	public static float score;
	Text text;

	// Use this for initialization
	void Awake () {
		text = GetComponent <Text> ();
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		score += score * Timer.counter;
		text.text = "Game Over\nScore:"+ (int)Timer.counter;
		print ("Score:" + (int)Timer.counter);
	}

	public static int getScore(float timer){
		return (int)timer * 32;
	}


}