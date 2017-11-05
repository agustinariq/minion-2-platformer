using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

	public Transform target;
	public float speed;

	private Vector3 startPosition;
	private Vector3 endPosition;

	// Use this for initialization
	void Start () {
		target.parent = null;
		startPosition = transform.position;
		endPosition = target.position;
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float deltaSpeed = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards (transform.position, target.position, deltaSpeed);

		if (transform.position == target.position) {
			target.position = (target.position == startPosition) ? endPosition : startPosition;
		}
	}
}
