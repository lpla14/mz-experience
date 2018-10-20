﻿using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuInteracciones : MonoBehaviour {

    private GameObject bInteractuar;
    private GameObject bComer;
    private GameObject bAcariciar;
    private GameObject bVerInformacion;
    private GameObject bFingirMuerte;
    private GameObject bDespertar;
    private GameObject bDormir;
    private GameObject bCorrer;
    private GameObject bDeseleccionar;
    private GameObject bInfo;
    private GameObject bVolver;
    
    public bool mostrarMenu = false;
    
    public Animator animator;

    public GameObject canvas;
    public Camera myCamera;
    public Transform animTransform;

    private string interaccion;
    private bool init = false;

    private string idAnimal;

    
    void Start () {
        if (!init) Init();
    }

    // Update is called once per frame
    void Update () {

        if (canvas != null && animTransform != null)
        {
            canvas.transform.position = new Vector3(animTransform.position.x, animTransform.position.y + 3, animTransform.position.z);

            if (myCamera != null)
            {
                canvas.transform.LookAt(myCamera.transform);
            }
        }

        if (!string.IsNullOrEmpty(interaccion) && Input.GetKeyDown(KeyCode.K))
        {
            MostrarMenu(false);
            bVolver.GetComponent<Button>().interactable = true;
            bDormir.GetComponent<Button>().enabled = true;

            if (interaccion.Equals("deseleccionar"))
            {
                interaccion = "";
                GetComponent<MenuInteracciones>().animator = null;
                GetComponent<MenuInteracciones>().enabled = false;
            }
            if (interaccion.Equals("volver"))
            {
                bInfo.SetActive(false);
                bVolver.SetActive(false);

                MostrarMenu(true);
                interaccion = "";
            }
            else if (interaccion.Equals("verInfo"))
            {
                 bInfo.SetActive(true);
                 bVolver.SetActive(true);
                 interaccion = "";
                 string info = BuscarInfo(AnimacionesAnimales.GetNombreAnimacion(animator.name));
                 GameObject.Find("bInfo").GetComponentInChildren<Text>().text = info;
            }
            else
            {
                if (interaccion.Equals("sleep_start"))
                {
                    GetComponent<EstadoAnimales>().SetDormido(idAnimal, true);
                }
                else if (interaccion.Equals("sleep_end"))
                {
                    GetComponent<EstadoAnimales>().SetDormido(idAnimal, false);
                }

                if ( animator != null && !string.IsNullOrEmpty( interaccion ) )
                {
                    // Animaciones.Animales es el script que tiene los diccionarios (nombre de animaciones por animal, info de animales)
                    var nombreAnimacion = AnimacionesAnimales.GetNombreAnimacion(animator.name, interaccion);

                    if (!string.IsNullOrEmpty(nombreAnimacion))
                    {
                        animator.Play(nombreAnimacion + "|" + interaccion);
                    }
                }

                GetComponent<MenuInteracciones>().animator = null;
                GetComponent<MenuInteracciones>().enabled = false;
                interaccion = "";
            }
        }
    }

    public void Init()
    {
        bInteractuar = GameObject.Find(Botones.ID_BOTON_INTERACTUAR);
        bComer = GameObject.Find(Botones.ID_BOTON_COMER);
        bAcariciar = GameObject.Find(Botones.ID_BOTON_ACARICIAR);
        bVerInformacion = GameObject.Find(Botones.ID_BOTON_VER_INFORMACION);
        bFingirMuerte = GameObject.Find(Botones.ID_BOTON_FINGIR_MUERTE);
        bDespertar = GameObject.Find(Botones.ID_BOTON_DESPERTAR);
        bDormir = GameObject.Find(Botones.ID_BOTON_DORMIR);
        bCorrer = GameObject.Find(Botones.ID_BOTON_CORRER);
        bDeseleccionar = GameObject.Find(Botones.ID_BOTON_DESELECCIONAR);
        bInfo = GameObject.Find(Botones.ID_BOTON_INFO);
        bVolver = GameObject.Find(Botones.ID_BOTON_VOLVER);

        bDespertar.GetComponent<Button>().interactable = false;
        
        AddMenuButtonsEventTriggers();

        init = true;

        MostrarMenu(mostrarMenu);
    }

    public void SetAnimator(Animator animator)
    {
        this.animator = animator.GetComponent<Animator>();
        this.animTransform = animator.transform;
    }

    public void SetIdAnimal(string id)
    {
        idAnimal = id;
    }

    public void MostrarMenu(bool mostrarMenu)
    {
        if (!init) Init();

        //var altura = 0;

        //if (mostrarMenu)
        //{
        //    if (bComer.transform.localPosition.y != 90)
        //    {
        //        altura = -8000;
        //    }
        //}
        //else
        //{
        //    if (bComer.transform.localPosition.y == 90)
        //    {
        //        altura = 8000;
        //    }
        //}

        if (mostrarMenu)
        {
            var animalDormido = GetComponent<EstadoAnimales>().IsDormido(idAnimal);

            bDormir.GetComponent<Button>().interactable       = !animalDormido;
            bComer.GetComponent<Button>().interactable        = !animalDormido;
            bAcariciar.GetComponent<Button>().interactable    = !animalDormido;
            bFingirMuerte.GetComponent<Button>().interactable = !animalDormido;
            bCorrer.GetComponent<Button>().interactable       = !animalDormido;

            bDespertar.GetComponent<Button>().interactable    = animalDormido;
        }

        bComer.SetActive(mostrarMenu);
        bDormir.SetActive(mostrarMenu);
        bAcariciar.SetActive(mostrarMenu);
        bVerInformacion.SetActive(mostrarMenu);        
        bFingirMuerte.SetActive(mostrarMenu);
        bDespertar.SetActive(mostrarMenu);
        bCorrer.SetActive(mostrarMenu);
        bDeseleccionar.SetActive(mostrarMenu);
        bInfo.SetActive(mostrarMenu);
        bVolver.SetActive(mostrarMenu);


        bInfo.SetActive(false);
        bVolver.SetActive(false);

        this.mostrarMenu = mostrarMenu;

        /*
        bComer.transform.localPosition = new Vector3(
            bComer.transform.localPosition.x,
            bComer.transform.localPosition.y + altura,
            bComer.transform.localPosition.z);

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
           bVerInformacion.transform.localPosition.y,
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

        bInfo.transform.localPosition = new Vector3(
             bInfo.transform.localPosition.x,
            bInfo.transform.localPosition.y ,
             bInfo.transform.localPosition.z);

        bVolver.transform.localPosition = new Vector3(
            bVolver.transform.localPosition.x,
            bVolver.transform.localPosition.y ,
            bVolver.transform.localPosition.z);
            */
    }


    #region pointer enter actions
    private void OnPointerEnter_bDormir()
    {
        interaccion = GetComponent<EstadoAnimales>().IsDormido(idAnimal) ? "" : "sleep_start";
    }

    private void OnPointerEnter_bComer()
    {
        interaccion = GetComponent<EstadoAnimales>().IsDormido(idAnimal) ? "" : "eat";
    }

    private void OnPointerEnter_bAcariciar()
    {
        interaccion = GetComponent<EstadoAnimales>().IsDormido(idAnimal) ? "" : "idle_2"; //ver si vamos a poder acariciar solo cuando esta despierto o no
    }

    private void OnPointerEnter_bVerInformacion()
    {
        interaccion = "verInfo";
    }

    private void OnPointerEnter_bFingirMuerte()
    {
        interaccion = GetComponent<EstadoAnimales>().IsDormido(idAnimal) ? "" : "dead_1";
    }

    private void OnPointerEnter_bDespertar()
    {
        interaccion = GetComponent<EstadoAnimales>().IsDormido(idAnimal) ? "sleep_end" : "";
    }

    private void OnPointerEnter_bCorrer()
    {
        interaccion = GetComponent<EstadoAnimales>().IsDormido(idAnimal) ? "" : "run";
    }

    private void OnPointerEnter_bDeseleccionar()
    {
        interaccion = "deseleccionar";
    }

    private void OnPointerEnter_bInfo()
    {
        interaccion = "";
    }
    private void OnPointerEnter_bVolver()
    {
        interaccion = "volver";
    }
    private void OnPointerExit_botones()
    {
        interaccion = "";
        //MostrarMenu(false);
        //GetComponent<MenuInteracciones>().enabled = false;

        //todo ver cuando desactivar este script
    }

    #endregion pointer enter actions

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
        var bComerEvtTrigger = bComer.GetComponent<EventTrigger>();
        var bAcariciarEvtTrigger = bAcariciar.GetComponent<EventTrigger>();
        var bVerInformacionEvtTrigger = bVerInformacion.GetComponent<EventTrigger>();
        var bFingirMuerteEvtTrigger = bFingirMuerte.GetComponent<EventTrigger>();
        var bDespertarEvtTrigger = bDespertar.GetComponent<EventTrigger>();
        var bDormirEvtTrigger = bDormir.GetComponent<EventTrigger>();
        var bCorrerEvtTrigger = bCorrer.GetComponent<EventTrigger>();
        var bDeseleccionarEvtTrigger = bDeseleccionar.GetComponent<EventTrigger>();
        var bInfoEvtTrigger = bInfo.GetComponent<EventTrigger>();
        var bVolverEvtTrigger = bVolver.GetComponent<EventTrigger>();

        AddEventTrigger(OnPointerEnter_bDormir, EventTriggerType.PointerEnter, bDormirEvtTrigger);
        AddEventTrigger(OnPointerEnter_bComer, EventTriggerType.PointerEnter, bComerEvtTrigger);
        AddEventTrigger(OnPointerEnter_bAcariciar, EventTriggerType.PointerEnter, bAcariciarEvtTrigger);
        AddEventTrigger(OnPointerEnter_bVerInformacion, EventTriggerType.PointerEnter, bVerInformacionEvtTrigger);
        AddEventTrigger(OnPointerEnter_bFingirMuerte, EventTriggerType.PointerEnter, bFingirMuerteEvtTrigger);
        AddEventTrigger(OnPointerEnter_bDespertar, EventTriggerType.PointerEnter, bDespertarEvtTrigger);
        AddEventTrigger(OnPointerEnter_bCorrer, EventTriggerType.PointerEnter, bCorrerEvtTrigger);
        AddEventTrigger(OnPointerEnter_bDeseleccionar, EventTriggerType.PointerEnter, bDeseleccionarEvtTrigger);
        AddEventTrigger(OnPointerEnter_bInfo, EventTriggerType.PointerEnter, bInfoEvtTrigger);
        AddEventTrigger(OnPointerEnter_bVolver, EventTriggerType.PointerEnter, bVolverEvtTrigger);



        AddEventTrigger(OnPointerExit_botones, EventTriggerType.PointerExit, bDormirEvtTrigger);
        AddEventTrigger(OnPointerExit_botones, EventTriggerType.PointerExit, bComerEvtTrigger);
        AddEventTrigger(OnPointerExit_botones, EventTriggerType.PointerExit, bAcariciarEvtTrigger);
        AddEventTrigger(OnPointerExit_botones, EventTriggerType.PointerExit, bVerInformacionEvtTrigger);
        AddEventTrigger(OnPointerExit_botones, EventTriggerType.PointerExit, bFingirMuerteEvtTrigger);
        AddEventTrigger(OnPointerExit_botones, EventTriggerType.PointerExit, bDespertarEvtTrigger);
        AddEventTrigger(OnPointerExit_botones, EventTriggerType.PointerExit, bCorrerEvtTrigger);
        AddEventTrigger(OnPointerExit_botones, EventTriggerType.PointerExit, bDeseleccionarEvtTrigger);
        AddEventTrigger(OnPointerExit_botones, EventTriggerType.PointerExit, bInfoEvtTrigger);
        AddEventTrigger(OnPointerExit_botones, EventTriggerType.PointerExit, bVolverEvtTrigger);
    }

    public string BuscarInfo(string animal) {
        string retorno="";
        switch (animal)
        {
            case "Arm_bear":
                retorno = "soy un osito";
                break;
            case "Arm_fox":
                retorno="soy un zorro";
                break;
            default:
                retorno="nada";
                break;
        }

        return retorno;
    }
}