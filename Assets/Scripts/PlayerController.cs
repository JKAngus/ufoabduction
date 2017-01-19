using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class PlayerController : MonoBehaviour {

	public float horizontalMaxSpeed;
	public float verticalMaxSpeed;

	public float horizontalAccelaration;
	public float verticalAccelaration;

	public GameObject abductionBeam;
	public GameObject ufoExplosion;
	public Transform alienSpawn;

	public float maxHuman;
	private float horizontalVelocity;
	private float verticalVelocity;

	private bool abducting;
	private bool invisible;

	private Rigidbody2D myRigidbody2D;
	private float rotation;

	private StockManager stockManager;
	private LevelManager levelManager;
	private bool isAlive;

	private float origTilt;

	// Use this for initialization
	void Start () {
		isAlive = true;
		myRigidbody2D = gameObject.GetComponent<Rigidbody2D> ();
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		stockManager = FindObjectOfType<StockManager> ();
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

			if (Input.GetKey (KeyCode.Space)) {
				abduct ();
			} else if (Input.GetKeyUp (KeyCode.Space)) {
				stopAbduct ();
			}

			rotation = -10 * (horizontalVelocity) / (horizontalMaxSpeed);

			myRigidbody2D.rotation = rotation;

			if (Input.GetKeyDown (KeyCode.R)) {
				release ();
			}
		} else {
			GetComponent<SpriteRenderer> ().enabled = false;
			GetComponent<PolygonCollider2D> ().enabled = false;
		}
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Human" && abducting) {
			CitizenController temp1 = other.gameObject.GetComponent<CitizenController> ();
			ReporterController temp2 = other.gameObject.GetComponent<ReporterController> ();
			if (temp1 != null) {
				stockManager.addStock (temp1.alienVersion ());
				HealthManager.recover (temp1.abductRecover());
				ScoreManager.addScore (temp1.abductScore());
			} else if (temp2 != null) {
				stockManager.addStock (temp2.alienVersion ());
				HealthManager.recover (temp2.abductRecover());
				ScoreManager.addScore (temp2.abductScore());
			} else {
				Debug.Log ("Alien not found in abducted");
			}
			levelManager.Abducted ();
			Destroy (other.gameObject);
		}
	}

	void OnTriggerStay2D(Collider2D other){
		if (other.gameObject.tag == "Cloud" && !abducting) {
			invisible = true;
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.tag == "Cloud") {
			invisible = false;
		}
	}

	public void verticalMove(float value){
			verticalVelocity = myRigidbody2D.velocity.y + value * verticalAccelaration * Time.deltaTime;

		if (Mathf.Abs (myRigidbody2D.velocity.y) <= verticalMaxSpeed * (1 - stockManager.getStock() / maxHuman) && !abducting)
			myRigidbody2D.velocity = new Vector2 (myRigidbody2D.velocity.x, verticalVelocity);
	}

	public void horizontalMove(float value){
			horizontalVelocity = myRigidbody2D.velocity.x + value * horizontalAccelaration * Time.deltaTime;

		if (Mathf.Abs (myRigidbody2D.velocity.x) <= horizontalMaxSpeed * (1 - stockManager.getStock() / maxHuman) && !abducting)
			myRigidbody2D.velocity = new Vector2 (horizontalVelocity, myRigidbody2D.velocity.y);
	}

	public void abduct() {
		abducting = true;
		abductionBeam.SetActive (true);
	}

	public bool isAbducting(){
		return abducting;
	}

	public void stopAbduct(){
		abducting = false;
		abductionBeam.GetComponent<BeamController> ().reset ();
		abductionBeam.SetActive (false);
	}

	public void release(){
		GameObject temp = stockManager.releaseStock ();
		if (temp != null) {
			AlienController controller = temp.GetComponent<AlienController> ();
			DetectionManager.addDetection (-controller.getReleaseDetectionBonus());
			ScoreManager.addScore (controller.getReleaseScore());
			levelManager.Release ();
			Instantiate (temp, alienSpawn.position, new Quaternion (0, 0, 0, 0));
			GetComponent<AudioSource> ().Play ();
		}
	}

	public bool isPlayerAlive(){
		return isAlive;
	}

	public bool isInvisible(){
		return invisible;
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
