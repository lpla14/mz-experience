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
    public Animator animator;
    public Camera myCamera;
    private RectTransform canvasRectTransform;

    private GameObject bInteractuar;

    public bool dormido;

    void Start()
    {
        animator = GetComponent<Animator>();

        dormido = false;
        canvasRectTransform = canvas.GetComponent<RectTransform>();
        bInteractuar = GameObject.Find(Botones.ID_BOTON_INTERACTUAR);

        GetComponent<MenuInteracciones>().dormido = dormido;
        GetComponent<MenuInteracciones>().mostrarMenu = false;
        GetComponent<MenuInteracciones>().enabled = true;

        AddMenuButtonsEventTriggers();

    }

    // Update is called once per frame
    void Update()
    {
        canvas.transform.position = new Vector3(transform.position.x, transform.position.y+3, transform.position.z);
        canvas.transform.LookAt(myCamera.transform);

        if (bInteractuar != null && bInteractuar.activeSelf)
        {
            //canvasRectTransform.localPosition = new Vector3(firstPerson.transform.localPosition.x, firstPerson.transform.localPosition.y + 1, firstPerson.transform.localPosition.z - 3);

            if (Input.GetKeyDown(KeyCode.P)/*Input.GetKeyDown(Botones.BOTON_A)*/)
            {
                // se activa on pointer enter del animal y se desactiva on pointer exit
                //bInteractuar.SetActive(false);



                MostrarBotonInteractuar(false);

                GetComponent<MenuInteracciones>().dormido = dormido;
                GetComponent<MenuInteracciones>().mostrarMenu = true;
                GetComponent<MenuInteracciones>().enabled = true;

                GetComponent<MenuInteracciones>().MostrarMenu(true);

            }
        }


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

    private void OnPointerEnter_bInteractuar()
    {
        //bInteractuar.SetActive(false);
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
        var animatorEvtTrigger = animator.GetComponent<EventTrigger>();
        var bInteractuarEvtTrigger = bInteractuar.GetComponent<EventTrigger>();

        //AddEventTrigger(OnPointerEnter_animator,        EventTriggerType.PointerEnter, animatorEvtTrigger);
        AddEventTrigger(OnPointerExit_animator, EventTriggerType.PointerExit, animatorEvtTrigger);

        AddEventTrigger(OnPointerEnter_bInteractuar, EventTriggerType.PointerEnter, bInteractuarEvtTrigger);

    }

    public void MostrarBotonInteractuar(bool mostrar)
    {
        var altura = mostrar ? 0 : 8000;

        if (bInteractuar == null)
        {
            bInteractuar = GameObject.Find(Botones.ID_BOTON_INTERACTUAR);
        }

        bInteractuar.transform.localPosition = new Vector3(
            bInteractuar.transform.localPosition.x,
            altura,
            bInteractuar.transform.localPosition.z);
    }
}
