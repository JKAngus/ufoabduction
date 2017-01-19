using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {

	public int maxHealth;

	public static int currentHealth;

	public Slider healthBar;

	public PlayerController playerController;
	public LevelManager levelManager;

	// Use this for initialization
	void Start () {
		currentHealth = maxHealth;
		playerController = GameObject.FindObjectOfType<PlayerController> ();
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		healthBar.value = currentHealth;

		if (currentHealth > maxHealth) {
			currentHealth = maxHealth;
		}

		if (currentHealth <= 0) {
			playerController.dead ();
			levelManager.GameOver ();
		}
	}

	public static void damagePlayer(int value){
		currentHealth -= value;
	}

	public static void recover(int value){
		currentHealth += value;
	}
}
