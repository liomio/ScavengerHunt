using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure01Spawn : MonoBehaviour {

	private Vector3[] positions = new Vector3[3];

	// Use this for initialization
	void Start () {
		positions [0] = new Vector3 (-0.37f, -0.4306518f, 2.49f);
		positions [1] = new Vector3 (12.31f, -0.602f, 7.73f);
		positions [2] = new Vector3 (-0.95f, -0.602f, 4.03f);
		int random = Random.Range (0, 3);
		Debug.Log (random);
		this.gameObject.transform.localPosition = positions[random];
	}

}
