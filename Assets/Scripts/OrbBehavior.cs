using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbBehavior : MonoBehaviour {
	GameObject player;
    public GameObject[] orbs;
    float xMod;
	float yMod = -0.8f;

	void Start () {
		player = GameObject.FindWithTag("Player");
        //xMod = transform.position.x - player.transform.position.x;
        
        orbs = GameObject.FindGameObjectsWithTag("Orb");
        xMod = -0.7f+(.4f*orbs.Length); //This fixes the varying orb spawn problem ♥ -C
    }

	void Update () {
		Vector3 currentPos = player.transform.position;
		

        if (PlayerMovement.direction == 'r')
        {
            currentPos.x += xMod;
            currentPos.y += yMod;
        }
        else
        {
            currentPos.x += xMod-.15f;//Fixes the flippity flopity stuff
            currentPos.y += yMod;
        }
        transform.position = currentPos;
    }
}
