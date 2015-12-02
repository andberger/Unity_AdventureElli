using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenuManager : MonoBehaviour {
	
	public void LoadLevel(string level){
		Application.LoadLevel(level);
	}	
}
