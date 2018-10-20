using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FijarPosicion : MonoBehaviour {
    public float x, y, z;
    
	// Use this for initialization
	void Start () {
        transform.localPosition = new Vector3(x,y,z);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
