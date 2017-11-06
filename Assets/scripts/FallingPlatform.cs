using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour {

	public float fallRate = 1f;
	public float respawnRate = 1f;

	private Rigidbody2D rigidBody;
	private BoxCollider2D collider;
	private Vector3 start;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody2D> ();
		collider = GetComponent<BoxCollider2D> (); 
		start = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.CompareTag ("player")) {
			Invoke ("Fall", fallRate);
			Invoke ("Respawn", fallRate + respawnRate);
		}
	
	}

	void Fall(){
		rigidBody.isKinematic = false;
		collider.isTrigger = true;
	}

	void Respawn(){
		transform.position = start;
		rigidBody.isKinematic = true;
		rigidBody.velocity = Vector3.zero;
		collider.isTrigger = false;
	}
}
