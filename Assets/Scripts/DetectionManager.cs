using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DetectionManager : MonoBehaviour {

	public int maxDetection;

	public static int currentDetection;

	public Slider detectionBar;

	public LevelManager levelManager;
	public float invisWait;
	private float invisCount;

	public PlayerController player;

	// Use this for initialization
	void Start () {
		//detectionBar = GetComponent<Slider> ();
		currentDetection = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		player = FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		detectionBar.value = currentDetection;

		if (player.isInvisible ()) {
			if (invisCount <= 0) {
				addDetection (-1);
				invisCount = invisWait;
			}else
				invisCount -= Time.deltaTime;
		}
	}

	public static void addDetection(int value){
		if (value > 0) {
			if (currentDetection >= 100) {
				currentDetection = 100;
			} else {
				currentDetection += value;
			}
		} else {
			if (currentDetection <= 0) {
				currentDetection = 0;
			} else {
				currentDetection += value;
			}
		}
	}

	public static int getDetection(){
		return currentDetection;
	}
}
