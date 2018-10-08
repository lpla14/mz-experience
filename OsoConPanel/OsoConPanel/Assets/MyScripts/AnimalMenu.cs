using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AnimalMenu : MonoBehaviour
{
    public GameObject canvas;
    public GameObject firstPerson;
    public Animator   animator;

    private RectTransform canvasRectTransform;
    private bool          menuVisible;

    private GameObject bInteractuar;
    private GameObject bComer;
    private GameObject bAcariciar;
    private GameObject bVerInformacion;
    private GameObject bFingirMuerte;
    private GameObject bDespertar;
    private GameObject bDormir;
    private GameObject bCorrer;
    private GameObject bDeseleccionar;

    private List<string> animalesAnimacionesFull = new List<string>(); // animales 1er compra. Tienen todas las animaciones
    private List<string> animalesAnimaciones = new List<string>();
    private GameObject   animal;

    private string botonSeleccionado;

    void Start()
    {
        animator          = GetComponent<Animator>();
        botonSeleccionado = "";

        menuVisible         = false;
        canvasRectTransform = canvas.GetComponent<RectTransform>();
        bInteractuar        = GameObject.Find(Botones.ID_BOTON_INTERACTUAR    );
        bComer              = GameObject.Find(Botones.ID_BOTON_COMER          );
        bAcariciar          = GameObject.Find(Botones.ID_BOTON_ACARICIAR      );
        bVerInformacion     = GameObject.Find(Botones.ID_BOTON_VER_INFORMACION);
        bFingirMuerte       = GameObject.Find(Botones.ID_BOTON_FINGIR_MUERTE  );
        bDespertar          = GameObject.Find(Botones.ID_BOTON_DESPERTAR      );
        bDormir             = GameObject.Find(Botones.ID_BOTON_DORMIR         );
        bCorrer             = GameObject.Find(Botones.ID_BOTON_CORRER         );
        bDeseleccionar      = GameObject.Find(Botones.ID_BOTON_DESELECCIONAR  );

        bDespertar.GetComponent<Button>().interactable = false;

        MostrarMenu(false);

        AddMenuButtonsEventTriggers();
    }

    // Update is called once per frame
    void Update()
    {
        //todo quitar esto y hacer que luego de que ese ejecuta la animacion correspondiente vuelva a idle el animal
        if (Input.GetKeyDown(Botones.BOTON_B))
        {
            ResetarParametros();
        }

        if (bInteractuar != null && bInteractuar.activeSelf)
        {
            canvasRectTransform.localPosition = new Vector3(firstPerson.transform.localPosition.x, firstPerson.transform.localPosition.y + 1, firstPerson.transform.localPosition.z - 3);

            if (Input.GetKeyDown(Botones.BOTON_A))
            {
                // se activa on pointer enter del animal y se desactiva on pointer exit
                bInteractuar.SetActive(false);
                MostrarMenu(true);
            }
        }

        if (!string.IsNullOrEmpty(botonSeleccionado) && Input.GetKeyDown(Botones.BOTON_R1))
        {
            MostrarMenu(false);

            if (botonSeleccionado.Equals(Botones.ID_BOTON_DORMIR))
            {
                bDormir.GetComponent<Button>().interactable = false;
                bComer.GetComponent<Button>().interactable = false;
                bAcariciar.GetComponent<Button>().interactable = false;
                bFingirMuerte.GetComponent<Button>().interactable = false;
                bCorrer.GetComponent<Button>().interactable = false;

                bDespertar.GetComponent<Button>().interactable = true;
            }
            else if (botonSeleccionado.Equals(Botones.ID_BOTON_DESPERTAR))
            {
                bDormir.GetComponent<Button>().interactable = true;
                bComer.GetComponent<Button>().interactable = true;
                bAcariciar.GetComponent<Button>().interactable = true;
                bFingirMuerte.GetComponent<Button>().interactable = true;
                bCorrer.GetComponent<Button>().interactable = true;

                bDespertar.GetComponent<Button>().interactable = false;
            }

            CambiarParametrosAnimator(botonSeleccionado);
        }
    }

    private void MostrarMenu(bool mostrarMenu)
    {  
        bComer         .SetActive(mostrarMenu);
        bDormir        .SetActive(mostrarMenu);
        bAcariciar     .SetActive(mostrarMenu);
        bVerInformacion.SetActive(mostrarMenu);
        bFingirMuerte  .SetActive(mostrarMenu);
        bDespertar     .SetActive(mostrarMenu);
        bCorrer        .SetActive(mostrarMenu);
        bDeseleccionar .SetActive(mostrarMenu);

        menuVisible = mostrarMenu;
    }

    private void CambiarParametrosAnimator(string boton)
    {
        var parametro = AnimacionesAnimales.GetParametro(boton);

        if (!string.IsNullOrEmpty(parametro))
        {
            animator.SetBool("idle", false);
            animator.SetBool(parametro, true);

            //todo
            //Thread.Sleep(5000);
            //ResetarParametros();
        }
    }

    private void ResetarParametros()
    {
        Debug.Log("reset");
        animator.SetBool("eat",   false);
        animator.SetBool("sleep", false);
        animator.SetBool("idle2", false);
        animator.SetBool("run",   false);
        animator.SetBool("dead",  false);
        animator.SetBool("idle",  true );
    }

    #region region pointer triggers
    private void OnPointerEnter_bInteractuar()
    {
        bInteractuar.gameObject.SetActive(true);
    }

    private void OnPointerExit_bInteractuar()
    {
        bInteractuar.gameObject.SetActive(false);
    }

    private void OnPointerEnter_bDormir()
    {
        botonSeleccionado = Botones.ID_BOTON_DORMIR;
    }

    private void OnPointerEnter_bComer()
    {
        botonSeleccionado = Botones.ID_BOTON_COMER;
    }

    private void OnPointerEnter_bAcariciar()
    {
        botonSeleccionado = Botones.ID_BOTON_ACARICIAR;
    }

    private void OnPointerEnter_bVerInformacion()
    {
        //TODO
        botonSeleccionado = Botones.ID_BOTON_VER_INFORMACION;
    }

    private void OnPointerEnter_bFingirMuerte()
    {
        botonSeleccionado = Botones.ID_BOTON_FINGIR_MUERTE;
    }

    private void OnPointerEnter_bDespertar()
    {
        botonSeleccionado = Botones.ID_BOTON_DESPERTAR;
    }

    private void OnPointerEnter_bCorrer()
    {
        botonSeleccionado = Botones.ID_BOTON_CORRER;
    }

    private void OnPointerEnter_bDeseleccionar()
    {
        botonSeleccionado = Botones.ID_BOTON_DESELECCIONAR;
    }
    

    private void OnPointerExit()
    {
        botonSeleccionado = "";
    }
    #endregion

    /*private void EjecutarAnimacion()
    {
        var nombreAnimacion = AnimacionesAnimales.GetNombreAnimacion(botonSeleccionado, animator.name);

        if (!string.IsNullOrEmpty(nombreAnimacion))
        {
            Debug.Log(nombreAnimacion);
            animator.Play(nombreAnimacion);
        }
    }*/

    private void AddEventTrigger(UnityAction action, EventTriggerType triggerType, EventTrigger eventTrigger)
    {
        // Create a new TriggerEvent and add a listener
        EventTrigger.TriggerEvent trigger = new EventTrigger.TriggerEvent();
        trigger.AddListener((eventData) => action()); // you can capture and pass the event data to the listener

        // Create and initialise EventTrigger.Entry using the created TriggerEvent
        EventTrigger.Entry entry = new EventTrigger.Entry() { callback = trigger, eventID = triggerType };

        // Add the EventTrigger.Entry to delegates list on the EventTrigger
        eventTrigger.triggers.Add(entry);
    }

    private void AddMenuButtonsEventTriggers()
    {
        var bInteractuarEvtTrigger    = bInteractuar.GetComponent<EventTrigger>();
        var bComerEvtTrigger          = bComer.GetComponent<EventTrigger>();
        var bAcariciarEvtTrigger      = bAcariciar.GetComponent<EventTrigger>();
        var bVerInformacionEvtTrigger = bVerInformacion.GetComponent<EventTrigger>();
        var bFingirMuerteEvtTrigger   = bFingirMuerte.GetComponent<EventTrigger>();
        var bDespertarEvtTrigger      = bDespertar.GetComponent<EventTrigger>();
        var bDormirEvtTrigger         = bDormir.GetComponent<EventTrigger>();
        var bCorrerEvtTrigger         = bCorrer.GetComponent<EventTrigger>();
        var bDeseleccionarEvtTrigger  = bDeseleccionar.GetComponent<EventTrigger>();

        //AddEventTrigger(OnPointerEnter_bInteractuar,    EventTriggerType.PointerEnter, bInteractuarEvtTrigger);
        //AddEventTrigger(OnPointerExit_bInteractuar,     EventTriggerType.PointerExit,  bInteractuarEvtTrigger);

        AddEventTrigger(OnPointerEnter_bDormir,         EventTriggerType.PointerEnter, bDormirEvtTrigger        );
        AddEventTrigger(OnPointerEnter_bComer,          EventTriggerType.PointerEnter, bComerEvtTrigger         );
        AddEventTrigger(OnPointerEnter_bAcariciar,      EventTriggerType.PointerEnter, bAcariciarEvtTrigger     );
        AddEventTrigger(OnPointerEnter_bVerInformacion, EventTriggerType.PointerEnter, bVerInformacionEvtTrigger);
        AddEventTrigger(OnPointerEnter_bFingirMuerte,   EventTriggerType.PointerEnter, bFingirMuerteEvtTrigger  );
        AddEventTrigger(OnPointerEnter_bDespertar,      EventTriggerType.PointerEnter, bDespertarEvtTrigger     );
        AddEventTrigger(OnPointerEnter_bCorrer,         EventTriggerType.PointerEnter, bCorrerEvtTrigger        );
        AddEventTrigger(OnPointerEnter_bDeseleccionar,  EventTriggerType.PointerEnter, bDeseleccionarEvtTrigger ); 
    }
}
