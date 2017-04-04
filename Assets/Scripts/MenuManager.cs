using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {
	//oh, honestly i just planned to do this during polish because i didn't know if i wanted cutscenes too or not.

	void Start () {
	}

	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Application.LoadLevel ("Stage 1");
			print ("hi");
		}
	}
}
