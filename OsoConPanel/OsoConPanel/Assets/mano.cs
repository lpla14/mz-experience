using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mano : MonoBehaviour {
    GameObject dedo1;
    GameObject dedo2;
    GameObject dedo3;
    GameObject dedo4;
    GameObject dedo5;
    bool cierra = true;
    float posInicialDedo2;
    float posFinalDedo2;

    // Use this for initialization
    void Start () {
        dedo1 = GameObject.Find("hands:b_r_thumb1");
        dedo2 = GameObject.Find("hands:b_r_index1");
        dedo3 = GameObject.Find("hands:b_r_middle1");
        dedo4 = GameObject.Find("hands:b_r_ring1");
        dedo5 = GameObject.Find("hands:b_r_pinky0");
        posInicialDedo2 = dedo2.transform.eulerAngles.z;
        posFinalDedo2 = posInicialDedo2 - 40;

    }
	
	// Update is called once per frame
	void Update () {
    
        if (dedo2.transform.eulerAngles.z > posFinalDedo2 && cierra == true)
        {
            Debug.Log("cerrando");
            dedo1.transform.eulerAngles -= new Vector3(0, 0, 0.5F);
            dedo2.transform.eulerAngles -= new Vector3(0, 0, 1f);
            dedo3.transform.eulerAngles -= new Vector3(0, 0, 1f);
            dedo4.transform.eulerAngles -= new Vector3(0, 0, 1f);
            dedo5.transform.eulerAngles -= new Vector3(0, 0, 0.5F);
        }
        else {
            cierra = false;
             }
        if (dedo2.transform.eulerAngles.z < posInicialDedo2 && cierra == false)
        {
            Debug.Log("abriendo");
            dedo1.transform.eulerAngles += new Vector3(0, 0, 0.5F);
            dedo2.transform.eulerAngles += new Vector3(0, 0, 1f);
            dedo3.transform.eulerAngles += new Vector3(0, 0, 1f);
            dedo4.transform.eulerAngles += new Vector3(0, 0, 1f);
            dedo5.transform.eulerAngles += new Vector3(0, 0, 0.5F);
        }
        else
        {
            cierra = true;
           // dedo1.transform.eulerAngles = new Vector3(dedo1.transform.eulerAngles.x, dedo1.transform.eulerAngles.x, posInicial);
        }
    }


}
