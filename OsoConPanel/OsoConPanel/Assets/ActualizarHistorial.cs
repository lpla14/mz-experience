using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActualizarHistorial : MonoBehaviour {
    
    public string ultimoAmbiente;
    public string escenaActual;
    public string escenaAnterior;

    private void Start()
    {
        var G = FindObjectOfType<ActualizarHistorial>();
        Object.DontDestroyOnLoad(G);
    }

    //llamar a esta funcion cuando se quiere cambiar escena
    public void CambiarEscena( string nuevaEscena )
    {
        if (!string.IsNullOrEmpty(nuevaEscena) && !nuevaEscena.Equals(""))
        {
            if (nuevaEscena.Equals("AMBIENTE"))
            {
                nuevaEscena = ultimoAmbiente;
            }

            escenaAnterior = escenaActual;

            //ver si los ambientes hay que permitirlos
            if (!escenaAnterior.Equals("MainMenuScene") && !escenaAnterior.Equals("MenuPausa")) escenaAnterior = "";

            escenaActual = nuevaEscena;
            //todo guardar ref ambiente

            SceneManager.LoadScene(nuevaEscena);
        }
    }
    
}
