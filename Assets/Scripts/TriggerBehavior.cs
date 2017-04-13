using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBehavior : MonoBehaviour {
	public bool activated = false;
	public SpriteRenderer sprite;
	float angle = 0;
	public static int affectedObjNum = 1;
	public GameObject[] affectedObjArray = new GameObject[affectedObjNum];
    bool lowered = false;

	void Start () {	
	}

	void Update () {
		if (activated == true) {
            //should only flip the falling platform triggers, but im too tired to figure it out rn
            //Yo Rachel I got you ♥ You could do tags or add a manually controlled bool, but I am lazy af -C
            if (this.name.Substring(0, 6) == "Switch")//Aka only the rope things on the ceiling- it checks the beginning of the string for "Switch"
            {
                angle = transform.localEulerAngles.y;
                transform.localRotation = Quaternion.Euler(0, angle + 180, 0);
            }else if (!lowered)
            {
               transform.position=new Vector3(transform.position.x, transform.position.y-.03f,0);//I wanted it to have some sort of visual feedback, so TADA 
                lowered = true;
            }
			for (int i = 0; i < affectedObjArray.Length; i++) {
				PuzzleBehavior pzlObject = affectedObjArray[i].GetComponent<PuzzleBehavior> ();
				pzlObject.activated = true;
			}
			activated = false;
		}
	}
}
