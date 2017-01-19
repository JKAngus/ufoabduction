using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public int humanToAbduct;

	private int humanAbducted;
	private int alienStock;


	private bool gameOver;
	private bool gameWon;
	private bool gameOverMenu;
	private bool gameWonMenu;
	private float gameOverCount;

	public ScoreManager scoreManager;

	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
		scoreManager = GameObject.FindObjectOfType<ScoreManager> ();
		gameOver = false;
		gameWon = false;
		gameOverMenu = false;
		gameWonMenu = false;
		gameOverCount = 2;
	}
	
	// Update is called once per frame
	void Update () {
		if (humanToAbduct == 0 && alienStock == 0) {
			GameWon ();
		}
		if (gameOver) {
			if ( (gameOverCount -= Time.deltaTime) <= 0) {
				Time.timeScale = 0;
				if (gameWon) {
					gameWonMenu = true;
				} else {
					gameOverMenu = true;
				}
			}
		}
	}

	public void Abducted(){
		humanToAbduct--;
		humanAbducted++;
		alienStock++;
	}

	public void Release(){
		alienStock--;
	}

	public void GameWon(){
		gameWon = true;
		gameOver = true;
		scoreManager.gameWonScore();
		Debug.Log ("Game won");
	}

	public void GameOver(){
		MissileController[] missiles = FindObjectsOfType<MissileController> ();
		foreach(MissileController i in missiles){
			i.destroyMissile ();
		}
		gameOver = true;
		scoreManager.gameOverScore ();
		Debug.Log ("Game Over");
	}

	public bool isGameOver(){
		return gameOver;
	}

	public bool showGameOverMenu(){
		return gameOverMenu;
	}
	public bool showGameWonMenu(){
		return gameWonMenu;
	}
}
