using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure03Spawn : MonoBehaviour {

	private Vector3[] positions = new Vector3[3];

	// Use this for initialization
	void Start () {
		positions [0] = new Vector3 (27.31815f, -0.6f, 3.375406f);
		positions [1] = new Vector3 (23.05f, -0.6f, 9.47f);
		positions [2] = new Vector3 (28.8f, -0.6f, -6f);
		int random = Random.Range (0, 3);
		Debug.Log (random);
		this.gameObject.transform.localPosition = positions[random];
	}

}
