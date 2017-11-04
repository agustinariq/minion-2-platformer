using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public GameObject follow;
	public Vector2 minCameraPosition;
	public Vector2 maxCameraPosition;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		float posX = follow.transform.position.x;
		float posY = follow.transform.position.y;

		transform.position = new Vector3 (
			Mathf.Clamp(posX, minCameraPosition.x, maxCameraPosition.x), 
			Mathf.Clamp(posY, minCameraPosition.y, maxCameraPosition.y), 
			transform.position.z);
	}
}
