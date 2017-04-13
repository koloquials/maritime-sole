using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustBehavior : MonoBehaviour {
	Rigidbody2D dustRB;
	public SpriteRenderer sprite;
	public float velY = 0f;
	public float velX = 0f;
	bool stopMove = false;

	float f = 1f;
	int count = 120;

	public GameObject triggeredObj;

	void Start () {
		dustRB = GetComponent<Rigidbody2D>();
		dustRB.AddForce (new Vector2 (velX, velY), ForceMode2D.Impulse);
	}

	void Update () {
		if (dustRB.velocity.y == 0) {
			stopMove = true;
		}
		if (stopMove == true) {
			if (count > 0) {
				count--;
			}
			else if (count <= 0) {
				f -= 0.02f;
                sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, f);
				//sprite.color = new Color (0.2f, 0f, 1f, f);
				if (f <= 0) {
					Destroy (this.gameObject);
				}
			}
		}
	}
	void OnTriggerEnter2D(Collider2D otherCollider) {
		if (otherCollider.gameObject.tag == "Trigger") {
			triggeredObj = otherCollider.gameObject;
			TriggerBehavior triggBehave = triggeredObj.GetComponent<TriggerBehavior>();
			triggBehave.activated = true;
		}
	}
}
