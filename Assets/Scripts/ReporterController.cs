using UnityEngine;
using System.Collections;

public class ReporterController : MonoBehaviour {

	public GameObject alien;
	public GameObject player;
	public PlayerController playerController;

	public float walkSpeed;
	public Transform boundaryCheck;
	public Transform groundCheck;
	private float CheckRadius;
	public LayerMask whatIsGround;
	public LayerMask whatIsBoundary;

	public GameObject exclamationPoint;
	public float detectionRadius;
	public int detectionAdd;
	public float detectionWait;
	private float detectionCount;
	public LayerMask whatIsPlayer;
	private bool playerInRange;

	public float actionChangeWait;
	private float actionCount;
	private int action;

	public int abductionRecover;
	public int abductionScore;

	private Rigidbody2D myRigidBody2D;
	private bool isRight;
	private bool Grounded;
	private bool boundaryHit;

	private Animator anim;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("UFO");
		playerController = FindObjectOfType<PlayerController> ();
		myRigidBody2D = gameObject.GetComponent<Rigidbody2D> ();
		anim = gameObject.GetComponent<Animator> ();
		isRight = Random.Range (0f, 1f) > 0.5;
		actionCount = 0;
		CheckRadius = 0.1f;
	}

	void FixedUpdate (){
		Grounded = Physics2D.OverlapCircle (groundCheck.position, CheckRadius, whatIsGround);
		boundaryHit = Physics2D.OverlapCircle (boundaryCheck.position, CheckRadius, whatIsBoundary);
	}

	// Update is called once per frame
	void Update () {

		anim.SetFloat("velocity", Mathf.Abs(myRigidBody2D.velocity.x));

		playerInRange = Physics2D.OverlapCircle (transform.position, detectionRadius, whatIsPlayer);

		if (playerInRange &&
		    Grounded &&
			(!playerController.isInvisible() ||
				playerController.isAbducting()) &&
		    ((player.transform.position.x < transform.position.x && !isRight) ||
		    (player.transform.position.x > transform.position.x && isRight))) {
			
			myRigidBody2D.velocity = new Vector2 (0f, myRigidBody2D.velocity.y);
			exclamationPoint.SetActive (true);

			if (detectionCount <= 0) {
				detectionCount = detectionWait;
				if (playerController.isAbducting()) {
					DetectionManager.addDetection (detectionAdd*2);
				} else {
					DetectionManager.addDetection (detectionAdd);
				}
			} else {
				detectionCount -= Time.deltaTime;
			}

			return;

		} else {
			exclamationPoint.SetActive (false);
			detectionCount = detectionWait;
		}

		if (actionCount <= 0) {
			actionCount = actionChangeWait;
			isRight = Random.Range (0f, 1f) > 0.5;
			action = Random.Range (0, 10);
		}

		if (action > 2) {
			if (boundaryHit) {
				isRight = !isRight;
			}

			if (isRight && Grounded) {
				gameObject.transform.localScale = new Vector3 (-Mathf.Abs (gameObject.transform.localScale.x), gameObject.transform.localScale.y, gameObject.transform.localScale.z);
				myRigidBody2D.velocity = new Vector2 (walkSpeed, myRigidBody2D.velocity.y);
			} else if (!isRight && Grounded) {
				gameObject.transform.localScale = new Vector3 (Mathf.Abs (gameObject.transform.localScale.x), gameObject.transform.localScale.y, gameObject.transform.localScale.z);
				myRigidBody2D.velocity = new Vector2 (-walkSpeed, myRigidBody2D.velocity.y);
			} else {
				myRigidBody2D.velocity = new Vector2 (0f, myRigidBody2D.velocity.y);
			}
		} else {
			myRigidBody2D.velocity = new Vector2 (0f, myRigidBody2D.velocity.y);
		}

		actionCount -= Time.deltaTime;


	}

	void OnDrawGizmosSelected(){
		Gizmos.DrawSphere (transform.position, detectionRadius);
	}

	public GameObject alienVersion(){
		return alien;
	}

	public int abductRecover(){
		return abductionRecover;
	}

	public int abductScore(){
		return abductionScore;
	}

	public void setPosition(float x, float y){
		gameObject.transform.position = new Vector3 (x, y, 0f);
		Debug.Log ("position: " + x + " " + y);
	}
}
