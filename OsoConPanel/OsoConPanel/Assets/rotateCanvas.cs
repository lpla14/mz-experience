using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateCanvas : MonoBehaviour
{
    public Camera myCamera;
    
    // Update is called once per frame
    void Update()
    {
        if ( myCamera != null )
        { 
            transform.LookAt(transform.position + myCamera.transform.rotation * Vector3.up,
                 myCamera.transform.rotation * Vector3.down
                );
        }
    }
}