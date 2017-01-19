using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {

	public float allowTime;
	public float remainingTime;

	public Text text;
	public LevelManager levelManager;

	// Use this for initialization
	void Start () {
		remainingTime = allowTime;
		text = GetComponent<Text> ();
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
	}

	// Update is called once per frame
	void Update () {

		text.text = "" + Mathf.Round(remainingTime);

		remainingTime -= Time.deltaTime;

		if (remainingTime <= 0) {
			levelManager.GameOver ();
		}
	}

	public float timePercentage(){
		return remainingTime / allowTime;
	}
}
