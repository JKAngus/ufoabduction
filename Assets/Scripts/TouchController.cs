using UnityEngine;
using System.Collections;

public class TouchController : MonoBehaviour {

	private PlayerController player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindObjectOfType<PlayerController> ();
	}

	public void abductionButton(){
		player.abduct ();
	}
	public void unpressedAbduction(){
		player.stopAbduct ();
	}
	public void releaseButton(){
		player.release ();
	}
}
