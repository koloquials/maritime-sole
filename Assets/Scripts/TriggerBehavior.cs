using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBehavior : MonoBehaviour {
	public bool activated = false;
	public SpriteRenderer sprite;
	float angle = 0;
	public static int affectedObjNum = 1;
	public GameObject[] affectedObjArray = new GameObject[affectedObjNum];

	void Start () {	
	}

	void Update () {
		if (activated == true) {
			//should only flip the falling platform triggers, but im too tired to figure it out rn

			angle = transform.localEulerAngles.y;
			transform.localRotation = Quaternion.Euler (0, angle + 180, 0);

			for (int i = 0; i < affectedObjArray.Length; i++) {
				PuzzleBehavior pzlObject = affectedObjArray[i].GetComponent<PuzzleBehavior> ();
				pzlObject.activated = true;
			}
			activated = false;
		}
	}
}
