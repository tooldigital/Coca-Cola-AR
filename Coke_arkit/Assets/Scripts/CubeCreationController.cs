using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCreationController : MonoBehaviour {
	public GameObject generatorX;
	public Transform iceCubePrefab;
	public GameObject refCube;
	private GameObject world;
	private Vector3 iniPos;
	private bool dir;
	public float speedX;
	public float maxDistanceX;
	public float maxDistanceZ;
	public float gravity;

	// Use this for initialization
	void Start () {
		world = GameObject.Find ("World");
		iniPos = gameObject.transform.position;
		Physics.gravity = new Vector3(0, gravity, 0);
		maxDistanceX = refCube.transform.localScale.x*5;
		maxDistanceZ = maxDistanceX * -1;

	}
	
	// Update is called once per frame
	void Update () {
		checkScale ();
		moveSpawner ();
		if (Input.GetMouseButtonDown (0)) {
			Transform tc = GameObject.Instantiate (iceCubePrefab);
			tc.position = generatorX.transform.position;
			tc.SetParent (GameObject.Find ("Container").transform);
			tc.localScale = refCube.transform.localScale;
			gameObject.transform.Translate (Vector3.up*(refCube.transform.localScale.x)*world.transform.localScale.x);

		}
	}

	public void moveSpawner(){
		if (generatorX.transform.localPosition.x > maxDistanceX) {
			generatorX.transform.localPosition = new Vector3 (0, 0, maxDistanceX);
			dir = true;
		}
		if (generatorX.transform.localPosition.z < maxDistanceZ) {
			generatorX.transform.localPosition = new Vector3 (maxDistanceZ, 0, 0);
			dir = false;
		}

		if (!dir) {
			generatorX.transform.localPosition =new Vector3(generatorX.transform.localPosition.x + (speedX * Time.deltaTime), generatorX.transform.localPosition.y, generatorX.transform.localPosition.z);
		} else {
			generatorX.transform.localPosition =new Vector3(generatorX.transform.localPosition.x, generatorX.transform.localPosition.y, generatorX.transform.localPosition.z +(speedX * Time.deltaTime*-1));
		}
	}

	public void restart(){
		gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x,iniPos.y,gameObject.transform.localPosition.z);
	}
	public void checkScale(){
		maxDistanceX = refCube.transform.localScale.x*5;
		maxDistanceZ = maxDistanceX * -1;
	}
}
