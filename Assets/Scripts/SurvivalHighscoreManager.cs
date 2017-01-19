using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SurvivalHighscoreManager : MonoBehaviour {

	public Text myText;
	public SurvivalGameOverMenu gameOverMenu;

	// Use this for initialization
	void Start () {
		myText = GetComponent<Text> ();
		gameOverMenu = FindObjectOfType<SurvivalGameOverMenu> ();
	}

	// Update is called once per frame
	void Update () {
		myText.text = ("highscore\n" + SurvivalScoreManager.getHighScore(gameOverMenu.getCurrectLevel()));
	}
}
