using UnityEngine;
using System.Collections;

public class AlienController : MonoBehaviour {


	public float walkSpeed;
	public Transform boundaryCheck;
	private float CheckRadius;
	public LayerMask whatIsBoundary;

	public float actionChangeWait;
	private float actionCount;
	private int action;

	public int releaseScore;
	public int releaseDetectionBonus;

	private Rigidbody2D myRigidBody2D;
	private bool isRight;
	private bool boundaryHit;

	private Animator anim;

	// Use this for initialization
	void Start () {
		myRigidBody2D = gameObject.GetComponent<Rigidbody2D> ();
		anim = gameObject.GetComponent<Animator> ();
		isRight = Random.Range (0f, 1f) > 0.5;
		actionCount = 0;
		CheckRadius = 0.1f;
	}

	void FixedUpdate (){
		boundaryHit = Physics2D.OverlapCircle (boundaryCheck.position, CheckRadius, whatIsBoundary);
	}

	// Update is called once per frame
	void Update () {

		if (actionCount <= 0) {
			actionCount = actionChangeWait;
			isRight = Random.Range (0f, 1f) > 0.5;
			action = Random.Range (0, 10);
		}

		if (action > 2) {
			if (boundaryHit) {
				isRight = !isRight;
			}

			if (isRight) {
				gameObject.transform.localScale = new Vector3 (-Mathf.Abs (gameObject.transform.localScale.x), gameObject.transform.localScale.y, gameObject.transform.localScale.z);
				myRigidBody2D.velocity = new Vector2 (walkSpeed, myRigidBody2D.velocity.y);
			} else if (!isRight) {
				gameObject.transform.localScale = new Vector3 (Mathf.Abs (gameObject.transform.localScale.x), gameObject.transform.localScale.y, gameObject.transform.localScale.z);
				myRigidBody2D.velocity = new Vector2 (-walkSpeed, myRigidBody2D.velocity.y);
			} else {
				myRigidBody2D.velocity = new Vector2 (0f, myRigidBody2D.velocity.y);
			}
		} else {
			myRigidBody2D.velocity = new Vector2 (0f, myRigidBody2D.velocity.y);
		}

		actionCount -= Time.deltaTime;

		anim.SetFloat("velocity", Mathf.Abs(myRigidBody2D.velocity.x));
	}

	public int getReleaseScore(){
		return releaseScore;
	}

	public int getReleaseDetectionBonus(){
		return releaseDetectionBonus;
	}
}
