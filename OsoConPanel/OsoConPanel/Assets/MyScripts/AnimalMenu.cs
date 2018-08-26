using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalMenu : MonoBehaviour
{
    public GameObject canvas;
    public GameObject firstPerson;
   
    RectTransform canvasRectTransform;
    private GameObject botonInteractuar;

    // Use this for initialization
    void Start ()
    {
        canvasRectTransform = canvas.GetComponent<RectTransform>();
        botonInteractuar = GameObject.Find("Button_Interactuar");
    }

    // Update is called once per frame
    void Update ()
    {
       
        if ( botonInteractuar != null && botonInteractuar.activeSelf )
        {
            canvasRectTransform.localPosition = new Vector3(firstPerson.transform.localPosition.x, firstPerson.transform.localPosition.y + 1, firstPerson.transform.localPosition.z - 3);
            
            //A
            if (Input.GetKeyDown(KeyCode.Joystick1Button3))
            {

            }

            //C
            if (Input.GetKeyDown(KeyCode.Joystick1Button2))
            {

            }
        }

       
    }

    public void MostrarMenu()
    {
        
        
    }

}
