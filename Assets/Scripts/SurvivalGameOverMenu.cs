using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SurvivalGameOverMenu : MonoBehaviour {

	public string currentLevel;

	public string mainMenu;

	public Text gameOverScore;
	public GameObject gameOverCanvas;

	private int score;

	public SurvivalLevelManager levelManager;

	void Start () {
		levelManager = FindObjectOfType<SurvivalLevelManager> ();
	}

	void Update(){
		if (levelManager.showGameOverMenu()) {
			score = SurvivalScoreManager.getScore ();
			gameOverScore.text = "Score: " + score;
			gameOverCanvas.SetActive (true);
			SurvivalScoreManager.setHightScore (currentLevel);
		}
	}

	public string getCurrectLevel(){
		return currentLevel;
	}

	public void restart(){
		SceneManager.LoadScene (currentLevel);
	}

	public void quit(){
		SceneManager.LoadScene (mainMenu);
	}

}
