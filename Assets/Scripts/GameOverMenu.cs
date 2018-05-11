using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class GameOverMenu : MonoBehaviour {

	public string currentLevel;
	public string nextLevel;

	private string[] Tips;
	private int numberOfTips;

	public string mainMenu;

	public Text tipsText;
	public Text gameOverScore;
	public Text gameWonScore;
	public GameObject gameOverCanvas;
	public GameObject gameWonCanvas;

	private int score;

	public LevelManager levelManager;

	void Start () {
		levelManager = FindObjectOfType<LevelManager> ();

		numberOfTips = 6;

		Tips = new string[numberOfTips];
		Tips[0] = "Tips: Try to keep the destection bar low by hiding";
		Tips[1] = "Tips: Try to abduct the ones that notice you";
		Tips[2] = "Tips: Try to advoid groups of people";
		Tips[3] = "Tips: Tranforming aliens can lower the detection bar";
		Tips[4] = "Tips: abducting human can heal you";
		Tips[5] = "Tips: More people in stock slowers your movement";

		randomize ();
	}

	void Update(){
		score = ScoreManager.getScore ();
		if (levelManager.showGameOverMenu()) {
			gameOverScore.text = "Score: " + score;
			gameOverCanvas.SetActive (true);
			ScoreManager.setHightScore (currentLevel);
		}
		if (levelManager.showGameWonMenu()) {
			gameWonScore.text = "Score: " + score;
			gameWonCanvas.SetActive (true);
			ScoreManager.setHightScore (currentLevel);
		}
	}

	public string getCurrectLevel(){
		return currentLevel;
	}

	public void goNextLevel(){
		SceneManager.LoadScene (nextLevel);
	}

	public void restart(){
		SceneManager.LoadScene (currentLevel);
	}

	public void quit(){
		SceneManager.LoadScene (mainMenu);
	}

	public void randomize(){
		tipsText.text = Tips [Random.Range (0, numberOfTips)];
	}

    public void showAD()
    {
        if (Advertisement.IsReady())
            Advertisement.Show();
    }
}
