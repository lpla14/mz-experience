using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlceInteraction : MonoBehaviour {

    Animator alceAnimator;
	// Use this for initialization
	void Start () {
        alceAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Joystick1Button2)) {
            alceAnimator.SetBool("Caminar", !alceAnimator.GetBool("Caminar"));

            alceAnimator.SetBool("Comiendo", !alceAnimator.GetBool("Caminar"));

            

        }
        if (alceAnimator.GetBool("Caminar")) {
            transform.position += new Vector3(-0.06F, 0, 0);
        }
	}
}
