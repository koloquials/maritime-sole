using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {

	void Start () {
	}

	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Application.LoadLevel ("Stage 1");
			print ("hi");
		}
	}
}
