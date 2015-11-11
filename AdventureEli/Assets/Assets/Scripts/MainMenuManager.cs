using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenuManager : MonoBehaviour {
	public GameObject instructionsPanel;
	public GameObject aboutPanel;
	// Use this for initialization
	void Start () {
		instructionsPanel.SetActive(false);
		aboutPanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoadLevel(string level){
		Application.LoadLevel(level);
	}

	public void ShowInstructions(){
		instructionsPanel.SetActive(true);
	}

	public void ShowAbout(){
		aboutPanel.SetActive(true);
	}

	public void BackButton(){
		if(instructionsPanel.activeSelf){
			instructionsPanel.SetActive(false);
		}
		if(aboutPanel.activeSelf){
			aboutPanel.SetActive(false);
		}
	}
}
