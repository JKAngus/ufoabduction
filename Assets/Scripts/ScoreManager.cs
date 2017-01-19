using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public static int currentScore;

	public Text myText;

	public TimeManager timeManager;

	private static bool gameOver;

	// Use this for initialization
	void Start () {
		gameOver = false;
		currentScore = 0;
		timeManager = GameObject.FindObjectOfType<TimeManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		//myText.text = "" + currentScore;
	}

	public static void addScore(int value){
		if (!gameOver) {
			if (value < 0 && currentScore <= 0) {
				currentScore = 0;
			} else {
				currentScore += value;
			}
		}
	}

	public void gameOverScore(){
		gameOver = true;
	}

	public void gameWonScore(){
		if (!gameOver) {
			currentScore = Mathf.RoundToInt (currentScore * (1 + timeManager.timePercentage ()));
			gameOver = true;
		}
	}

	public static int getScore(){
		return currentScore;
	}

	public static void setHightScore(string level){
		if (PlayerPrefs.GetInt (level + "highscore", 0) < currentScore) {
			PlayerPrefs.SetInt (level + "highscore", currentScore);
		}
	}
	public static int getHighScore(string level){
		return PlayerPrefs.GetInt (level + "highscore", 0);
	}
}
