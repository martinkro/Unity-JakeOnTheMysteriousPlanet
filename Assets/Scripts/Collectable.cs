using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {

	bool isCollected = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Show(){
		this.GetComponent<SpriteRenderer> ().enabled = true;
		this.GetComponent<CircleCollider2D> ().enabled = true;
		isCollected = false;
	}

	void Hide(){
		this.GetComponent<SpriteRenderer> ().enabled = false;
		this.GetComponent<CircleCollider2D> ().enabled = false;
	}

	void Collect(){
		isCollected = true;
		Hide ();
		GameManager.instance.CollectCoin ();
	}

	void OnEnterTrigger2D(Collider2D other){
		if (other.tag == "Player") {
			Collect ();
		}
	}
}
