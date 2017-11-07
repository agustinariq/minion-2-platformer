using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed = 20f;
	public float maxSpeed = 5f;
	public bool grounded;
	public float jumpPower = 6.5f;
	private bool jump;
	public int hearts = 1;
	public int coins = 0;

	private Rigidbody2D rigidBody;
	private Animator animator;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.Space) && grounded) { jump = true; }
	}

	// Update is called once per frame
	void FixedUpdate () {
		UpdateAnimationVariables ();
		HorizontalMomevent ();
		LimitVelocity ();
		FacingDirectrion ();
		CheckDeath ();
		Debug.Log (coins);

		if (jump) {
			SoundManager.PlaySound ("jump");
			rigidBody.AddForce (Vector2.up * jumpPower, ForceMode2D.Impulse);
			jump = false;
		}

		//Debug.Log (animator.GetBool("grounded"));
		//Debug.Log (rigidBody.velocity.x);
	}

	void OnTriggerEnter2D(Collision2D col){
		if (col.gameObject.CompareTag ("coin")) {
			SoundManager.PlaySound ("coin");
			Destroy (col.gameObject);
			coins += 1;
		}
	}

	void OnCollisionStay2D(Collision2D col){
		if (col.gameObject.tag == "ground") { grounded = true; }
		if (col.gameObject.tag == "platform") { 
			gameObject.transform.parent = col.transform;
			grounded = true;
		}
	}

	void OnCollisionExit2D(Collision2D col){
		if (col.gameObject.tag == "ground") { grounded = false; }
		if (col.gameObject.tag == "platform") { 
			gameObject.transform.parent = null;
			grounded = false; 
		}
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

	public void EnemyJump(){
		jump = true;
	}

	public void EnemyKnockback(float enemyPositionX){
		//jump = true;
		float side = Mathf.Sign (enemyPositionX - transform.position.x);
		rigidBody.AddForce (Vector2.left * side * 10, ForceMode2D.Impulse);
	}

	public void CheckDeath(){
		if (hearts < 1) {  
			//Destroy (gameObject);
			SoundManager.PlaySound ("death");
			gameObject.active = false;
			//trigger game over
		}
	}
	public void TakeDamage(){
			hearts -= 1;
		}

}
