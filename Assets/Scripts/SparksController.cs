using UnityEngine;
using System.Collections;

public class SparksController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.parent.localScale.x < 0) {
			transform.eulerAngles = new Vector3 (0, -90, 0);
		}
	}
}
