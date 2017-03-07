using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearBehavior : MonoBehaviour {
	Rigidbody2D spearRB;
	public SpriteRenderer sprite;
	public float velY = 0f;
	public float velX = 0f;
	bool hitSolid = false;
	float f = 1f;
	int count = 120;

	public GameObject triggeredObj;

	void Start () {
		spearRB = GetComponent<Rigidbody2D>();
		spearRB.AddForce (new Vector2 (velX, velY), ForceMode2D.Impulse);
	}

	void Update () {
		if (hitSolid == true) {
			spearRB.velocity = Vector3.zero;
			spearRB.isKinematic = true;
			if (count > 0) {
				count--;
			}
			else if (count <= 0) {
				f -= 0.02f;
				sprite.color = new Color (0.2f, 0f, 1f, f);
				if (f <= 0) {
					Destroy (this.gameObject);
				}
			}
		}
	}
	void OnTriggerEnter2D(Collider2D otherCollider) {
		if (otherCollider.gameObject.tag == "Solid" || otherCollider.gameObject.tag == "Fall Puzzle" || otherCollider.gameObject.tag == "Fade Puzzle" || otherCollider.gameObject.tag == "Grate" ) {
			hitSolid = true;
		}
		if (otherCollider.gameObject.tag == "Trigger" || otherCollider.gameObject.tag == "Heavy Trigger" || otherCollider.gameObject.tag == "Wall Trigger") {
			hitSolid = true;
			triggeredObj = otherCollider.gameObject;
			TriggerBehavior triggBehave = triggeredObj.GetComponent<TriggerBehavior>();
			triggBehave.activated = true;
		}
	}
}
