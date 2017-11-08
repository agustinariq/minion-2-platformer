using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {


	public Transform target;
	public float speed;
	public SpriteRenderer spriteRenderer;
	public GameObject coin;

	private Vector3 startPosition;
	private Vector3 endPosition;

	// Use this for initialization
	void Start () {
		target.parent = null;
		startPosition = transform.position;
		endPosition = target.position;
		spriteRenderer = GetComponentInChildren<SpriteRenderer> ();

	}
		
	// Update is called once per frame
	void FixedUpdate () {
		float deltaSpeed = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards (transform.position, target.position, deltaSpeed);
		spriteFlip ();
		if (transform.position == target.position) {
			target.position = (target.position == startPosition) ? endPosition : startPosition;
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "player") {
			float yOffset = 0.32f;
			if (transform.position.y + yOffset < col.transform.position.y) { 
				col.SendMessage ("EnemyJump");
				///
				Instantiate(coin, transform.position, coin.transform.rotation);
				///
				Destroy (gameObject);
			} else {
				col.SendMessage ("EnemyKnockback", transform.position.x);
				col.SendMessage ("TakeDamage");
			}

		}
	
	}

	void spriteFlip(){
		if (target.position == startPosition) { spriteRenderer.flipX = true; }
		if (target.position == endPosition) { spriteRenderer.flipX = false; }
	}

	void hideCoin(){
		coin.SetActive (false);
	}
}

