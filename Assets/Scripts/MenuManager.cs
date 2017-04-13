using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {
	//oh, honestly i just planned to do this during polish because i didn't know if i wanted cutscenes too or not.

	void Start () {
	}

	void Update () {
		
        if (Input.GetMouseButton(0))
        {
            SceneManager.LoadScene("Stage 1");
            print("hi");
        }
    }
}
