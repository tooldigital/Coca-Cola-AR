using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCube : MonoBehaviour {
	private GameController gc;
	public bool firstTime = true;
	// Use this for initialization
	void Start () {
		gc = GameObject.Find ("gameControllerObj").GetComponent<GameController> ();
		firstTime = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		Debug.Log ("holi");
		if (other.gameObject.tag.Equals ("IceCube")||other.gameObject.tag.Equals ("InitialCube")) {
			if (firstTime) {
				gc.increaseScore ();
				firstTime = false;
			}

		}
	}
}
