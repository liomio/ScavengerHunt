using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {
	
	Vector2 rotateAmount;
	Vector2 smoothing;

	GameObject character;

	// Use this for initialization
	void Start () {
		// get character since camera is child of character
		character = this.transform.parent.gameObject;
	}

	// Update is called once per frame
	void Update () {
		
		// mouse control
		// get change in mouse position using axes
		var md = new Vector2 (Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

		// smooth out movement, set mouse sensitivity
		md = Vector2.Scale (md, new Vector2 (5.0f, 5.0f));
		smoothing.x = Mathf.Lerp (smoothing.x, md.x, 0.5f);
		smoothing.y = Mathf.Lerp (smoothing.y, md.y, 0.5f);
		rotateAmount += smoothing;

		// limit how far the camera can rotate vertically
		rotateAmount.y = Mathf.Clamp (rotateAmount.y, -70.0f, 70.0f);

		// apply transformations
		// rotates camera vertically
		transform.localRotation = Quaternion.AngleAxis (-rotateAmount.y, Vector3.right);
		// rotates character and camera together horizontally
		character.transform.localRotation = Quaternion.AngleAxis (rotateAmount.x, character.transform.up);

	}
}
