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
		} else if (GameState.inGame == gameState) {
		} else if (GameState.gameOver == gameState) {
		}
		currentGameState = gameState;
	}
}
