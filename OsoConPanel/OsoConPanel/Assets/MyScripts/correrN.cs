using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class correrN : MonoBehaviour {


    int posicionFinal = 10;
    int posicionInicial = 0;
    int anguloGiro = 270;
    int anguloInicial = 90;
    bool adelante = true;
    bool atras = false;
    bool girar = false;
    float anguloActual = 0;
    string orientacion = "";

    // Use this for initialization
    void Start()
    {
        posicionInicial = (int)transform.position.x;
        anguloActual = transform.eulerAngles.y;
        anguloInicial = (int)transform.eulerAngles.y;

        switch ((int)transform.eulerAngles.y)
        {
            case 0:
                posicionFinal = posicionInicial + 10;
                orientacion = "ESTE";
                break;
            case 180:
                posicionFinal = posicionInicial - 10;
                orientacion = "OESTE";
                break;
            case 270:
                posicionFinal = posicionInicial - 10;
                orientacion = "SUR";
                break;
            case 90:
                orientacion = "NORTE";
                posicionFinal = posicionInicial + 10;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < posicionFinal && adelante == true)
        {
            transform.position += new Vector3(0.1F, 0, 0);
            if (transform.position.x > posicionFinal)
            {
                adelante = false;
                girar = true;
            }

        }
        if (girar == true && adelante == false && atras == false)
        {
           
            anguloActual = anguloActual + 1f;
           
            if (anguloActual <= anguloGiro)
            {
               transform.eulerAngles = new Vector3(transform.eulerAngles.x, anguloActual , transform.eulerAngles.z);
            }
            if (transform.eulerAngles.y >= anguloGiro)
            {
                girar = false;
            }
        }

        if (adelante == false && girar == false && posicionInicial != transform.position.x)
        {
            transform.position -= new Vector3(0.1f, 0, 0);
            if (transform.position.x < posicionInicial)
            {
                adelante = false;
                girar = true;
                transform.position = new Vector3(posicionInicial, transform.position.y, transform.position.z);
                atras = true;
               
            }
        }

        if (adelante == false && atras == true && girar == true && anguloActual != anguloInicial)
        {
            anguloActual = anguloActual - 1f;
            if (anguloActual > anguloInicial && transform.eulerAngles.y != anguloInicial)
            {
                transform.eulerAngles = new Vector3(0, anguloActual, 0);
                Debug.Log(2);
            }
            if (anguloActual < 90)
            {
                anguloActual = 0;
                Debug.Log(transform.eulerAngles);
                transform.eulerAngles = new Vector3(0, 0, 0);
                girar = false;
            }

        }


    }
}
