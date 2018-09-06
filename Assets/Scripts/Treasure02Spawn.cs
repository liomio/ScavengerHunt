using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure02Spawn : MonoBehaviour {

	private Vector3[] positions = new Vector3[3];

	// Use this for initialization
	void Start () {
		positions [0] = new Vector3 (-0.5201867f, -0.6f, -14.0344f);
		positions [1] = new Vector3 (14.625f, -0.6f, -8.194f);
		positions [2] = new Vector3 (-7.96f, -0.6f, -0.37f);
		int random = Random.Range (0, 3);
		Debug.Log (random);
		this.gameObject.transform.localPosition = positions[random];
	}

}
