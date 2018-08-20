using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConejoControlador : MonoBehaviour {
    Animator conejoAnimator;
	// Use this for initialization
	void Start () {
        conejoAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (conejoAnimator.GetBool("Saltando"))
        {
            transform.position += new Vector3(0.1f, 0, 0);
        }
	}
}
