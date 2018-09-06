using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsScript : MonoBehaviour {

	public void Easy() {
		MainScript.time = 120.0f;
		MainMenuScript.difficulty = 1;
		SceneManager.LoadScene ("MainMenu");
	}

	public void Medium() {
		MainScript.time = 90.0f;
		MainMenuScript.difficulty = 2;
		SceneManager.LoadScene ("MainMenu");
	}

	public void Hard() {
		MainScript.time = 60.0f;
		MainMenuScript.difficulty = 3;
		SceneManager.LoadScene ("MainMenu");
	}

	public void Back() {
		SceneManager.LoadScene ("MainMenu");
	}
		
}
