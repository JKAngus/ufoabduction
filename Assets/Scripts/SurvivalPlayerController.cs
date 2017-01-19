using UnityEngine;
using System.Collections;

public class SurvivalPlayerController : MonoBehaviour {


	public float horizontalMaxSpeed;
	public float verticalMaxSpeed;

	public float horizontalAccelaration;
	public float verticalAccelaration;

	public GameObject ufoExplosion;

	private float horizontalVelocity;
	private float verticalVelocity;

	private Rigidbody2D myRigidbody2D;
	private float rotation;

	private bool isAlive;

	private float origTilt;

	// Use this for initialization
	void Start () {
		isAlive = true;
		myRigidbody2D = gameObject.GetComponent<Rigidbody2D> ();
		origTilt = Input.acceleration.y;
	}

	// Update is called once per frame
	void Update () {
		if (isAlive) {
			//horizontalVelocity = myRigidbody2D.velocity.x + Input.GetAxisRaw ("Horizontal") * horizontalAccelaration * Time.deltaTime;

			//verticalVelecity = myRigidbody2D.velocity.y + Input.GetAxisRaw ("Vertical") * verticalAccelaration * Time.deltaTime;


			horizontalMove (Input.GetAxisRaw ("Horizontal"));
			verticalMove (Input.GetAxisRaw ("Vertical"));

			horizontalMove (Input.acceleration.x * 2);
			verticalMove ((Input.acceleration.y - origTilt) * 2);

			rotation = -10 * (horizontalVelocity) / (horizontalMaxSpeed);

			myRigidbody2D.rotation = rotation;

		} else {
			GetComponent<SpriteRenderer> ().enabled = false;
			GetComponent<PolygonCollider2D> ().enabled = false;
		}
	}

	public void verticalMove(float value){
		verticalVelocity = myRigidbody2D.velocity.y + value * verticalAccelaration * Time.deltaTime;

		if (Mathf.Abs (myRigidbody2D.velocity.y) <= verticalMaxSpeed)
			myRigidbody2D.velocity = new Vector2 (myRigidbody2D.velocity.x, verticalVelocity);
	}

	public void horizontalMove(float value){
		horizontalVelocity = myRigidbody2D.velocity.x + value * horizontalAccelaration * Time.deltaTime;

		if (Mathf.Abs (myRigidbody2D.velocity.x) <= horizontalMaxSpeed)
			myRigidbody2D.velocity = new Vector2 (horizontalVelocity, myRigidbody2D.velocity.y);
	}

	public bool isPlayerAlive(){
		return isAlive;
	}

	public void applyForce(float value){
		myRigidbody2D.velocity = new Vector2 (value, myRigidbody2D.velocity.y);
	}

	public void dead(){
		if (isAlive) {
			Instantiate (ufoExplosion, transform.position, transform.rotation);
			isAlive = false;
		}
	}

	public void resetPosition(){
		origTilt = Input.acceleration.y;
	}
}
