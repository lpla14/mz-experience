using UnityEngine;
using UnityEngine.UI;

public class AnimalMenu : MonoBehaviour
{
    public GameObject canvas;
    public GameObject firstPerson;

    private RectTransform canvasRectTransform;
    private bool menuVisible;

    private GameObject bInteractuar;
    private GameObject bComer;
    private GameObject bAcariciar;
    private GameObject bVerInformacion;
    private GameObject bFingirMuerte;
    private GameObject bDespertar;
    private GameObject bDormir;
    private GameObject bCorrer;
    private GameObject bDeseleccionar;

    void Start()
    {
        menuVisible = false;
        canvasRectTransform = canvas.GetComponent<RectTransform>();
        bInteractuar = GameObject.Find("bInteractuar");
        bComer = GameObject.Find("bComer");
        bAcariciar = GameObject.Find("bAcariciar");
        bVerInformacion = GameObject.Find("bVerInformacion");
        bFingirMuerte = GameObject.Find("bFingirMuerte");
        bDespertar = GameObject.Find("bDespertar");
        bDormir = GameObject.Find("bDormir");
        bCorrer = GameObject.Find("bCorrer");
        bDeseleccionar = GameObject.Find("bDeseleccionar");

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
        bInteractuar.SetActive(false);

        bComer.SetActive(mostrarMenu);
        bDormir.SetActive(mostrarMenu);
        bAcariciar.SetActive(mostrarMenu);
        bVerInformacion.SetActive(mostrarMenu);
        bFingirMuerte.SetActive(mostrarMenu);
        bDespertar.SetActive(mostrarMenu);
        bCorrer.SetActive(mostrarMenu);
        bDeseleccionar.SetActive(mostrarMenu);

        menuVisible = mostrarMenu;
    }

}
