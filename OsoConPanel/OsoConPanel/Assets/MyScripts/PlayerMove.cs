using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMove : MonoBehaviour
{

    public bool moveForward;
    private Transform vrHead;
    private CharacterController charControl;
    public float walkSpeed;

    void Start()
    {
        charControl = GetComponent<CharacterController>();

        vrHead = Camera.main.transform;
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
    }
}

