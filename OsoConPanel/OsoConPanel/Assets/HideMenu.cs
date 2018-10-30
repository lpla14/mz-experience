using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideMenu : MonoBehaviour {

    // Update is called once per frame
    void Update () {

        var bInfo = GameObject.Find(Botones.ID_BOTON_INFO);
        if ((Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(Botones.BOTON_R2)) && !GetComponent<MenuInteracciones>().enabled)
        {
            var bComer = GameObject.Find(Botones.ID_BOTON_COMER);

            if (bComer != null && bComer.activeSelf)
            {
                GetComponent<MenuInteracciones>().enabled = true;
                GetComponent<MenuInteracciones>().MostrarMenu(false);
                GetComponent<MenuInteracciones>().enabled = false;
            }

            if (bInfo != null && bInfo.activeSelf)
            {
                GetComponent<MenuInteracciones>().enabled = true;
                GetComponent<MenuInteracciones>().OcultarPanelInfo("");
            }

        }
        else if (bInfo != null && bInfo.activeSelf && (Input.GetKeyDown(KeyCode.T) || Input.GetKeyDown(Botones.BOTON_R1)) && !GetComponent<MenuInteracciones>().enabled)
        {
            GetComponent<MenuInteracciones>().enabled = true;
            GetComponent<MenuInteracciones>().OcultarPanelInfo("");   
        }
    }
}
