using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AnimalMenu : MonoBehaviour
{
    public GameObject canvas;
    public GameObject firstPerson;
    public Animator   animator;
    public Camera myCamera;
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
    private string nombreAnimacion;
    private bool   dormido;

    void Start()
    {
        animator          = GetComponent<Animator>();
        nombreAnimacion   = "";

        dormido             = false;
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
    {    canvas.transform.position = new Vector3(transform.position.x, transform.position.y+3, transform.position.z);
        //canvas.transform.position = new Vector3(transform.position.x + 2, transform.position.y + 2, transform.position.z);
        canvas.transform.LookAt(myCamera.transform);
        if (bInteractuar != null && bInteractuar.activeSelf)
        {
           // canvasRectTransform.localPosition = new Vector3(firstPerson.transform.localPosition.x, firstPerson.transform.localPosition.y + 1, firstPerson.transform.localPosition.z - 3);

            if (Input.GetKeyDown(Botones.BOTON_A))
            {
                // se activa on pointer enter del animal y se desactiva on pointer exit
                //bInteractuar.SetActive(false);

                MostrarBotonInteractuar(false);
                MostrarMenu(true);
            }
        }

        if (!string.IsNullOrEmpty(nombreAnimacion) && Input.GetKeyDown(Botones.BOTON_R1))
        {
            MostrarMenu(false);

            if (nombreAnimacion.Equals("deseleccionar"))
            {
                nombreAnimacion = "";
                return;
            }

            if (nombreAnimacion.Equals("sleep_start"))
            {
                dormido = true;
                bDormir.GetComponent<Button>().interactable = false;
                bComer.GetComponent<Button>().interactable = false;
                bAcariciar.GetComponent<Button>().interactable = false;
                bFingirMuerte.GetComponent<Button>().interactable = false;
                bCorrer.GetComponent<Button>().interactable = false;

                bDespertar.GetComponent<Button>().interactable = true;
            }
            else if (nombreAnimacion.Equals("sleep_end"))
            {
                dormido = false;
                bDormir.GetComponent<Button>().interactable = true;
                bComer.GetComponent<Button>().interactable = true;
                bAcariciar.GetComponent<Button>().interactable = true;
                bFingirMuerte.GetComponent<Button>().interactable = true;
                bCorrer.GetComponent<Button>().interactable = true;

                bDespertar.GetComponent<Button>().interactable = false;
            }

            // Animaciones.Animales es el script que tiene los diccionarios (nombre de animaciones por animal, info de animales)
            var nombreAnimator = AnimacionesAnimales.GetNombreAnimacion(animator.name);

            if ( !string.IsNullOrEmpty( nombreAnimator ) )
            {
                animator.Play( nombreAnimator + "|" + nombreAnimacion);
            }
            
        }
    }

    private void MostrarMenu(bool mostrarMenu)
    {
        
        var altura = 0;

        if (mostrarMenu)
        {
            if (bComer.transform.localPosition.y != 90)
            {
                altura = -8000;
            }
        }
        else
        {
            if (bComer.transform.localPosition.y == 90)
            {
                altura = 8000;
            }
        }

        bComer.transform.localPosition = new Vector3( 
            bComer.transform.localPosition.x, 
            bComer.transform.localPosition.y + altura,
            bComer.transform.localPosition.z );

        bDormir.transform.localPosition = new Vector3(
            bDormir.transform.localPosition.x,
            bDormir.transform.localPosition.y + altura,
            bDormir.transform.localPosition.z);

        bAcariciar.transform.localPosition = new Vector3(
            bAcariciar.transform.localPosition.x,
            bAcariciar.transform.localPosition.y + altura,
            bAcariciar.transform.localPosition.z);

        bVerInformacion.transform.localPosition = new Vector3(
           bVerInformacion.transform.localPosition.x,
           bVerInformacion.transform.localPosition.y + altura,
           bVerInformacion.transform.localPosition.z);


        bFingirMuerte.transform.localPosition = new Vector3(
           bFingirMuerte.transform.localPosition.x,
           bFingirMuerte.transform.localPosition.y + altura,
           bFingirMuerte.transform.localPosition.z);

        bDespertar.transform.localPosition = new Vector3(
            bDespertar.transform.localPosition.x,
            bDespertar.transform.localPosition.y + altura,
            bDespertar.transform.localPosition.z);

        bCorrer.transform.localPosition = new Vector3(
            bCorrer.transform.localPosition.x,
            bCorrer.transform.localPosition.y + altura,
            bCorrer.transform.localPosition.z);

        bDeseleccionar.transform.localPosition = new Vector3(
            bDeseleccionar.transform.localPosition.x,
            bDeseleccionar.transform.localPosition.y + altura,
            bDeseleccionar.transform.localPosition.z);

        menuVisible = mostrarMenu;
    }

    #region region pointer triggers
    private void OnPointerEnter_animator()
    {
        //bInteractuar.SetActive(true);

        MostrarBotonInteractuar(true);
    }

    private void OnPointerExit_animator()
    {
        //bInteractuar.SetActive(false);
        StartCoroutine(OcultarBotonInteractuar());
    }

    private void OnPointerExit_botones()
    {
        nombreAnimacion = "";
    }

    private void OnPointerEnter_bInteractuar()
    {
        nombreAnimacion = "";
        //bInteractuar.SetActive(false);

        MostrarBotonInteractuar(false);
        MostrarMenu(true);
    }

    private void OnPointerEnter_bDormir()
    {
        nombreAnimacion = dormido ? "" : "sleep_start";
    }

    private void OnPointerEnter_bComer()
    {
        nombreAnimacion = dormido ? "" : "eat";
    }

    private void OnPointerEnter_bAcariciar()
    {
        nombreAnimacion = dormido ? "" : "idle_2"; //ver si vamos a poder acariciar solo cuando esta despierto o no
    }

    private void OnPointerEnter_bVerInformacion()
    {
        nombreAnimacion = "";
    }

    private void OnPointerEnter_bFingirMuerte()
    {
        nombreAnimacion = dormido ? "" : "dead_1";
    }

    private void OnPointerEnter_bDespertar()
    {
        nombreAnimacion = dormido ? "sleep_end" : "";
    }

    private void OnPointerEnter_bCorrer()
    {
        nombreAnimacion   = dormido ? "" : "run";
    }

    private void OnPointerEnter_bDeseleccionar()
    {
        nombreAnimacion = "";
    }
    
    #endregion

    IEnumerator OcultarBotonInteractuar()
    {
        yield return new WaitForSeconds(5);
        //bInteractuar.SetActive(false);
        MostrarBotonInteractuar(false);

    }

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
        var animatorEvtTrigger        = animator.GetComponent<EventTrigger>();
        var bInteractuarEvtTrigger    = bInteractuar.GetComponent<EventTrigger>();
        var bComerEvtTrigger          = bComer.GetComponent<EventTrigger>();
        var bAcariciarEvtTrigger      = bAcariciar.GetComponent<EventTrigger>();
        var bVerInformacionEvtTrigger = bVerInformacion.GetComponent<EventTrigger>();
        var bFingirMuerteEvtTrigger   = bFingirMuerte.GetComponent<EventTrigger>();
        var bDespertarEvtTrigger      = bDespertar.GetComponent<EventTrigger>();
        var bDormirEvtTrigger         = bDormir.GetComponent<EventTrigger>();
        var bCorrerEvtTrigger         = bCorrer.GetComponent<EventTrigger>();
        var bDeseleccionarEvtTrigger  = bDeseleccionar.GetComponent<EventTrigger>();

        AddEventTrigger(OnPointerEnter_animator,        EventTriggerType.PointerEnter, animatorEvtTrigger);
        AddEventTrigger(OnPointerExit_animator,         EventTriggerType.PointerExit,  animatorEvtTrigger);

        AddEventTrigger(OnPointerEnter_bInteractuar,    EventTriggerType.PointerEnter, bInteractuarEvtTrigger   );
        AddEventTrigger(OnPointerEnter_bDormir,         EventTriggerType.PointerEnter, bDormirEvtTrigger        );
        AddEventTrigger(OnPointerEnter_bComer,          EventTriggerType.PointerEnter, bComerEvtTrigger         );
        AddEventTrigger(OnPointerEnter_bAcariciar,      EventTriggerType.PointerEnter, bAcariciarEvtTrigger     );
        AddEventTrigger(OnPointerEnter_bVerInformacion, EventTriggerType.PointerEnter, bVerInformacionEvtTrigger);
        AddEventTrigger(OnPointerEnter_bFingirMuerte,   EventTriggerType.PointerEnter, bFingirMuerteEvtTrigger  );
        AddEventTrigger(OnPointerEnter_bDespertar,      EventTriggerType.PointerEnter, bDespertarEvtTrigger     );
        AddEventTrigger(OnPointerEnter_bCorrer,         EventTriggerType.PointerEnter, bCorrerEvtTrigger        );
        AddEventTrigger(OnPointerEnter_bDeseleccionar,  EventTriggerType.PointerEnter, bDeseleccionarEvtTrigger );

        AddEventTrigger(OnPointerExit_botones,          EventTriggerType.PointerExit, bDormirEvtTrigger         );
        AddEventTrigger(OnPointerExit_botones,          EventTriggerType.PointerExit, bComerEvtTrigger          );
        AddEventTrigger(OnPointerExit_botones,          EventTriggerType.PointerExit, bAcariciarEvtTrigger      );
        AddEventTrigger(OnPointerExit_botones,          EventTriggerType.PointerExit, bVerInformacionEvtTrigger );
        AddEventTrigger(OnPointerExit_botones,          EventTriggerType.PointerExit, bFingirMuerteEvtTrigger   );
        AddEventTrigger(OnPointerExit_botones,          EventTriggerType.PointerExit, bDespertarEvtTrigger      );
        AddEventTrigger(OnPointerExit_botones,          EventTriggerType.PointerExit, bCorrerEvtTrigger         );
        AddEventTrigger(OnPointerExit_botones,          EventTriggerType.PointerExit, bDeseleccionarEvtTrigger  );
    }

    public void exitMenu()
    {
        MostrarBotonInteractuar(false);
        //bInteractuar.SetActive(false);
        MostrarMenu(false);
        nombreAnimacion = "";
    }

    private void MostrarBotonInteractuar(bool mostrar)
    {
        var altura = mostrar ? 0 : 8000;

        bInteractuar.transform.localPosition = new Vector3(
            bInteractuar.transform.localPosition.x,
            altura,
            bInteractuar.transform.localPosition.z);
    }    
}
