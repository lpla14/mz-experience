using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Correr : MonoBehaviour
{

    int posicionFinal;
    int posicionInicial = 0;
    int anguloGiro;
    int anguloInicial;

    bool adelante;
    bool atras;
    bool girar;
    bool init = false;

    float anguloActual;

    string orientacion;

    Animator animator;

    // Update is called once per frame
    void Update()
    {
        if (!init) Init();

        switch (orientacion)
        {
            case "ESTE":

                if (transform.position.z < posicionFinal && adelante == true)
                {
                    animator.SetBool("run", true);
                    transform.position += new Vector3(0, 0, 0.1F);
                    if (transform.position.z >= posicionFinal)
                    {
                        adelante = false;
                        girar = true;
                    }
                }
                if (girar == true && adelante == false && atras == false)
                {
                    animator.SetBool("walk", true);

                    anguloActual = anguloActual + 1f;
                    if (transform.eulerAngles.y < anguloActual)
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
                    animator.SetBool("walk", false);
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
                    animator.SetBool("walk", true);
                    if (transform.eulerAngles.y > anguloInicial && transform.eulerAngles.y != 0)
                    {
                        transform.eulerAngles = new Vector3(0, anguloActual, 0);

                    }
                    if (anguloActual > 360)
                    {
                        animator.SetBool("walk", false);
                        animator.SetBool("run", false);

                        anguloActual = 0;
                        transform.eulerAngles = new Vector3(0, 0, 0);
                        girar = false;

                        init = false;
                        GetComponent<Correr>().enabled = false;
                    }

                }
                break;
            case "OESTE":
                if (transform.position.z > posicionFinal && adelante == true)
                {
                    transform.position -= new Vector3(0, 0, 0.1F);

                    if (transform.position.z < posicionFinal)
                    {
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
                        transform.eulerAngles = new Vector3(0, 0, 0);
                        girar = false;
                    }

                }

                break;
        }

    }

    public void Init()
    {
        if (init) return;

        posicionFinal = 10;
        anguloGiro = 180;
        anguloInicial = 0;
        adelante = true;
        atras = false;
        girar = false;
        anguloActual = 0;
        orientacion = "";

        posicionInicial = (int)transform.position.z;

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
            default:
                this.enabled = false;
                break;
        }

        animator = GetComponent<Animator>();

        init = true;
    }
}