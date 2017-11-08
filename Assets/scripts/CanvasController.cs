using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour {

	public GameObject gameOverText;
	public static GameObject GameOver;
	public GameObject gameClearText;
	public static GameObject GameClear;
	public GameObject player;
	public Text pointsText;

	// Use this for initialization
	void Start () {
		CanvasController.GameOver = gameOverText;
		CanvasController.GameOver.gameObject.SetActive (false);
		CanvasController.GameClear = gameClearText;
		CanvasController.GameClear.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		pointsText.text = "Points: " + player.GetComponent<PlayerController>().coins;

	}

	public static void ShowGameOverScreen(){
		CanvasController.GameOver.gameObject.SetActive (true);
	}

	public static void ShowGameClearScreen(){
		CanvasController.GameClear.gameObject.SetActive (true);
	}

}
