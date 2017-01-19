using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject player;


	// Use this for initialization
	void Start () {
		
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if(player.transform.position.x > -3.5 && 
			player.transform.position.x < 13.5 &&
			player.GetComponent<PlayerController>().isPlayerAlive()){
			gameObject.transform.position = new Vector3 (player.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
		}
	}
}
