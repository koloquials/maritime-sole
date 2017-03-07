using UnityEngine;
using System.Collections;

public class BallBehavior : MonoBehaviour {
	Rigidbody2D ballRB;
	bool isThrown;
	public Vector2 ballStartPos = new Vector2 (-3.91f, 0.79f);
	public float spaceHeld;

	public Sprite[] playerSprites;
	public SpriteRenderer playerObject;

	// Use this for initialization
	void Start () {
		ballRB = GetComponent<Rigidbody2D>();
		resetGame ();
	}
	
	// Update is called once per frame
	void Update () {
		while (Input.GetKeyDown (KeyCode.Space)) {
			playerObject.sprite = playerSprites [1];
			spaceHeld += (Time.deltaTime * 50);
			print (spaceHeld);
		}
		if (Input.GetKeyUp (KeyCode.Space) && isThrown == false) {
			ballRB.isKinematic = false;
			isThrown = true;
			ballRB.AddForce (new Vector2 (spaceHeld, (spaceHeld*1.6f)), ForceMode2D.Impulse);
			print (spaceHeld);
			playerObject.sprite = playerSprites [2];
		}  
		else if (Input.GetKeyDown (KeyCode.Return)) {
			resetGame ();
		}
	}

	void resetGame(){
		ballRB.isKinematic = true;
		transform.position = new Vector3 (ballStartPos.x, ballStartPos.y, 0);
		playerObject.sprite = playerSprites [0];
		isThrown = false;
		spaceHeld = 1f;
	}
}
