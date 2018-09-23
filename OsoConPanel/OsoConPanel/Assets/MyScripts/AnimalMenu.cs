using System.Collections.Generic;
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

        MostrarMenu(false);

        AddMenuButtonsEventTriggers();
    }

    // Update is called once per frame
    void Update()
    {
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

        if (menuVisible && Input.GetKeyDown(Botones.BOTON_D))
        {
            MostrarMenu(false);
        }

        if (!string.IsNullOrEmpty(botonSeleccionado) && Input.GetKeyDown(Botones.BOTON_D))
        {
            MostrarMenu(false);
            EjecutarAnimacion();
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
        MostrarMenu(false);
    }
    

    private void OnPointerExit()
    {
        botonSeleccionado = "";
    }

    private void EjecutarAnimacion()
    {
        var nombreAnimacion = AnimacionesAnimales.GetNombreAnimacion(botonSeleccionado, animator.name);

        if (!string.IsNullOrEmpty(nombreAnimacion))
        {
            Debug.Log(nombreAnimacion);
            animator.Play(nombreAnimacion);
        }
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
        var bInteractuarEvtTrigger    = bInteractuar.GetComponent<EventTrigger>();
        var bComerEvtTrigger          = bComer.GetComponent<EventTrigger>();
        var bAcariciarEvtTrigger      = bAcariciar.GetComponent<EventTrigger>();
        var bVerInformacionEvtTrigger = bVerInformacion.GetComponent<EventTrigger>();
        var bFingirMuerteEvtTrigger   = bFingirMuerte.GetComponent<EventTrigger>();
        var bDespertarEvtTrigger      = bDespertar.GetComponent<EventTrigger>();
        var bDormirEvtTrigger         = bDormir.GetComponent<EventTrigger>();
        var bCorrerEvtTrigger         = bCorrer.GetComponent<EventTrigger>();
        var bDeseleccionarEvtTrigger  = bDeseleccionar.GetComponent<EventTrigger>();

        AddEventTrigger(OnPointerEnter_bDormir, EventTriggerType.PointerEnter, bDormirEvtTrigger);

        AddEventTrigger(OnPointerExit, EventTriggerType.PointerExit, bInteractuarEvtTrigger   );
        AddEventTrigger(OnPointerExit, EventTriggerType.PointerExit, bComerEvtTrigger         );
        AddEventTrigger(OnPointerExit, EventTriggerType.PointerExit, bAcariciarEvtTrigger     );
        AddEventTrigger(OnPointerExit, EventTriggerType.PointerExit, bVerInformacionEvtTrigger);
        AddEventTrigger(OnPointerExit, EventTriggerType.PointerExit, bFingirMuerteEvtTrigger  );
        AddEventTrigger(OnPointerExit, EventTriggerType.PointerExit, bDespertarEvtTrigger     );
        AddEventTrigger(OnPointerExit, EventTriggerType.PointerExit, bDormirEvtTrigger        );
        AddEventTrigger(OnPointerExit, EventTriggerType.PointerExit, bCorrerEvtTrigger        );
        AddEventTrigger(OnPointerExit, EventTriggerType.PointerExit, bDeseleccionarEvtTrigger );

        //todo setear los event trigger PointerEnter/PointerExit por script de bInteractuar  
    }
}
