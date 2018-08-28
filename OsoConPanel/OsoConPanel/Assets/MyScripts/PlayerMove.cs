using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMove : MonoBehaviour {

    CharacterController charControl;
    public float walkSpeed;

    void Awake()
    {
        charControl = GetComponent<CharacterController>();
    }

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");
        
        Vector3 moveDirSide = transform.right * vert * walkSpeed;
        Vector3 moveDirForward = transform.forward * horiz * walkSpeed;
        
        charControl.SimpleMove(moveDirSide);
        charControl.SimpleMove(moveDirForward);

        //float horizontalAxis = CrossPlatformInputManager.GetAxis("Horizontal");
        //float verticalAxis = CrossPlatformInputManager.GetAxis("Vertical");

        ////var camera = GameObject.Find("racterersonCharacter");
        //var camera = gameObject.GetComponentInChildren<Camera>();


        ////camera forward and right vectors:
        //var forward = camera.transform.forward;
        //var right = camera.transform.right;

        ////project forward and right vectors on the horizontal plane (y = 0)
        //forward.y = 0f;
        //right.y = 0f;
        //forward.Normalize();
        //right.Normalize();

        ////this is the direction in the world space we want to move:
        //var desiredMoveDirection = forward * verticalAxis + right * horizontalAxis;

        ////now we can apply the movement:
        //transform.Translate(desiredMoveDirection * walkSpeed * Time.deltaTime);


    }
}
