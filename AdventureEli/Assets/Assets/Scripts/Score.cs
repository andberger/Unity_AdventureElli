using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	public float score;
	public GUIStyle guistyle;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		score += score * Timer.counter;
		print ("Score:" + (int)Timer.counter);
	}

	public static int getScore(float timer){
		return (int)timer * 32;
	}

	void OnGUI(){
		GUI.Label(new Rect(350,24,100,100),"Time:" + getScore(Timer.counter),guistyle);
	}
}