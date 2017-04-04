using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
	public GameObject player;
	public float lLimit = 0;
	public float rLimit;

	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if (player.transform.position.x > lLimit && player.transform.position.x < rLimit  ) {
			Vector3 newPos = transform.position;
			newPos.x = player.transform.position.x;
			transform.position = newPos;
		}
	}
}
