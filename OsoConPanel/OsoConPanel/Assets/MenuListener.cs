using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuListener : MonoBehaviour {

    public string nuevaEscena;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(Botones.BOTON_R1) || Input.GetKeyDown(KeyCode.T))
        {
            FindObjectOfType<ActualizarHistorial>().CambiarEscena(nuevaEscena);
        }
    }

    public void SetNuevaEscena(string nueva)
    {
        nuevaEscena = nueva;
    }
}
