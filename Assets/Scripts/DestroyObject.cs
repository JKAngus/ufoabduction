using UnityEngine;
using System.Collections;

public class DestroyObject : MonoBehaviour {

	public float destroyObjectInSec;
	private float destroyCount;

	// Use this for initialization
	void Start () {
		destroyCount = destroyObjectInSec;
	}
	
	// Update is called once per frame
	void Update () {
		destroyCount -= Time.deltaTime;
		if (destroyCount <= 0) {
			Destroy (gameObject);
		}
	}
}
