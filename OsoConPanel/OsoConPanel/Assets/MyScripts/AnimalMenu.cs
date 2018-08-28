using UnityEngine;
using UnityEngine.UI;

public class AnimalMenu : MonoBehaviour
{
    public  GameObject    canvas;
    public  GameObject    firstPerson;
   
    private RectTransform canvasRectTransform;
    private bool          menuVisible;

    private GameObject    bInteractuar;
	private GameObject    bComer;
	private GameObject    bDormir;
	private GameObject    bAcariciar;
	
    void Start ()
    {
        menuVisible         = false;
        canvasRectTransform = canvas.GetComponent<RectTransform>();
		bInteractuar        = GameObject.Find("bInteractuar");
		bComer 				= GameObject.Find("bComer");
        bAcariciar          = GameObject.Find("bAcariciar");
        //bVerInformacion
        //bFingirMuerte
        //bDespertar
        bDormir             = GameObject.Find("bDormir");
        //bCorrer
        //bDeseleccionar
        // bDeseleccionar.GetComponent<Button>().onClick.AddListener(
        //                 delegate { MostrarMenuInteractuar(false); }
        //                 );

        bInteractuar.GetComponent<Button>().onClick.AddListener(
                delegate { MostrarMenuInteractuar(true); }
                );

        //todo ver de setear los event trigger PointerEnter/PointerExit por script       
    }

    // Update is called once per frame
    void Update ()
    {
        if ( bInteractuar != null && bInteractuar.activeSelf)
        {
			
			canvasRectTransform.localPosition = new Vector3(firstPerson.transform.localPosition.x, firstPerson.transform.localPosition.y + 1, firstPerson.transform.localPosition.z - 3); 
			
            //A
            if (Input.GetKeyDown(KeyCode.Joystick1Button3))
            {
                // se activa on pointer enter del animal y se desactiva on pointer exit
                bInteractuar.SetActive ( false );  
            }

        }
	
    }

    private void MostrarMenuInteractuar( bool mostrarMenu )
    {
        bInteractuar.SetActive ( !mostrarMenu );
		
		bComer.SetActive  ( mostrarMenu );
		bDormir.SetActive ( mostrarMenu );
		bAcariciar.SetActive( mostrarMenu );
     
		menuVisible = mostrarMenu;
    }

}
