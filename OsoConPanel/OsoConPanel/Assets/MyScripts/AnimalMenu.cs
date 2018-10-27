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
    public Camera myCamera;
    public Animator animator;

    private Transform animTransform;
    private GameObject bInteractuar;

    void Start()
    {
        bInteractuar = GameObject.Find(Botones.ID_BOTON_INTERACTUAR);

        GetComponent<MenuInteracciones>().mostrarMenu = false;
        GetComponent<MenuInteracciones>().animator = animator;
        GetComponent<MenuInteracciones>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<MenuInteracciones>().mostrarMenu) return;

        
        if (canvas != null && animTransform != null)
        {
            canvas.transform.position = new Vector3(animTransform.position.x + 1 , animTransform.position.y + 3, animTransform.position.z);

            if (myCamera != null)
            {
                canvas.transform.LookAt(myCamera.transform);
            }
        }
        
        if (bInteractuar != null && bInteractuar.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(Botones.BOTON_R2))
            {
                MostrarBotonInteractuar(false);

                GetComponent<AnimalMenu>().animator = null;
                GetComponent<AnimalMenu>().enabled = false;
            }

            if (Input.GetKeyDown(KeyCode.T) || Input.GetKeyDown(Botones.BOTON_R1))
            {
                // se activa on pointer enter del animal y se desactiva on pointer exit
                //bInteractuar.SetActive(false);
                
                MostrarBotonInteractuar(false);

                GetComponent<MenuInteracciones>().mostrarMenu = true;
                GetComponent<MenuInteracciones>().animator    = animator;
                GetComponent<MenuInteracciones>().enabled     = true;
                GetComponent<MenuInteracciones>().canvas      = canvas;
                GetComponent<MenuInteracciones>().myCamera    = myCamera;

                GetComponent<MenuInteracciones>().MostrarMenu(true);

                GetComponent<AnimalMenu>().animator = null;
                GetComponent<AnimalMenu>().enabled = false;

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
        yield return new WaitForSeconds(10);
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

    public void AddMenuButtonsEventTriggers()
    {
        if (animator != null)
        {
            var animatorEvtTrigger = animator.GetComponent<EventTrigger>();
            AddEventTrigger(OnPointerExit_animator, EventTriggerType.PointerExit, animatorEvtTrigger);
        }

        if (bInteractuar == null)
        {
            bInteractuar = GameObject.Find(Botones.ID_BOTON_INTERACTUAR);
        }

        if (bInteractuar != null)
        {
            var bInteractuarEvtTrigger = bInteractuar.GetComponent<EventTrigger>();
            AddEventTrigger(OnPointerEnter_bInteractuar, EventTriggerType.PointerEnter, bInteractuarEvtTrigger);
        }
    }

    public void Init(Animator animator)
    {
        var nombreAnimal = "";

        if (animator != null)
        {
            if (animator.GetComponent<Correr>() != null && animator.GetComponent<Correr>().enabled)
            {
                this.enabled = false;
            }

            this.animator = animator.GetComponent<Animator>();

            nombreAnimal = animator.name;

            this.animTransform = animator.transform;
            AddMenuButtonsEventTriggers();
        }

        GetComponent<MenuInteracciones>().OcultarPanelInfo(nombreAnimal);
        MostrarBotonInteractuar(true);
    }

    public void MostrarBotonInteractuar(bool mostrar)
    {
        if (GetComponent<MenuInteracciones>().mostrarMenu) return;

        var altura = mostrar ? 0 : 8000;

        if (bInteractuar == null)
        {
            bInteractuar = GameObject.Find(Botones.ID_BOTON_INTERACTUAR);
        }

        bInteractuar.SetActive(mostrar);
        
        /*
        bInteractuar.transform.localPosition = new Vector3(
            bInteractuar.transform.localPosition.x,
            altura,
            bInteractuar.transform.localPosition.z);*/
    }

}
