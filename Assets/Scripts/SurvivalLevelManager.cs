using UnityEngine;
using System.Collections;

public class SurvivalLevelManager : MonoBehaviour {

	private bool gameOver;
	private bool gameOverMenu;
	private float gameOverCount;

	public SurvivalScoreManager scoreManager;

	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
		scoreManager = GameObject.FindObjectOfType<SurvivalScoreManager> ();
		gameOver = false;
		gameOverMenu = false;
		gameOverCount = 2;
	}

	// Update is called once per frame
	void Update () {
		if (gameOver) {
			if ( (gameOverCount -= Time.deltaTime) <= 0) {
				Time.timeScale = 0;
				gameOverMenu = true;

			}
		}
	}

	public void GameOver(){
		SurvivalMissileController[] missiles = FindObjectsOfType<SurvivalMissileController> ();
		foreach(SurvivalMissileController i in missiles){
			i.destroyMissile ();
		}
		gameOver = true;
		scoreManager.gameOverScore ();
	}

	public bool isGameOver(){
		return gameOver;
	}

	public bool showGameOverMenu(){
		return gameOverMenu;
	}

}
