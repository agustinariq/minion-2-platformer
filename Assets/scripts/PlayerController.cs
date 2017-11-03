using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed = 20f;
	public float maxSpeed = 5f;
	public bool grounded;
	public float jumpPower = 6.5f;
	private bool jump;

	private Rigidbody2D rigidBody;
	private Animator animator;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.UpArrow) && grounded) { jump = true; }
	}

	// Update is called once per frame
	void FixedUpdate () {
		UpdateAnimationVariables ();
		HorizontalMomevent ();
		LimitVelocity ();
		FacingDirectrion ();

		if (jump) {
			rigidBody.AddForce (Vector2.up * jumpPower, ForceMode2D.Impulse);
			jump = false;
		}

		//Debug.Log (animator.GetBool("grounded"));
		//Debug.Log (rigidBody.velocity.x);
	}

	void OnCollisionStay2D(Collision2D col){
		if (col.gameObject.tag == "ground") { grounded = true; }
	}

	void OnCollisionExit2D(Collision2D col){
		if (col.gameObject.tag == "ground") { grounded = false; }
	}

	// animation control

	void UpdateAnimationVariables(){
		animator.SetFloat("speed", Mathf.Abs(rigidBody.velocity.x));
		animator.SetBool ("grounded", grounded);
	}

	void FacingDirectrion(){
		float dir = Input.GetAxis ("Horizontal");
		if (dir >= 0f) {
			transform.localScale = new Vector3 (1f, 1f, 1f);
		}
		if (dir < 0f) {
			transform.localScale = new Vector3 (-1f, 1f, 1f);
		}
	}

	// movement control

	void HorizontalMomevent(){
		float dir = Input.GetAxis ("Horizontal");
		rigidBody.AddForce (Vector2.right * speed * dir);
	}

	void LimitVelocity(){
		float limitedSpeed = Mathf.Clamp (rigidBody.velocity.x, -maxSpeed, maxSpeed);
		rigidBody.velocity = new Vector2 (limitedSpeed, rigidBody.velocity.y);
	}
}
