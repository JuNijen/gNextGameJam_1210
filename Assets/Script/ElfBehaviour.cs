using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElfBehaviour : RobotsBehavior {
	public float jumpheight = 4f;
	public float timeToJumpApex = .4f;
	float accelerationTimeAirborne = .2f;
	float accelerationTimeGrounded = .1f;

	float gravity;
	float jumpVelocity;

	public bool grounded = false;

	void Start(){
		base.Start ();
		gravity = -(2 * jumpheight) / Mathf.Pow (timeToJumpApex, 2);
		jumpVelocity = Mathf.Abs (gravity) * timeToJumpApex;
	}

	void Update(){
		if (!grounded) {
			if (gameObject.GetComponent<Rigidbody2D> ().velocity.y < 0)
				jumpingdown ();
			if (gameObject.GetComponent<Rigidbody2D> ().velocity.y > 0)
				jumpingup ();
		}
		if (isActive && Input.GetKeyDown (KeyCode.Space) && grounded) {
			jump ();
		} else {
			if (gameObject.GetComponent<Rigidbody2D> ().velocity.magnitude > 0)
				gameObject.GetComponent<Rigidbody2D> ().velocity += new Vector2 (0, gravity * Time.deltaTime);
		}
		
		base.Update ();
	}

	void jump(){
		gameObject.GetComponent<Rigidbody2D> ().velocity += new Vector2 (0,jumpVelocity);
		grounded = false;
	}

	void OnCollisionEnter2D(Collision2D col){
		if (!grounded && col.gameObject.layer == LayerMask.NameToLayer ("Ground"))
			grounded = true;
	}

	void jumpingup(){
		setAnimation(1, "Jump_Up", false, 1f);
	}

	void jumpingdown(){
		setAnimation(1, "Jump_Down", false, 1f);
	}
}
