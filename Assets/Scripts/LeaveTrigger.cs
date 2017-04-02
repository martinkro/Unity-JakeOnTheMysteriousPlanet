﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		Debug.Log ("LeaveTrigger position - enter: " + other.transform.position);
		LevelGenerator.instance.AddPiece ();
		LevelGenerator.instance.RemoveOldestPiece ();

	}

	void OnTriggerLeave2D(Collider2D other){
		Debug.Log ("LeaveTrigger position - leave: " + other.transform.position);

	}
}
