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

    public static bool init = false;

    void Start()
    {
        Init();
    }

    public static void Init()
    {
        animalesAnimacionesFull = new List<string>();
        animalesAnimaciones = new List<string>();
        mapBotonAnimacion = new Dictionary<string, string>();
        mapAnimatorAnimal = new Dictionary<string, string>();

        animalesAnimacionesFull.Add("Low_Bear_v01");

        //mapBotonAnimacion.Add(Botones.ID_BOTON_DORMIR, "sleep_start");
        //mapBotonAnimacion.Add(Botones.ID_BOTON_COMER, "eat");
        //mapBotonAnimacion.Add(Botones.ID_BOTON_ACARICIAR, "idle_2");
        //mapBotonAnimacion.Add(Botones.ID_BOTON_FINGIR_MUERTE, "dead_1");
        //mapBotonAnimacion.Add(Botones.ID_BOTON_DESPERTAR, "sleep_end");
        //mapBotonAnimacion.Add(Botones.ID_BOTON_CORRER, "run");

        mapBotonAnimacion.Add(Botones.ID_BOTON_DORMIR, "sleep");
        mapBotonAnimacion.Add(Botones.ID_BOTON_COMER, "eat");
        mapBotonAnimacion.Add(Botones.ID_BOTON_ACARICIAR, "idle2");
        mapBotonAnimacion.Add(Botones.ID_BOTON_FINGIR_MUERTE, "dead");
        mapBotonAnimacion.Add(Botones.ID_BOTON_DESPERTAR, "sleep");
        mapBotonAnimacion.Add(Botones.ID_BOTON_CORRER, "run");

        mapAnimatorAnimal.Add("Low_Bear_v01", "Arm_bear");

        //TO DO: AGREGAR TODOS LOS NOMBRES DE ANIMALES 

        init = true;
    }

    /*public static string GetNombreAnimacion(string boton, string animator)
    {
        if (string.IsNullOrEmpty(boton) || string.IsNullOrEmpty(animator)) return null;

        if (!init)
        {
            Init();
            init = true;
            
        }
        var animatorName = "";

        foreach (var id in mapAnimatorAnimal.Keys)
        {
            if (animator.StartsWith("Low_Bear_v01"))
            {
                animatorName = id;
                break;
            }
        }

        if (mapBotonAnimacion.ContainsKey(boton) && mapAnimatorAnimal.ContainsKey(animatorName))
        {
            var nombreAnimacion = "";
            var nombreAnimal    = "";

            if (animalesAnimacionesFull.Contains(animatorName)  &&
                mapBotonAnimacion.TryGetValue(boton, out nombreAnimacion) &&
                mapAnimatorAnimal.TryGetValue(animatorName, out nombreAnimal))
            { 
                return nombreAnimal + '|' + nombreAnimacion;
            }

            //todo agregar logica para animales que no contienen todas las animaciones
        }

        return null;
    }*/

    public static string GetParametro(string botonID)
    {
        if (string.IsNullOrEmpty(botonID)) return null;

        if (!init)
        {
            Init();
        }
        if (mapBotonAnimacion.ContainsKey(botonID))
        {
            var parametro = "";

            if (mapBotonAnimacion.TryGetValue(botonID, out parametro))
            {
                return parametro;
            }

            //todo ver DESPERTAR
        }

        return null;
    }


}
