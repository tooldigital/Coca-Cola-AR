using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour {
	public CubeCreationController spawner;
	public Text highScoreLabel;
	public Text currentScoreLabel;
	public GameObject initialCube;
	private int score=0;
	private int highScore=5;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		updateScoreLabel ();
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag.Equals ("IceCube")) {
			GameObject[] cubes = GameObject.FindGameObjectsWithTag ("IceCube");
			foreach (GameObject obj in cubes) {
				Destroy(obj);
			}
			setScore (0);
			spawner.restart ();
			initialCube.GetComponentInChildren<IceCube> ().firstTime = true;
		}
	}

	public void setScore(int ns){
		score = ns;
	}

	public void increaseScore(){
		score++;
		if (score > highScore) {
			highScore = score;
		}
	}

	public void updateScoreLabel(){
		highScoreLabel.text = "High Score: "+ highScore;
		currentScoreLabel.text = "Score: "+ score;
	}
}
