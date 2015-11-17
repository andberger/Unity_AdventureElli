using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {
	float counter;
	public GUIStyle timerStyle;
	
	// Use this for initialization
	void Start () {
		timerStyle.fontSize = 35;
	}
	
	void Awake(){
		counter = 0f;
		//	text = GetComponent <Timer> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		counter += Time.deltaTime;
	}
	
	void OnGUI(){
		if (counter >= 0f) {
			GUI.Label(new Rect(350,24,100,100),"Time:" + (int)counter,timerStyle);
		}
		
	}
}
