using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewGameOver : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.instance.currentGameState == GameState.gameOver) {
			highscoreLabel.text = PlayerPrefs.GetFloat ("highscore", 0).ToString ("f0");
		}
	}

	public Text highscoreLabel;
	public Text coinsLabel;
}
