using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlceInteraction : MonoBehaviour {

    Animator alceAnimator;

    private string estadoCaminar = "Caminar";
    private string estadoComer   = "Comiendo";

    // Use this for initialization
    void Start () {
        alceAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Joystick1Button2)) {
            alceAnimator.SetBool(estadoCaminar, !alceAnimator.GetBool(estadoCaminar));

            alceAnimator.SetBool(estadoComer, !alceAnimator.GetBool(estadoCaminar));
            
        }
        if (alceAnimator.GetBool(estadoCaminar)) {
            transform.position += new Vector3(-0.01F, 0, 0);
        }
	}
}
