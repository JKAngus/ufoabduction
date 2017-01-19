using UnityEngine;
using System.Collections;

public class SurvivalMissileManager : MonoBehaviour {
	public Transform top;
	public Transform bottom;
	public Transform left;
	public Transform right;

	private float currentWait;

	public GameObject missile1;
	public GameObject missile2;
	public GameObject missile3;

	private float timeCount;

	private SurvivalLevelManager levelManager;

	// Use this for initialization
	void Start () {
		currentWait = 3;
		levelManager = FindObjectOfType<SurvivalLevelManager> ();
	}

	// Update is called once per frame
	void Update () {
		if (!levelManager.isGameOver ()) {
			timeCount -= Time.deltaTime;
		}

		if (timeCount <= 0) {
			spawnMissile (selectMissile());
			decreaseWait ();
			timeCount = currentWait;
		}
	}

	private GameObject selectMissile(){
		switch (Random.Range(0,3)) {
		case 2:
			return missile3;
		case 1:
			return missile2;
		default:
			return missile1;
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

	void decreaseWait(){
		if (currentWait >= 1)
			currentWait = currentWait * 0.9f;
		else if (currentWait >= 0.3)
			currentWait = currentWait * 0.99f;
	}
}
