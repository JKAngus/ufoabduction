using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class StockManager : MonoBehaviour {

	public PlayerController player;
	public LevelManager levelManager;

	public Text stockText;
	public Text humanText;

	private List<GameObject> stocksList;
	private int stocks;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ();
		levelManager = FindObjectOfType<LevelManager> ();
		stocksList = new List<GameObject> ();
		stocks = 0;
	}
	
	// Update is called once per frame
	void Update () {
		stockText.text = "STOCK: " + stocks;
		humanText.text = "HUMANS: " + levelManager.humanToAbduct;
	}

	public void addStock(GameObject alien){
		stocksList.Add (alien);
		stocks++;
	}

	public GameObject releaseStock(){
		if (stocks > 0) {
			stocks--;
			GameObject temp = stocksList [0];
			stocksList.RemoveAt (0);
			return temp;
		} else
			return null;
	}

	public int getStock(){
		return stocks;
	}
}
