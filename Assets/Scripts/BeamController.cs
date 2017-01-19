using UnityEngine;
using System.Collections;

public class BeamController : MonoBehaviour {

	public float abductionSpeed;

	private bool abducting;
	private GameObject abducted;
	private Rigidbody2D myRigidbody2D;

	// Use this for initialization
	void Start () {
		abducting = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(abducted == null){
			abducting = false;
		}
	}

	void OnTriggerStay2D(Collider2D other){
		if (abducting == false && other.tag == "Human") {
			abducted = other.gameObject;

			abducting = true;
			myRigidbody2D = abducted.GetComponent<Rigidbody2D> ();
		} else if (abducted!=null && other.gameObject == abducted.gameObject) {
			myRigidbody2D.velocity = new Vector2 (myRigidbody2D.velocity.x, abductionSpeed);
			//Debug.Log("Abducting same object");
		}
	}

	public void reset(){
		abducting = false;
		abducted = null;
		myRigidbody2D = null;
	}
}
