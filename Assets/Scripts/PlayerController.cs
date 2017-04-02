using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float jumpForce = 6f;
	public float runningSpeed = 1.5f;
	private Rigidbody2D rigidBody;
	public Animator animator;

	void Awake(){
		rigidBody = GetComponent<Rigidbody2D> ();
	}

	// Use this for initialization
	void Start () {
		animator.SetBool ("isAlive", true);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Jump ();		
		}

		animator.SetBool ("isGrounded", IsGrounded ());
	}

	void FixedUpdate(){
		
		if (rigidBody.velocity.y < runningSpeed) {
			rigidBody.velocity = new Vector2 (runningSpeed, rigidBody.velocity.y);
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
		
}
