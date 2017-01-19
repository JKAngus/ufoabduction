using UnityEngine;
using System.Collections;

public class LevelSelectManager : MonoBehaviour {

	public GameObject level1;
	public GameObject level2;
	public GameObject level3;
	public GameObject level4;

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetInt ("Level 2highscore", -1) == -1) {
			level2.SetActive (false);
		}
		if (PlayerPrefs.GetInt ("Level 3highscore", -1) == -1) {
			level3.SetActive (false);
		}
		if (PlayerPrefs.GetInt ("Level 4highscore", -1) == -1) {
			level4.SetActive (false);
		}
	}
}
