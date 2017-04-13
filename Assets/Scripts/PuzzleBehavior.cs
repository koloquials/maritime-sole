using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleBehavior : MonoBehaviour {
	Rigidbody2D pzlRB;
	public SpriteRenderer sprite;
	public bool activated = false;
	bool started = false; //for timing
	float f = 1f; // for fading

	void Start () {
		pzlRB = GetComponent<Rigidbody2D>();
		pzlRB.isKinematic = true;
	}

	void Update () {
		if (gameObject.tag == "Fall Puzzle") {
			if (activated == true && started == true && pzlRB.velocity.y == 0 && this.gameObject.transform.rotation.z < 1) { //make static after it is done
				pzlRB.isKinematic = true;
				pzlRB.freezeRotation = true;
                //print ("AAAA");
                //this.gameObject.layer = 12;
            }
			if (activated == true && started == false) { //activate falling
				pzlRB.isKinematic = false;
				started = true;
               // this.gameObject.layer = 16;

			}
		}
		if (gameObject.tag == "Raise Puzzle") {
			if (activated == true && started == true && pzlRB.velocity.y == 0) { //make static after it stops moving
				pzlRB.isKinematic = true;
				activated = false;
				started = false;
			}
			if (activated == true && started == false) { //activate rising
				pzlRB.isKinematic = false;
				pzlRB.gravityScale = -0.5f;
				started = true;
			}
		}
		if (gameObject.tag == "Fade Puzzle" && activated == true) {
			f -= 0.02f;
			sprite.color = new Color (1f, 1f, 1f, f);
			if (f <= 0) {
				//Destroy (this.gameObject);
				this.gameObject.SetActive(false);
			}
		}
        //more here
    }
   


    }
