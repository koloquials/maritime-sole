using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterMovement : MonoBehaviour {
	public GameObject player;
	public GameObject spearProjectile;
	public GameObject bombProjectile;
	public GameObject dustProjectile;
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

		//angles shooter towards mouse
		Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
		Vector3 dir = Input.mousePosition - pos;
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

		//calculates if facing left or right + flips arm sprite
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

		if (Input.GetMouseButtonDown (0) && ComponentManager.canShoot == true) {
			Vector3 newObjPos = player.transform.position;

			//placing the projectile. its hardcoded because im dead inside and frankly shouldn't be tweaked anyways
			newObjPos.x += (Mathf.Cos (Mathf.Atan2 (dir.y, dir.x)) * 0.2f);
			newObjPos.y += (Mathf.Sin (Mathf.Atan2 (dir.y, dir.x)) * 0.2f) + 0.1f;
			newObjPos.z += 10f;

			if (ComponentManager.type == 'e') { 
				SpearBehavior spearBehave = spearProjectile.GetComponent<SpearBehavior> ();
				spearBehave.velX = (Mathf.Cos (Mathf.Atan2 (dir.y, dir.x)) * 10f);
				spearBehave.velY = (Mathf.Sin (Mathf.Atan2 (dir.y, dir.x)) * 10f);
			}
			if (ComponentManager.type == 'r') {
				BombBehavior bombBehave = bombProjectile.GetComponent<BombBehavior> ();
				bombBehave.velX = (Mathf.Cos (Mathf.Atan2 (dir.y, dir.x)) * 7f);
				bombBehave.velY = (Mathf.Sin (Mathf.Atan2 (dir.y, dir.x)) * 7f);
			}
			if (ComponentManager.type == 'f') {
				DustBehavior dustBehave = dustProjectile.GetComponent<DustBehavior> ();
				dustBehave.velX = (Mathf.Cos (Mathf.Atan2 (dir.y, dir.x)) * 4f);
				dustBehave.velY = (Mathf.Sin (Mathf.Atan2 (dir.y, dir.x)) * 4f);
			}

			//make hte dang bullet. for sale: bullet, never referenced
			if (ComponentManager.type == 'e') {
				GameObject bullet = Instantiate (spearProjectile, newObjPos, Quaternion.AngleAxis (angle, Vector3.forward)) as GameObject;
			}
			if (ComponentManager.type == 'r') {
				GameObject bullet = Instantiate (bombProjectile, newObjPos, Quaternion.AngleAxis (angle, Vector3.forward)) as GameObject;
			}
			if (ComponentManager.type == 'f') {
				GameObject bullet1 = Instantiate (dustProjectile, newObjPos, Quaternion.AngleAxis (angle + Random.Range(-20f, 20f), Vector3.forward)) as GameObject;
				GameObject bullet2 = Instantiate (dustProjectile, newObjPos, Quaternion.AngleAxis (angle + Random.Range(-20f, 20f), Vector3.forward)) as GameObject;
				GameObject bullet3 = Instantiate (dustProjectile, newObjPos, Quaternion.AngleAxis (angle + Random.Range(-20f, 20f), Vector3.forward)) as GameObject;
				GameObject bullet4 = Instantiate (dustProjectile, newObjPos, Quaternion.AngleAxis (angle + Random.Range(-20f, 20f), Vector3.forward)) as GameObject;
				GameObject bullet5 = Instantiate (dustProjectile, newObjPos, Quaternion.AngleAxis (angle + Random.Range(-20f, 20f), Vector3.forward)) as GameObject;
			}
			//maybe replace with an array like a sensible human being later
		} 
		else if (Input.GetMouseButtonDown (0) && ComponentManager.canShoot == false){
			//print ("cannot shoot. not enough components loaded!");
			//denial or empty sound goes here
		}
	}
}
