using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Correr : MonoBehaviour
{

    int posicionFinal;
    int posicionInicial = 0;
    int anguloGiro;
    int anguloInicial;
    int orientacion = -1;


    bool adelante;
    bool atras;
    bool girar;
    bool init = false;

    float anguloActual;
    
    Animator animator;
    
    private const int NORTE = 0;
    private const int SUR   = 1;
    private const int ESTE  = 2;
    private const int OESTE = 3;

    // Update is called once per frame
    void Update()
    {
        if (!init) Init();

        switch (orientacion)
        {
            case ESTE:

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

                        //para que la proxima vez que se ejecute el correr para este animal, se vuelvan a setear los valores de Init()
                        init = false;
                        GetComponent<Correr>().enabled = false;
                    }

                }
                break;

            case SUR:
                if (transform.position.x > posicionFinal && adelante == true)
                {
                    transform.position -= new Vector3(0.1F, 0, 0);
                    if (transform.position.x < posicionFinal)
                    {
                        adelante = false;
                        girar = true;
                    }

                }
                if (girar == true && adelante == false && atras == false)
                {
                    anguloActual = anguloActual + 1f;
                    if (anguloActual > 450)
                    {
                        anguloActual = 90;
                    }
                    if (anguloActual > anguloGiro)
                    {
                        if (anguloActual < 360)
                            transform.eulerAngles = new Vector3(transform.eulerAngles.x, anguloActual, transform.eulerAngles.z);
                        else
                        {
                            transform.eulerAngles = new Vector3(transform.eulerAngles.x, anguloActual - 360, transform.eulerAngles.z);
                        }
                        if (transform.eulerAngles.y == anguloGiro)
                        {
                            girar = false;
                        }
                    }
                }

                if (adelante == false && girar == false && posicionInicial != transform.position.z)
                {
                    transform.position += new Vector3(0.1f, 0, 0);
                    if (transform.position.x > posicionInicial)
                    {
                        girar = true;
                        transform.position = new Vector3(posicionInicial, transform.position.y, transform.position.z);
                        atras = true;
                        anguloActual = 90;
                    }
                }

                if (adelante == false && atras == true && girar == true && anguloActual != anguloInicial)
                {
                    anguloActual = anguloActual + 1f;
                    if (anguloActual < anguloInicial && transform.eulerAngles.y != anguloInicial)
                    {
                        transform.eulerAngles = new Vector3(0, anguloActual, 0);
                    }
                    if (anguloActual > 360)
                    {
                        anguloActual = 0;
                        transform.eulerAngles = new Vector3(0, 0, 0);
                        girar = false;

                        //para que la proxima vez que se ejecute el correr para este animal, se vuelvan a setear los valores de Init()
                        init = false;
                        GetComponent<Correr>().enabled = false;
                    }

                }
                break;
            case OESTE:
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

                        //para que la proxima vez que se ejecute el correr para este animal, se vuelvan a setear los valores de Init()
                        init = false;
                        GetComponent<Correr>().enabled = false;
                    }

                }

                break;

            case NORTE:
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
                        transform.eulerAngles = new Vector3(transform.eulerAngles.x, anguloActual, transform.eulerAngles.z);
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
                    }
                    if (anguloActual < 90)
                    {
                        anguloActual = 0;
                        
                        transform.eulerAngles = new Vector3(0, 0, 0);
                        girar = false;

                        //para que la proxima vez que se ejecute el correr para este animal, se vuelvan a setear los valores de Init()
                        init = false;
                        GetComponent<Correr>().enabled = false;
                    }

                }
                break;

        }

    }

    public void Init()
    {
        if (init) return;

        posicionFinal = 10;
        adelante = true;
        atras = false;
        girar = false;
        anguloActual = 0;
        orientacion = -1;

        posicionInicial = (int)transform.position.z;

        var angulo = GetAngulo(transform.eulerAngles.y);
        
        switch ( angulo )
        {
            case 0:
                posicionFinal = posicionInicial + 10;
                anguloGiro = 180;
                anguloInicial = 0;
                orientacion = ESTE;
                break;
            case 180:
                posicionFinal = posicionInicial - 10;
                anguloGiro = 0;
                anguloInicial = 0;
                
                anguloActual = angulo; //transform.eulerAngles.y;
                anguloInicial = angulo;

                orientacion = OESTE;
                break;
            case 270:
                orientacion = SUR;
                anguloGiro = 90;
                anguloInicial = 0;

                posicionInicial = (int)transform.position.x;
                anguloActual = angulo;//transform.eulerAngles.y;
                anguloInicial = angulo;
                break;
            case 90:
                orientacion = NORTE;
                anguloGiro = 270;
                anguloInicial = 90;

                posicionInicial = (int)transform.position.x;
                anguloActual = angulo;//transform.eulerAngles.y;

                break;
            default:
                this.enabled = false;
                break;
        }

        if (orientacion != -1)
        {
            animator = GetComponent<Animator>();
            init = true;
        }
    }

    public int GetAngulo( float eulerAnglesY)
    {
        var y = (int) eulerAnglesY;

        var delta = 10;

        if (y >= 0   - delta && y <= 0   + delta) return 0;

        if (y >= 90  - delta && y <= 90  + delta) return 90;

        if (y >= 180 - delta && y <= 180 + delta) return 180;

        if (y >= 270 - delta && y <= 270 + delta) return 270;

        if (y >= 360 - delta && y <= 360 + delta) return 0;

        return -1;
    }
}