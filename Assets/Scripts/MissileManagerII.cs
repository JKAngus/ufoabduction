using UnityEngine;
using System.Collections;

public class MissileManagerII : MonoBehaviour {

	public Transform top;
	public Transform bottom;
	public Transform left;
	public Transform right;

	public int stage1;
	public int stage2;
	public int stage3;
	public int stage4;
	private int currentStage;
	private float currentStageWait;

	public GameObject missile1;
	public GameObject missile2;
	public GameObject missile3;

	public float stage1Wait;
	public float stage2Wait;
	public float stage3Wait;
	public float stage4Wait;
	private float timeCount;
	private int detection;

	private LevelManager levelManager;

	// Use this for initialization
	void Start () {
		currentStage = 0;
		levelManager = FindObjectOfType<LevelManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!levelManager.isGameOver ()) {
			timeCount -= Time.deltaTime;
		}
		detection = DetectionManager.getDetection ();

		if (detection >= stage4 && currentStage != 4) {
			currentStage = 4;
			spawnMissile (selectMissile());
			currentStageWait = stage4Wait;
			timeCount = stage4Wait;
		} else if (detection < stage4 &&detection >= stage3 && currentStage != 3) {
			currentStage = 3;
			spawnMissile (selectMissile());
			currentStageWait = stage3Wait;
			timeCount = stage3Wait;
		} else if (detection < stage3 &&detection >= stage2 && currentStage != 2) {
			currentStage = 2;
			spawnMissile (selectMissile());
			currentStageWait = stage2Wait;
			timeCount = stage2Wait;
		} else if (detection < stage2 &&detection >= stage1 && currentStage != 1) {
			currentStage = 1;
			spawnMissile (selectMissile());
			currentStageWait = stage1Wait;
			timeCount = stage1Wait;
		} else if (detection < stage1){
			currentStage = 0;
		}

		if (currentStage > 0 && timeCount <= 0) {
			spawnMissile (selectMissile());
			timeCount = currentStageWait;
		}
	}

	private GameObject selectMissile(){
		float temp;
		switch (currentStage) {
		case 4:
			temp = Random.Range (0f, 1f);
			if (temp > 0.6) {
				return missile3;
			} else if (temp > 0.2) {
				return missile2;
			} else {
				return missile1;
			}
		case 3:
			temp = Random.Range (0f, 1f);
			if (temp > 0.8) {
				return missile3;
			} else if (temp > 0.4) {
				return missile2;
			} else {
				return missile1;
			}
		case 2:
			temp = Random.Range (0f, 1f);
			if (temp > 0.5) {
				return missile2;
			} else {
				return missile1;
			}
		case 1:
			temp = Random.Range (0f, 1f);
			if (temp > 0.7) {
				return missile2;
			} else {
				return missile1;
			}
		default:
			return null;
		}
	}

	void spawnMissile(GameObject selectedMissile){
		Debug.Log ("spawning missile:" + selectedMissile.name);
		float tempy;
		tempy = Random.Range (0f, 1f);
		tempy = (top.position.y - bottom.position.y) * tempy + bottom.position.y;
		if (Random.Range (0, 2) == 0) {
			Instantiate (selectedMissile, new Vector3 (left.position.x,tempy,transform.position.z), transform.rotation);
		} else {
			Instantiate (selectedMissile, new Vector3 (right.position.x,tempy,transform.position.z), transform.rotation);
		}
	}
}
