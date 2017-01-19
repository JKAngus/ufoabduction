using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SurvivalHealthManager : MonoBehaviour {

	public int maxHealth;

	public static int currentHealth;

	public Slider healthBar;

	public SurvivalPlayerController playerController;
	public SurvivalLevelManager levelManager;

	// Use this for initialization
	void Start () {
		currentHealth = maxHealth;
		playerController = GameObject.FindObjectOfType<SurvivalPlayerController> ();
		levelManager = GameObject.FindObjectOfType<SurvivalLevelManager> ();
	}

	// Update is called once per frame
	void Update () {
		healthBar.value = currentHealth;

		if (currentHealth <= 0) {
			playerController.dead ();
			levelManager.GameOver ();
		}
	}

	public void damagePlayer(int value){
		currentHealth -= value;
	}

}
