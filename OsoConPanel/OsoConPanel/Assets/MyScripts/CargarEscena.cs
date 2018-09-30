using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargarEscena : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(Botones.BOTON_A) || Input.GetKeyDown(Botones.BOTON_B) ||
            Input.GetKeyDown(Botones.BOTON_C) || Input.GetKeyDown(Botones.BOTON_D) ||
            Input.GetKeyDown(Botones.BOTON_R1) || Input.GetKeyDown(Botones.BOTON_R2))
        {
            var a = GetComponent<LoadScene>();
            a.enabled = true;
        }
	}
}
