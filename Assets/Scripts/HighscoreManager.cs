using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighscoreManager : MonoBehaviour {

	public Text myText;
	public GameOverMenu gameOverMenu;

	// Use this for initialization
	void Start () {
		myText = GetComponent<Text> ();
		gameOverMenu = FindObjectOfType<GameOverMenu> ();
	}
	
	// Update is called once per frame
	void Update () {
		myText.text = ("highscore\n" + ScoreManager.getHighScore(gameOverMenu.getCurrectLevel()));
	}
}
