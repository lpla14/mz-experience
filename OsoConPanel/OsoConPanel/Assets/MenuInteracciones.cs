using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
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
    public bool dormido;
    public Animator animator;

    public GameObject canvas;
    public Camera myCamera;
    public Transform animTransform;

    private string nombreAnimacion;
    private bool init = false;
    
    // Use this for initialization
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

        if (!string.IsNullOrEmpty(nombreAnimacion) && Input.GetKeyDown(KeyCode.K))
        {
            MostrarMenu(false);
            bVolver.GetComponent<Button>().interactable = true;
            bDormir.GetComponent<Button>().enabled = true;
            if (nombreAnimacion.Equals("deseleccionar"))
            {
                nombreAnimacion = "";
                GetComponent<MenuInteracciones>().animator = null;
                GetComponent<MenuInteracciones>().enabled = false;
            }
            if (nombreAnimacion.Equals("volver"))
            {
                bInfo.SetActive(false);
                bVolver.SetActive(false);
            }
            if (nombreAnimacion.Equals("verInfo"))
            {
                bInfo.SetActive(true);
                bVolver.SetActive(true);
                nombreAnimacion = "";
                string info = buscarInfo(AnimacionesAnimales.GetNombreAnimacion(animator.name));
                GameObject.Find("bInfo").GetComponentInChildren<Text>().text = info;
      

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

            if (animator != null)
            { 
                // Animaciones.Animales es el script que tiene los diccionarios (nombre de animaciones por animal, info de animales)
                var nombreAnimator = AnimacionesAnimales.GetNombreAnimacion(animator.name);
                
                if (!string.IsNullOrEmpty(nombreAnimator))
                {
                    animator.Play(nombreAnimator + "|" + nombreAnimacion);
                }
            }

            GetComponent<AnimalMenu>().dormido = dormido;
            GetComponent<MenuInteracciones>().animator = null;
            GetComponent<MenuInteracciones>().enabled = false;
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

    public void MostrarMenu(bool mostrarMenu)
    {
        if (!init) Init();

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
        bInfo.SetActive(false);
        bVolver.SetActive(false);

        this.mostrarMenu = mostrarMenu;
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
        nombreAnimacion = "verInfo";
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
        nombreAnimacion = dormido ? "" : "run";
    }

    private void OnPointerEnter_bDeseleccionar()
    {
        nombreAnimacion = "deseleccionar";
    }

    private void OnPointerEnter_bInfo()
    {
        nombreAnimacion = "";
    }
    private void OnPointerEnter_bVolver()
    {
        nombreAnimacion = "volver";
    }
    private void OnPointerExit_botones()
    {
        nombreAnimacion = "";
        //MostrarMenu(false);
        //GetComponent<MenuInteracciones>().enabled = false;

        //todo ver cuando desactivar este script
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
    public string buscarInfo(string animal) {
        string retorno="";
        switch (animal)
        {
            case "Arm_bear":
                retorno =  "\n" +
                           "  Especie : Canis lupus.\n" +
                           "  Habitad :  Norteamérica, Eurasia y el Oriente Medio.\n" +
                           "  Dieta : Carne de otros animales, como cerdos, ciervos, cabras, ovejas,depende del \n" +
                           "  habitad. Incluso pueden comer animales marinos como focas o pescados.\n" +
                           "  Caracteristicas : La altura varía entre los 60 y los 90 centímetros hasta el hombro,\n" +
                           "  y tienen un peso de entre 32 y 70 kilos.\n" +
                           "  Observaciones : Aunque está clasificada como una especie poco amenazada para su \n" +
                           "  extinción, en algunas regiones, incluyendo la parte continental de los \n" +
                           "  Estados Unidos de América, la especie está listada como en peligro o amenazada.\n" +
                           "  Los lobos son cazados en muchas áreas del mundo por la amenaza que representan para\n" +
                           "  el ganado, así como por deporte.\n" +
                           "  Habitos : Los lobos suelen organizarse en manadas siguiendo una estricta jerarquía \n" +
                           "  social. La manada la lideran el macho reproductor y la hembra reproductora. \n";
                break;
            case "Arm_fox":
                retorno="soy un zorro";
                break;
            case "Arm_boar":
                retorno = "soy un zorro";
                break;
            case "Arm_calf":
                retorno = "soy un zorro";
                break;
            case "Arm_doe":
                retorno = "soy un zorro";
                break;
            case "Arm_hare":
                retorno = "soy un zorro";
                break;
            case "Arm_Moose":
                retorno = "soy un zorro";
                break;
            case "Armature_wolf":
                retorno = "Especie : Canis lupus\n" +
                          "Habitad :  Norteamérica, Eurasia y el Oriente Medio\n " +
                          "Dieta : Carne de otros animales, como cerdos, ciervos, cabras, ovejas,depende del habitad.\n Incluso pueden comer animales marinos como focas o pescados." +
                          "Caracteristicas : La altura varía entre los 60 y los 90 centímetros hasta el hombro, y tienen un peso de entre 32 y 70 kilos\n" +
                          "Observaciones : Aunque está clasificada como una especie poco amenazada para su extinción, en algunas regiones, incluyendo la\n parte continental de los Estados Unidos de América, la especie está listada como en peligro o amenazada. Los lobos son cazados en muchas áreas del mundo por la amenaza que representan para el ganado,\n así como por deporte." +
                          "Habitos : Los lobos suelen organizarse en manadas siguiendo una estricta jerarquía social.\n La manada la lideran dos individuos que están en lo más alto de la jerarquía social: el macho reproductor y la hembra reproductora. ";
                break;
            default:
                retorno="nada";
                break;
        }

        return retorno;
    }
}
