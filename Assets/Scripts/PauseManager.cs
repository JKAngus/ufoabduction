using UnityEngine;
using System.Collections;

public class PauseManager : MonoBehaviour {

	public GameObject pauseCanvas;
	public bool paused;

	public PlayerController player;

	// Use this for initialization
	void Start () {
		paused = false;
		player = FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void pauseGame(){
		Time.timeScale = 0;
		paused = true;
		pauseCanvas.SetActive (true);
	}

	public void unpauseGame(){
		Time.timeScale = 1;
		paused = false;
		pauseCanvas.SetActive (false);
	}

	public void resetPosition(){
		player.resetPosition ();
		unpauseGame ();
	}
}
