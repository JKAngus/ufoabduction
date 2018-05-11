using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class MainMenuManager : MonoBehaviour {

	public string startingLevel;

	public GameObject HUD;

	public GameObject howToPlayCanvas;
	public GameObject introCanvas;
	public GameObject levelSelect;
	public GameObject highscore;

	public Text highscoreText;

	private bool menuActive;

	// Use this for initialization
	void Start () {
		//PlayerPrefs.DeleteAll ();
		menuActive = false;
        Advertisement.Initialize("1797201");

    }
	
	// Update is called once per frame
	void Update () {
		highscoreText.text = (
			"Survival: " + PlayerPrefs.GetInt("Survivalhighscore",0) + "\n\n" +
			"Level 1: " + PlayerPrefs.GetInt("Level 1highscore",0) + "\n\n" +
			"Level 2: " + PlayerPrefs.GetInt("Level 2highscore",0) + "\n\n" +
			"Level 3: " + PlayerPrefs.GetInt("Level 3highscore",0) + "\n\n" +
			"Level 4: " + PlayerPrefs.GetInt("Level 4highscore",0) + "\n\n"
		);
	}
		
	public void showMenu(){
		HUD.SetActive (!menuActive);
		menuActive = !menuActive;
	}

	public void showHighscore(){
		highscore.SetActive (true);
	}

	public void hideHighScore(){
		highscore.SetActive (false);
	}

	public void showLevelSelect(){
		levelSelect.SetActive (true);
	}

	public void hideLevelSelect(){
		levelSelect.SetActive (false);
	}

	public void startGameIntro(){
		introCanvas.SetActive(true);
	}

	public void showInstruction(){
		howToPlayCanvas.SetActive (true);
	}

	public void hideInstruction(){
		howToPlayCanvas.SetActive(false);
	}

	public void startLevel(){
		SceneManager.LoadScene (startingLevel);
	}

	public void loadSurvival(){
		SceneManager.LoadScene ("Survival");
	}

	public void loadLevel1(){
		SceneManager.LoadScene ("Level 1");
	}

	public void loadLevel2(){
		SceneManager.LoadScene ("Level 2");
	}

	public void loadLevel3(){
		SceneManager.LoadScene ("Level 3");
	}

	public void loadLevel4(){
		SceneManager.LoadScene ("Level 4");
	}
	public void quit(){
		Application.Quit ();
	}
}
