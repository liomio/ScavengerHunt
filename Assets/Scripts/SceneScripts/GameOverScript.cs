using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour {

	public Text endMessage;

	public void Start() {
		Cursor.lockState = CursorLockMode.None;

		if (MainScript.gameWon) {
			endMessage.text = "You Win!";
		} else {
			if (MainScript.burned) {
				endMessage.text = "You Burned To A Crisp!";
			}
			else if (MainScript.drowned) {
				endMessage.text = "You Drowned!";
			}
			else if (MainScript.timeOut) {
				endMessage.text = "Time Ran Out!";
			}
		}
	}

	public void MainMenu() {
		SceneManager.LoadScene ("MainMenu");
	}
}
