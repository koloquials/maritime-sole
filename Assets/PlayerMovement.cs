using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	Rigidbody2D player;
	float moveSpeed = 0.15f;
	float backwardSpeed = 0.08f;
	bool airborne = false;
	RaycastHit2D hit;
	public static char direction;

	void Start () {
		player = GetComponent<Rigidbody2D>();
	}

	void Update () {
		Vector3 currentPos = transform.position;

		//can only jump if not falling
		if (player.velocity.y != 0) {
			airborne = true;
		} else {
			airborne = false;
		}

		//keys
		if (Input.GetKey(KeyCode.W) && airborne == false) {
			player.AddForce (new Vector2 (0f, 9.5f), ForceMode2D.Impulse);
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
