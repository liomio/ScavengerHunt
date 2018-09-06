using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class MouseInteraction : MonoBehaviour {

	private int treasureFound = 0;
	public Text treasureCount;
	public Text objective;
	public Text timer;
	public float timeLeft;

	public UnityEvent noTimeLeft;
	public UnityEvent gotBurned;
	public UnityEvent gotDrowned;
	public UnityEvent wonGame;

	void Start () {
		treasureFound = 0;
		treasureCount.text = "Chests Found " + treasureFound.ToString();
		timer.text = "Time Left " + ((int) timeLeft).ToString ();
		objective.text = "Collect all 3 treasure chests!";
		timeLeft = MainScript.time;

	}

	void Update () {
		if (timeLeft > 0) {
			timeLeft -= Time.deltaTime;
			timer.text = "Time Left " + ((int) timeLeft).ToString ();
		} else {
			this.noTimeLeft.Invoke ();
		}

		if (treasureFound == 3) {
			this.wonGame.Invoke ();
		}

		if (Input.GetMouseButtonDown (0)) {
			Ray clickRay = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit clickInfo;
			// only get info if object is close
			if (Physics.Raycast (clickRay, out clickInfo, 3)) {
				GameObject clickedObject = clickInfo.collider.gameObject;
				if (clickedObject.tag == "Treasure") {
					GameObject treasureChest = clickedObject.transform.parent.gameObject;
					Destroy (treasureChest);
					treasureFound++;
					treasureCount.text = "Chests Found " + treasureFound.ToString();
				}
			}
		}
	}

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.tag == "Hazard") {
			this.gotBurned.Invoke ();
		}

		if (col.gameObject.tag == "River") {
			this.gotDrowned.Invoke ();
		}
	}
}
