using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationCanvas : MonoBehaviour
{
    public Camera myCamera;
    
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(transform.position + myCamera.transform.rotation * Vector3.up,
             myCamera.transform.rotation * Vector3.down
            );
    }
}
