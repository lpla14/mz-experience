using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Correr : MonoBehaviour {

    int posicionFinal = 10;
    int posicionInicial = 0;
    int anguloGiro = 180;
    int anguloInicial = 0;
    bool adelante = true;
    bool atras = false;
    bool girar = false;
    float anguloActual = 0;
    string orientacion = "";
    Animator bearAnimator;
    // Use this for initialization
    void Start () {
        posicionInicial =(int) transform.position.z;
        
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
                orientacion = "SUR";
                break;
            case 90:
                orientacion = "NORTE";
                break;
        }

        bearAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (orientacion)
        {
            case "ESTE":
               
                if (transform.position.z < posicionFinal && adelante == true)
                {
                    bearAnimator.SetBool("run",true);
                    transform.position += new Vector3(0, 0, 0.1F);
                    if (transform.position.z >= posicionFinal)
                    {
                        adelante = false;
                        girar = true;
                    }
                }
                if (girar == true && adelante == false && atras == false)
                {
                    bearAnimator.SetBool("walk", true);
                    Debug.Log("gira");
                    anguloActual = anguloActual + 1f;
                    if (transform.eulerAngles.y < anguloGiro)
                    {
                        transform.eulerAngles = new Vector3(transform.eulerAngles.x, anguloActual, transform.eulerAngles.z);
                        if (transform.eulerAngles.y >= anguloGiro)
                        {
                            girar = false;
                        }
                    }
                }
                if (adelante == false && girar == false && posicionInicial != transform.position.z)
                {
                    bearAnimator.SetBool("walk", false);
                    transform.position += new Vector3(0, 0, -0.1F);
                    if (transform.position.z < posicionInicial)
                    {
                        adelante = false;
                        girar = true;
                        transform.position = new Vector3(transform.position.x, transform.position.y, posicionInicial);
                        atras = true;
                    }
                }
                if (adelante == false && atras == true && girar == true && anguloActual != 0)
                {
                    anguloActual = anguloActual + 1f;
                    bearAnimator.SetBool("walk",true);
                    if (transform.eulerAngles.y > anguloInicial && transform.eulerAngles.y != 0)
                    {
                        transform.eulerAngles = new Vector3(0, anguloActual, 0);

                    }
                    if (anguloActual > 360)
                    {
                        bearAnimator.SetBool("walk", false);
                        bearAnimator.SetBool("run", false);
                        GetComponent<Correr>().enabled = false;
                        anguloActual = 0;
                        transform.eulerAngles = new Vector3(0, 0, 0);
                        girar = false;
                    }

                }
                break;
                case "OESTE":
                 if (transform.position.z > posicionFinal && adelante == true)
                {
                    transform.position -= new Vector3(0, 0, 0.1F);
                    if (transform.position.z < posicionFinal)
                    {
                        Debug.Log("girar");
                        adelante = false;
                        girar = true;
                    }
                }
                if (girar == true && adelante == false && atras == false)
                {

                    anguloActual = anguloActual + 1f;
                    if (transform.eulerAngles.y > anguloGiro)
                    {
                        transform.eulerAngles = new Vector3(transform.eulerAngles.x, anguloActual, transform.eulerAngles.z);
                        if (transform.eulerAngles.y == anguloGiro)
                        {
                            girar = false;
                        }
                    }
                }
                if (adelante == false && girar == false && posicionInicial != transform.position.z)
                {
                    transform.position += new Vector3(0, 0, -0.1F);
                    if (transform.position.z < posicionInicial)
                    {
                        adelante = false;
                        girar = true;
                        transform.position = new Vector3(transform.position.x, transform.position.y, posicionInicial);
                        atras = true;
                    }
                }
                if (adelante == false && atras == true && girar == true && anguloActual != 0)
                {
                    anguloActual = anguloActual + 1f;

                    if (transform.eulerAngles.y > anguloInicial && transform.eulerAngles.y != 0)
                    {
                        transform.eulerAngles = new Vector3(0, anguloActual, 0);

                    }
                    if (anguloActual > 360)
                    {
                        anguloActual = 0;
                        Debug.Log(transform.eulerAngles);
                        transform.eulerAngles = new Vector3(0, 0, 0);
                        girar = false;
                    }

                }
              
                break;
        }
    }
}
