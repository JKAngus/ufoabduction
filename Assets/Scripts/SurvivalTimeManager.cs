using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SurvivalTimeManager : MonoBehaviour {

	private float currentTime;

	public SurvivalLevelManager levelManager;

	public Text text;

	// Use this for initialization
	void Start () {
		currentTime = 0;
		text = GetComponent<Text> ();
		levelManager = FindObjectOfType<SurvivalLevelManager> ();
	}

	// Update is called once per frame
	void Update () {

		text.text = "" + Mathf.Round(currentTime);
		if (!levelManager.isGameOver())
			currentTime += Time.deltaTime;
	}

	public float getTime(){
		return currentTime;
	}
}
