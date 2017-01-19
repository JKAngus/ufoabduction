using UnityEngine;
using System.Collections;

public class HumanManager : MonoBehaviour {

	public float left;
	public float right;
	private float y;

	// Use this for initialization
	void Start () {
		y = -3.3f;
		CitizenController[] citizens = FindObjectsOfType<CitizenController> ();
		ReporterController[] reporters = FindObjectsOfType<ReporterController> ();
		foreach(CitizenController i in citizens){
			i.setPosition ((left + (right - left) * Random.Range (0f, 1f)), y);
		}
		foreach(ReporterController i in reporters){
			i.setPosition ((left + (right - left) * Random.Range (0f, 1f)), y);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
