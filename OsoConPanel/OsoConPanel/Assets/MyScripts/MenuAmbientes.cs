using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuAmbientes : MonoBehaviour {

    private const int ambienteDesierto = 0;
    private const int ambienteBosque   = 1;
    private const int ambienteArtico   = 2;

    private int imagenAmbiente = ambienteBosque;
    private int moverDerecha = 0;

    GameObject imgDesierto;
    GameObject imgBosque;
    GameObject imgArtico;

    // Use this for initialization
    void Start () {

        imgDesierto = GameObject.Find("ImgDesierto");
        imgBosque   = GameObject.Find("ImgBosque");
        imgArtico   = GameObject.Find("ImgArtico");

        imgDesierto.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
        imgBosque.gameObject.transform.localScale   = new Vector3(6f, 6f, 1f);
        imgArtico.gameObject.transform.localScale   = new Vector3(1f, 1f, 1f);

        imgDesierto.gameObject.transform.localPosition = new Vector3(-508f, 1f, 0);
        imgBosque.gameObject.transform.localPosition   = new Vector3(-26f,  1f, 0);
        imgArtico.gameObject.transform.localPosition   = new Vector3(470f,  1f, 0);
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(Botones.BOTON_R1) || Input.GetKeyDown(KeyCode.T))
        {
            var nuevaEscena = "";

            if (imagenAmbiente == ambienteDesierto)
            {
                nuevaEscena = "Desierto 3";
            }

            if (imagenAmbiente == ambienteBosque)
            {
                nuevaEscena = "Bosque 2";
            }

            if (imagenAmbiente == ambienteArtico)
            {
                nuevaEscena = "Artico 1";
            }

            var script = FindObjectOfType<ActualizarHistorial>();

            script.ultimoAmbiente = nuevaEscena;
            script.CambiarEscena(nuevaEscena);
        }
        
        var movimiento = Input.GetAxis("Vertical");

        if (movimiento != 0)
        {
            moverDerecha = movimiento > 0 ? 1 : -1 ;
        }
        else
        {
            imagenAmbiente += moverDerecha;

            if (imagenAmbiente > 2) imagenAmbiente = 0;

            if (imagenAmbiente < 0) imagenAmbiente = 2;

            Actualizar();

            moverDerecha = 0;
        }
       
    }

    private void Actualizar()
    {
        switch (imagenAmbiente)
        {
            case ambienteDesierto:
                imgDesierto.gameObject.transform.localScale = new Vector3(6f, 6f, 1f);
                imgBosque.gameObject.transform.localScale   = new Vector3(1f, 1f, 1f);
                imgArtico.gameObject.transform.localScale   = new Vector3(1f, 1f, 1f);

                imgDesierto.gameObject.transform.localPosition = new Vector3(-253f, 1f, 0);
                imgBosque.gameObject.transform.localPosition   = new Vector3(221f,  1f, 0);
                imgArtico.gameObject.transform.localPosition   = new Vector3(470f,  1f, 0);
                break;

            case ambienteBosque:
                imgDesierto.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
                imgBosque.gameObject.transform.localScale   = new Vector3(6f, 6f, 1f);
                imgArtico.gameObject.transform.localScale   = new Vector3(1f, 1f, 1f);

                imgDesierto.gameObject.transform.localPosition = new Vector3(-508f, 1f, 0);
                imgBosque.gameObject.transform.localPosition   = new Vector3(-26f,  1f, 0);
                imgArtico.gameObject.transform.localPosition   = new Vector3(470f,  1f, 0);
                break;

            case ambienteArtico:
                imgDesierto.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
                imgBosque.gameObject.transform.localScale   = new Vector3(1f, 1f, 1f);
                imgArtico.gameObject.transform.localScale   = new Vector3(6f, 6f, 1f);

                imgDesierto.gameObject.transform.localPosition = new Vector3(-508f, 1f, 0);
                imgBosque.gameObject.transform.localPosition   = new Vector3(-239f, 1f, 0);
                imgArtico.gameObject.transform.localPosition   = new Vector3(244f,  1f, 0);

                break;
        }

    }
}
