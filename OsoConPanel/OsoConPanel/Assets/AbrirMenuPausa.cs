﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirMenuPausa : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(Botones.BOTON_C))
        {
            var script = GetComponent<LoadScene>();
            script.enabled = true;
        }

    }
}