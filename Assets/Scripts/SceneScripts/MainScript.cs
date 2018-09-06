using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScript : MonoBehaviour {

	public static float time = 120.0f;

	public static bool burned;
	public static bool drowned;
	public static bool timeOut;
	public static bool gameWon;

	public void Burned() {
		MainScript.gameWon = false;
		MainScript.burned = true;
		MainScript.drowned = false;
		MainScript.timeOut = false;
		SceneManager.LoadScene ("GameOver");
	}

	public void Drowned() {
		MainScript.gameWon = false;
		MainScript.burned = false;
		MainScript.drowned = true;
		MainScript.timeOut = false;
		SceneManager.LoadScene ("GameOver");
	}

	public void TimeOut() {
		MainScript.gameWon = false;
		MainScript.burned = false;
		MainScript.drowned = false;
		MainScript.timeOut = true;
		SceneManager.LoadScene ("GameOver");
	}

	public void GameWon() {
		MainScript.gameWon = true;
		MainScript.burned = false;
		MainScript.drowned = false;
		MainScript.timeOut = false;
		SceneManager.LoadScene ("GameOver");
	}
}
