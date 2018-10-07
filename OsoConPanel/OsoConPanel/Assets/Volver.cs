using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volver : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(Botones.BOTON_R2)) {
            GetComponent<LoadScene>().enabled = true;
        }
	}
}
