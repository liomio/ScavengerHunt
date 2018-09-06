using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

	private float speed = 1.5f;

	// Use this for initialization
	void Start () {
		Cursor.lockState = CursorLockMode.Locked;
	}

	// Update is called once per frame
	void Update () {

		// simple movement using axis
		float smoothing = speed * Time.deltaTime;
		this.transform.Translate(Input.GetAxis ("Horizontal") * smoothing, 0, Input.GetAxis ("Vertical") * smoothing);

		// exit with esc
		if (Input.GetKey ("escape"))
			Cursor.lockState = CursorLockMode.None;

	}


}
