﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionsScript : MonoBehaviour {

	public void BackButton() {
		SceneManager.LoadScene ("MainMenu");
	}
}
