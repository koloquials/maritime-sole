using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	Rigidbody2D player;
	Animator anim;
	float jumpSpeed = 9.5f;
	float moveSpeed = 0.15f;
	float backwardSpeed = 0.08f;
	bool airborne = false;
	public static char direction;

	void Start () {
		player = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator> ();
	}

	void Update () {

		//looking in the right direction - meanwhile i wlak backwards into hell
		anim.SetFloat ("Speed", Mathf.Abs (Input.GetAxis ("Horizontal")));
		if (direction == 'l') {
			anim.transform.localRotation = Quaternion.Euler (0, 180, 0);
		} else {
			anim.transform.localRotation = Quaternion.Euler (0, 0, 0);
		}

		//ensure can only jump if not falling + jump animation parameter
		if (player.velocity.y > 0.05f || player.velocity.y < -0.05f) {
			airborne = true;
		} else {
			airborne = false;
		}
		anim.SetBool ("Jumping", airborne);
			
		//movement
		Vector3 currentPos = transform.position;
		if (Input.GetKey(KeyCode.W) && airborne == false) {
			player.AddForce (new Vector2 (0f, jumpSpeed), ForceMode2D.Impulse);
		}
		else if (Input.GetKey(KeyCode.A)) {
			if (direction == 'r') {
				currentPos.x -= backwardSpeed;
			} else {
				currentPos.x -= moveSpeed;
			}
		}
		else if (Input.GetKey(KeyCode.D)) {
			if (direction == 'l') {
				currentPos.x += backwardSpeed;
			} else {
				currentPos.x += moveSpeed;
			}
		}
		transform.position = currentPos;
	}


}
