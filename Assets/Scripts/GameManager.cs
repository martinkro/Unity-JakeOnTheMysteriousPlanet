using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState{
	menu = 1,
	inGame,
	gameOver
}
public class GameManager : MonoBehaviour {

	public static GameManager instance;
	public GameState currentGameState = GameState.menu;

	public Canvas menuCanvas;
	public Canvas inGameCanvas;
	public Canvas gameOverCanvas;

	public int collectedCoins = 0;

	void Awake(){
		instance = this;
	}
	// Use this for initialization
	void Start () {
		currentGameState = GameState.menu;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("s")) {
			StartGame ();
		}
	}

	public void StartGame(){
		PlayerController.instance.StartGame ();
		SetGameState (GameState.inGame);
	}

	public void GameOver(){
		SetGameState (GameState.gameOver);
	}

	public void BackToMenu(){
		SetGameState (GameState.menu);
	}

	void SetGameState(GameState gameState){
		if (GameState.menu == gameState) {
			menuCanvas.enabled = true;
			inGameCanvas.enabled = false;
			gameOverCanvas.enabled = false;
		} else if (GameState.inGame == gameState) {
			menuCanvas.enabled = false;
			inGameCanvas.enabled = true;
			gameOverCanvas.enabled = false;
		} else if (GameState.gameOver == gameState) {
			menuCanvas.enabled = false;
			inGameCanvas.enabled = false;
			gameOverCanvas.enabled = true;
		}
		currentGameState = gameState;
	}

	public void CollectCoin(){
		++collectedCoins;
	}
}
