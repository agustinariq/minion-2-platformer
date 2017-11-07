using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {


	public Transform target;
	public float speed;
	public SpriteRenderer spriteRenderer;

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

	void spriteFlip(){
		if (target.position == startPosition) { spriteRenderer.flipX = true; }
		if (target.position == endPosition) { spriteRenderer.flipX = false; }
	}
}

