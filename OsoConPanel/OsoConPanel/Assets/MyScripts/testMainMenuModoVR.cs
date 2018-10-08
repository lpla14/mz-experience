using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testMainMenuModoVR : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(Botones.BOTON_D))
        {
            //no funciona en modo Editor
            Application.Quit();
        }

        if (Input.GetKeyDown(Botones.BOTON_R1))
        {
            GetComponent<LoadScene>().enabled = true;
        }
    }
}
