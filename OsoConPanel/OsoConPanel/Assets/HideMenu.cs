using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideMenu : MonoBehaviour {

    // Update is called once per frame
    void Update () {

        if ((Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(Botones.BOTON_R2)) && !GetComponent<MenuInteracciones>().enabled)
        {
            var bComer = GameObject.Find(Botones.ID_BOTON_COMER);

            if (bComer != null && bComer.activeSelf)
            {
                GetComponent<MenuInteracciones>().enabled = true;

                GetComponent<MenuInteracciones>().MostrarMenu(false);
                GetComponent<MenuInteracciones>().enabled = false;
            }

        }

    }
}
