using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public static PlayerController instance;
	public float jumpForce = 25f;
	public float runningSpeed = 1.5f;
	private Rigidbody2D rigidBody;
	public Animator animator;

	public Vector3 startingPosition;

	void Awake(){
		instance = this;
		rigidBody = GetComponent<Rigidbody2D> ();
		startingPosition = this.transform.position;
	}

	public void StartGame(){
		animator.SetBool ("isAlive", true);
		this.transform.position = startingPosition;
		rigidBody.velocity = new Vector2 (0.0f, 0.0f);
		Debug.Log ("Player position:" + this.transform.position);
	}

	// Use this for initialization
	void Start () {
		
		//animator.SetBool ("isAlive", true);
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.instance.currentGameState == GameState.inGame) {
			if (Input.GetMouseButtonDown (0)) {
				Jump ();		
			}

			animator.SetBool ("isGrounded", IsGrounded ());
		}

	}

	void FixedUpdate(){
		if (GameManager.instance.currentGameState == GameState.inGame) {
			if (rigidBody.velocity.y < runningSpeed) {
				rigidBody.velocity = new Vector2 (runningSpeed, rigidBody.velocity.y);
			}
		}


	}

	void Jump(){
		//Debug.Log ("GroundLayer:" + groundLayer.value);
		if (IsGrounded ()) {
			Debug.Log ("Is grounded - Position:" + this.transform.position);
			rigidBody.AddForce (Vector2.up * jumpForce, ForceMode2D.Impulse);
		} else {
			//Debug.Log ("Position:" + this.transform.position);
			//Debug.Log ("Is NOT grounded - Position:" + this.transform.position);
		}
	}

	public LayerMask groundLayer;
	bool IsGrounded(){

		// RaycastHit2D hit = Physics2D.Raycast (this.transform.position, Vector2.down, 0.2f, groundLayer.value);
		if (Physics2D.Raycast (this.transform.position, Vector2.down, 0.2f, groundLayer.value)){
			//Debug.DrawLine(this.transform.position, hit.transform.position, Color.red, 1.0f, true);
			//Debug.Log ("origin:" + this.transform.position + " dest:" + hit.transform.position);
			return true;
		}
		else{
			
			return false;
		}
	}

	public void Kill(){
		GameManager.instance.GameOver ();
		animator.SetBool ("isAlive", false);

		if (PlayerPrefs.GetFloat ("highscore", 0) < this.GetDistance ()) {
			PlayerPrefs.SetFloat ("highscore", this.GetDistance ());
		}
	}

	public float GetDistance(){
		float traveledDistance = Vector2.Distance (new Vector2(startingPosition.x, 0), new Vector2(this.transform.position.x, 0));
		return traveledDistance;
	}
		
}
