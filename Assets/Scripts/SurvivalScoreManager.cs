using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SurvivalScoreManager : MonoBehaviour {

	public static int currentScore;

	public SurvivalTimeManager timeManager;

	// Use this for initialization
	void Start () {
		currentScore = 0;
		timeManager = GameObject.FindObjectOfType<SurvivalTimeManager> ();
	}

	// Update is called once per frame
	void Update () {
	}

	public void gameOverScore(){
		currentScore = Mathf.RoundToInt(timeManager.getTime () * 100);
		Debug.Log ("GameOverScore calcalated: Time=" + timeManager.getTime ());
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
