using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoeController : MonoBehaviour {
    Animator doeAnimator;
    // Use this for initialization
    void Start()
    {
        doeAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (doeAnimator.GetBool("Caminando"))
        {
            transform.position += new Vector3(0, 0,-0.01F);
        }
    }
}
