using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comer : MonoBehaviour {
    Animator bearAnimator;
    int AUX=0;
    // Use this for initialization

    void Start() {
        bearAnimator = GetComponentInParent<Animator>();
        bearAnimator.SetBool("eat", true);
        //bearAnimator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (AUX>100)
        if (transform.localScale.x >2F)
        {
            bearAnimator.SetBool("eat", true);
            transform.localScale -= new Vector3(0.02F, 0.02F, 0.02F);
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
        else
        {
            bearAnimator.SetBool("eat", false);
            transform.localScale = new Vector3(0.0F, 0.0F, 0.0F);
        }
        AUX++;
     }
}
