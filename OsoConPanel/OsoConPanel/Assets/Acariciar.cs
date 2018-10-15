using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acariciar : MonoBehaviour {

    private float posInicial;
    private float posFinal;
    private bool adelante = true;
    private bool atras = false;

	// Use this for initialization
	void Start () {
        posInicial = transform.position.z;
        posFinal = posInicial - 1.43f;
        Debug.Log(posInicial);
        Debug.Log(posFinal);
	}

    // Update is called once per frame
    void Update() {
        if (transform.position.z > posFinal && adelante == true)
        { 
            transform.position -= new Vector3(0,0,0.02f);
         }
        else
        {
            adelante = false;
         }

        if (transform.position.z < posInicial && adelante == false)
        {
            transform.position += new Vector3(0, 0, 0.02f);
        }
        else
            adelante = true;
    }
}
