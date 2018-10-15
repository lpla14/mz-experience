using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mano : MonoBehaviour {
    GameObject dedo1;
    GameObject dedo2;
    GameObject dedo3;
    GameObject dedo4;
    GameObject dedo5;
    bool cierra = true;
    float posInicial;
    float posFinal;
    // Use this for initialization
    void Start () {
        dedo1 = GameObject.Find("hands:b_r_thumb1");
        dedo2 = GameObject.Find("hands:b_r_index1");
        dedo3 = GameObject.Find("hands:b_r_middle1");
        dedo4 = GameObject.Find("hands:b_r_ring1");
        dedo5 = GameObject.Find("hands:b_r_pinky0");
        posInicial = dedo2.transform.eulerAngles.z;
        posFinal = posInicial - 45;
        Debug.Log(dedo2.transform.eulerAngles.z);
    }
	
	// Update is called once per frame
	void Update () {
    
        if (dedo2.transform.eulerAngles.z > posFinal && cierra == true)
        {
            Debug.Log("cerrando");
            dedo1.transform.eulerAngles -= new Vector3(0, 0, 1F);
            dedo2.transform.eulerAngles -= new Vector3(0, 0, 1f);
            dedo3.transform.eulerAngles -= new Vector3(0, 0, 1f);
            dedo4.transform.eulerAngles -= new Vector3(0, 0, 1f);
            dedo5.transform.eulerAngles -= new Vector3(0, 0, 1F);
        }
        else {
            cierra = false;
             }
        if (dedo2.transform.eulerAngles.z < posInicial && cierra == false)
        {
            Debug.Log("abriendo");
            dedo1.transform.eulerAngles += new Vector3(0, 0, 1F);
            dedo2.transform.eulerAngles += new Vector3(0, 0, 1f);
            dedo3.transform.eulerAngles += new Vector3(0, 0, 1f);
            dedo4.transform.eulerAngles += new Vector3(0, 0, 1f);
            dedo5.transform.eulerAngles += new Vector3(0, 0, 1F);
        }
        else
        {
            cierra = true;
           // dedo1.transform.eulerAngles = new Vector3(dedo1.transform.eulerAngles.x, dedo1.transform.eulerAngles.x, posInicial);
        }
    }
}
