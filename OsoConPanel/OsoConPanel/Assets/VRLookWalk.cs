using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRLookWalk : MonoBehaviour {
    public Transform vrCamera;
    public float toggleAngle = 30.0f;
    public float speed = 3.0f;
    public bool moveForward;

    private CharacterController cc;
    // Use this for initialization
    void Start () {
        cc = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetAxis("Horizontal") < 0)
        {
            Vector3 forward = vrCamera.TransformDirection(Vector3.forward);
            cc.SimpleMove(forward * speed);
            //moveForward = true;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            Vector3 back = vrCamera.TransformDirection(Vector3.back);
            cc.SimpleMove(back * speed);
            //moveForward = true;
        }
        if (Input.GetAxis("Vertical") > 0)
        {
            Vector3 right = vrCamera.TransformDirection(Vector3.right);
            cc.SimpleMove(right * speed);
            //moveForward = true;
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            Vector3 left = vrCamera.TransformDirection(Vector3.left);
            cc.SimpleMove(left * speed);
            //moveForward = true;
        }
        if (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0)
        {
            Vector3 zero = vrCamera.TransformDirection(Vector3.zero);
            cc.SimpleMove(zero);
            //moveForward = true;
        }

    }
}
 


/*
 if (moveForward)
        {
            Vector3 forward = vrCamera.TransformDirection(Vector3.forward);
cc.SimpleMove(forward* speed);
            
        }
else
        {
            moveForward = false;
        }

    */