using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionesAnimales : MonoBehaviour
{
    //animales 1er compra. Tienen todas las animaciones
    public static List<string> animalesAnimacionesFull; 
    public static List<string> animalesAnimaciones;
           
    public static Dictionary<string, string> mapBotonAnimacion;
    public static Dictionary<string, string> mapAnimatorAnimal;

    void Start()
    {
        animalesAnimacionesFull = new List<string>();
        animalesAnimaciones     = new List<string>();
        mapBotonAnimacion       = new Dictionary<string, string>();
        mapAnimatorAnimal       = new Dictionary<string, string>();

        animalesAnimacionesFull.Add("Low_Bear_v01");

        mapBotonAnimacion.Add(Botones.ID_BOTON_DORMIR,        "sleep_start");
        mapBotonAnimacion.Add(Botones.ID_BOTON_COMER,         "eat"        );
        mapBotonAnimacion.Add(Botones.ID_BOTON_ACARICIAR,     "idle_2"     );
        mapBotonAnimacion.Add(Botones.ID_BOTON_FINGIR_MUERTE, "dead_1"     );
        mapBotonAnimacion.Add(Botones.ID_BOTON_DESPERTAR,     "sleep_end"  );
        mapBotonAnimacion.Add(Botones.ID_BOTON_CORRER,        "run"        );

        mapAnimatorAnimal.Add("Low_Bear_v01", "Arm_bear");

        //TO DO: AGREGAR TODOS LOS NOMBRES DE ANIMALES 
    }

    public static string GetNombreAnimacion(string boton, string animator)
    {
        if (string.IsNullOrEmpty(boton) || string.IsNullOrEmpty(animator)) return null;

        if (mapBotonAnimacion.ContainsKey(boton) && mapAnimatorAnimal.ContainsKey(animator))
        {
            var nombreAnimacion = "";
            var nombreAnimal    = "";

            if (animalesAnimacionesFull.Contains(animator)  &&
                mapBotonAnimacion.TryGetValue(boton, out nombreAnimacion) &&
                mapAnimatorAnimal.TryGetValue(boton, out nombreAnimal))
            { 
                return nombreAnimal + '|' + nombreAnimacion;
            }

            //todo agregar logica para animales que no contienen todas las animaciones
        }

        return null;
    }
	
	
}
