using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalMenu : MonoBehaviour
{
    public GameObject canvas;
    public GameObject firstPerson;
    public string     nombreAnimal;
    public bool       todasLasAnimaciones;
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

    void Start()
    {
        animator = GetComponent<Animator>();

        if (todasLasAnimaciones)
        {
            animalesAnimacionesFull.Add(nombreAnimal);
        }
        else
        {
            animalesAnimaciones.Add(nombreAnimal);
        }

        menuVisible         = false;
        canvasRectTransform = canvas.GetComponent<RectTransform>();
        bInteractuar        = GameObject.Find("bInteractuar"   );
        bComer              = GameObject.Find("bComer"         );
        bAcariciar          = GameObject.Find("bAcariciar"     );
        bVerInformacion     = GameObject.Find("bVerInformacion");
        bFingirMuerte       = GameObject.Find("bFingirMuerte"  );
        bDespertar          = GameObject.Find("bDespertar"     );
        bDormir             = GameObject.Find("bDormir"        );
        bCorrer             = GameObject.Find("bCorrer"        );
        bDeseleccionar      = GameObject.Find("bDeseleccionar" );

        MostrarMenu(false);

        bDeseleccionar.GetComponent<Button>().onClick.AddListener(
                delegate { MostrarMenu(false); }
            );

        bInteractuar.GetComponent<Button>().onClick.AddListener(
                delegate { MostrarMenu(true); }
            );

        //todo ver de setear los event trigger PointerEnter/PointerExit por script       
    }

    // Update is called once per frame
    void Update()
    {
        if (bInteractuar != null && bInteractuar.activeSelf)
        {
            canvasRectTransform.localPosition = new Vector3(firstPerson.transform.localPosition.x, firstPerson.transform.localPosition.y + 1, firstPerson.transform.localPosition.z - 3);

            //A
            if (Input.GetKeyDown(KeyCode.Joystick1Button3))
            {
                // se activa on pointer enter del animal y se desactiva on pointer exit
                bInteractuar.SetActive(false);
            }
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

    private void MostrarBotonInteractuar(bool mostrar)
    {
        bInteractuar.SetActive(mostrar);
    }

    public void PermanecerQuieto()
    {
        if ( animalesAnimacionesFull.Contains ( nombreAnimal ) )
        {
            var nombreAnimacion = GetNombreAccion( nombreAnimal, "idle_1" );

            animator.Play(nombreAnimacion);
        }
    }

    private string GetNombreAccion( string nombreAnimal, string nombreAccion )
    {
        return nombreAnimal + '|' + nombreAccion;
    }

}
