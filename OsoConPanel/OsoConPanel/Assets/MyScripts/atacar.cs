using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atacar : MonoBehaviour {
    public Animator morder;
	// Use this for initialization
	void Start () {
        morder = GetComponent<Animator>();
	}

    // Update is called once per frame
    /*Si usamos la funcion update en el vent trigger debemos activar la casilla que esta justo debajo de la funcion y justo
     * al lado del object
     * void Update () {
        morder.Play("Arm_bear|hate_1");
	}
    */
    public void gritar()
    {
        morder.Play("Arm_bear|hate_1");
    }
    public void morir()
    {
        morder.Play("Arm_bear|dead_2");
    }
}
