﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadSceneAyuda : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(Botones.BOTON_C) || Input.GetKeyDown(KeyCode.P))
        {
            var script = GetComponent<LoadScenePausa>();
            script.enabled = true;
        }

    }
}