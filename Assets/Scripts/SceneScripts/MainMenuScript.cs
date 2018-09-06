using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour {

	public Text difficultyText;
	public static int difficulty;

	public void Start() {
		difficultyText.text = "Easy Mode";
	}

	public void Update() {
		if (difficulty == 1) {
			difficultyText.text = "Easy Mode";
		} else if (difficulty == 2) {
			difficultyText.text = "Medium Mode";
		} else if (difficulty == 3) {
			difficultyText.text = "Hard Mode";
		}
	}

	public void StartGame() {
		SceneManager.LoadScene ("Main");
	}

	public void OpenInstructions() {
		SceneManager.LoadScene ("Instructions");
	}

	public void Options() {
		SceneManager.LoadScene ("Options");
	}
}
