﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitApp : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(Botones.BOTON_R1))
        {
            //no funciona en modo Editor
            Application.Quit();
        }
    }
}