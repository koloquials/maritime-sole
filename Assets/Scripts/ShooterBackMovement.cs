using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterBackMovement : MonoBehaviour {
	public GameObject player;
	SpriteRenderer sprite;
	float armShift = 0.0f;

	void Start () {
		sprite = GetComponent<SpriteRenderer> ();
	}

	void Update () {
		Vector3 currentPos = player.transform.position;
		currentPos.x -= .10f; //nudges the shooter a bit to the side
		currentPos.x += armShift;
		currentPos.y += .18f;
		currentPos.z -= 2f;
		transform.position = currentPos;

		//aims towards mouse
		Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
		Vector3 dir = Input.mousePosition - pos;
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

		if (angle < 90f && angle > -90) {
			PlayerMovement.direction = 'r';
		} else {
			PlayerMovement.direction = 'l';
		}

		if (PlayerMovement.direction == 'l') {
			sprite.flipY = true;
			armShift = 0.15f;
		} else {
			sprite.flipY = false;
			armShift = 0.0f;
		}
			
	}
}
