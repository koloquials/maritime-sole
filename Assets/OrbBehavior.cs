using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbBehavior : MonoBehaviour {
	GameObject player;

	float xMod;
	float yMod = -0.8f;

	void Start () {
		player = GameObject.FindWithTag("Player");
		xMod = transform.position.x - player.transform.position.x;
	}

	void Update () {
		Vector3 currentPos = player.transform.position;
		currentPos.x += xMod;
		currentPos.y += yMod;
		transform.position = currentPos;
	}
}
