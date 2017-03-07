using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBehavior : MonoBehaviour {
	public bool activated = false;
	public SpriteRenderer sprite;

	public static int affectedObjNum = 1;
	public GameObject[] affectedObjArray = new GameObject[affectedObjNum];

	void Start () {		
	}

	void Update () {
		if (activated == true) {
			sprite.color = new Color (1f, 1f, 1f);

			for (int i = 0; i < affectedObjArray.Length; i++) {
				PuzzleBehavior pzlObject = affectedObjArray[i].GetComponent<PuzzleBehavior> ();
				pzlObject.activated = true;
			}
			activated = false;
		}
	}
}
