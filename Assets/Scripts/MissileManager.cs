using UnityEngine;
using System.Collections;

public class MissileManager : MonoBehaviour {

	public Transform spawn1;
	public Transform spawn2;
	public Transform spawn3;
	public Transform spawn4;
	public Transform spawn5;
	public Transform spawn6;
	public Transform spawn7;
	public Transform spawn8;

	public int stage1;
	public int stage2;
	public int stage3;
	public int stage4;

	public GameObject missile1;
	public GameObject missile2;
	public GameObject missile3;

	public float stage1Wait = 7;
	public float stage2Wait = 5;
	public float stage3Wait = 3;
	public float stage4Wait = 1;
	private float timeCount;
	private int detection;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		timeCount -= Time.deltaTime;
		detection = DetectionManager.getDetection ();

		if (detection >= stage4) {
			if (timeCount <= 0) {
				switch(Random.Range(0,3)){
				case 2:
					spawnMissile (missile3);
					break;
				case 1:
					spawnMissile (missile2);
					break;
				case 0:
					spawnMissile (missile1);
					break;
				}
				timeCount = stage4Wait;
			}
		} else if (detection >= stage3) {
			if (timeCount <= 0) {
				switch(Random.Range(0,5)){
				case 4:
					spawnMissile (missile3);
					break;
				case 3:
				case 2:
					spawnMissile (missile2);
					break;
				default:
					spawnMissile (missile1);
					break;
				}
				timeCount = stage3Wait;
			}
		} else if (detection >= stage2) {
			if (timeCount <= 0) {
				switch(Random.Range(0,3)){
				case 2:
					spawnMissile (missile2);
					break;
				default:
					spawnMissile (missile1);
					break;
				}
				timeCount = stage2Wait;
			}
		} else if (detection >= stage1) {
			if (timeCount <= 0) {
				spawnMissile (missile1);
				timeCount = stage1Wait;
			}
		}
	}

	void spawnMissile(GameObject selectedMissile){
		Debug.Log ("spawning missile:" + selectedMissile.name);
		switch(Random.Range(0,8)){
		case 0:
			Instantiate (selectedMissile, spawn1.position, spawn1.rotation);
			break;
		case 1:
			Instantiate (selectedMissile, spawn2.position, spawn2.rotation);
			break;
		case 2:
			Instantiate (selectedMissile, spawn3.position, spawn3.rotation);
			break;
		case 3:
			Instantiate (selectedMissile, spawn4.position, spawn4.rotation);
			break;
		case 4:
			Instantiate (selectedMissile, spawn5.position, spawn5.rotation);
			break;
		case 5:
			Instantiate (selectedMissile, spawn6.position, spawn6.rotation);
			break;
		case 6:
			Instantiate (selectedMissile, spawn7.position, spawn7.rotation);
			break;
		case 7:
			Instantiate (selectedMissile, spawn8.position, spawn8.rotation);
			break;

		}
	}
		
}
