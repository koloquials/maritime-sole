using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentManager : MonoBehaviour {
	public GameObject player;
	public GameObject eOrb;
	public GameObject rOrb;
	public GameObject fOrb;
	public GameObject[] orbArray = new GameObject[3];
	int total;
	int eCount; //spear
	int rCount; //needles
	int fCount; //blast
	int orbs;
	public static bool canShoot = false;
	public static char type = 's';

	void Start () {
		resetCount ();
	}
	
	// Update is called once per frame
	void Update () {
		if ((eCount > 0 && rCount > 0) || (eCount > 0 && fCount > 0) || (fCount > 0 && rCount > 0)) {
			print ("error! incompatible orb types loaded!");
			resetCount ();
		}

		if (Input.GetKeyDown (KeyCode.E) && total < 3) {
			displayOrb ("e");
			eCount++;
		} else if (Input.GetKeyDown (KeyCode.E) && total >= 3){
			declareOver ();
		}
		if (Input.GetKeyDown(KeyCode.R) && total < 3) {
			displayOrb ("r");
			rCount++;
		} else if (Input.GetKeyDown (KeyCode.R) && total >= 3){
			declareOver ();
		}
		if (Input.GetKeyDown(KeyCode.F) && total < 3) {
			displayOrb ("f");
			fCount++;
		} else if (Input.GetKeyDown (KeyCode.F) && total >= 3){
			declareOver ();
		}

		if (eCount >= 3) {
			type = 'e';
		}
		if (rCount >= 3) {
			type = 'r';
		}
		if (fCount >= 3) {
			type = 'f';
		}

		if (Input.GetKeyDown (KeyCode.Q)) {
			resetCount ();
		}
		total = eCount + rCount + fCount;
		if (total == 3) {
			canShoot = true;
		}
	}

	void displayOrb(string code){
		GameObject temp = eOrb;
		Vector3 startPos = player.transform.position;
		startPos.x -= 0.4f;
		startPos.y -= 0.8f;

		switch (code) {
		case "e":
			temp = eOrb;
			break;
		case "r":
			temp = rOrb;
			break;
		case "f":
			temp = fOrb;
			break;
		default:
			print ("error! invalid orb letter");
			break;
		}
        //All the commented out code was diagnosing and failed fixes, leaving it just in case :P -C

        //if (orbArray.Length == 0) {
            startPos.x += (0.4f * orbs);
        //}else if(orbArray.Length>0&&orbs>=1){
            //startPos.x = orbArray[orbs-1].transform.position.x +0.4f;
       // }else{
            //Debug.Log("We should never see this");
       // }
        orbArray[orbs] = Instantiate(temp, startPos, Quaternion.AngleAxis(0f, Vector3.forward)) as GameObject;
		orbs++;
	}

	void declareOver(){
		//for sound effects or other indicators later when there are more than three orbs
		print ("three components already loaded");
	}

	void resetCount(){
		total = 0;
		eCount = 0;
		rCount = 0;
		fCount = 0;
		orbs = 0;
		Destroy (orbArray [0]);
		Destroy (orbArray [1]);
		Destroy (orbArray [2]);
		canShoot = false;
	}
}
