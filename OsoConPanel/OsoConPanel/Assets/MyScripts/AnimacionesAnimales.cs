using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionesAnimales : MonoBehaviour
{
          
    public static Dictionary<string, string> mapAnimatorAnimal;

    public static bool init = false;

    void Start()
    {
        Init();
    }

    public static void Init()
    {
        if (init) return;

        mapAnimatorAnimal = new Dictionary<string, string>();
        
        // clave: nombre del asset
        // valor: string con el que empiezan los clips de animaciones del animal ej para el oso 
        // (Low_Bear_v01) "Arm_bear|sleep_start"
        // todo ver como se llaman las animaciones de los animales del nuevo paquete de assets. pasarlas a este formato
        mapAnimatorAnimal.Add("Low_Bear_v01", "Arm_bear");
        mapAnimatorAnimal.Add("Low_Fox_v01", "Arm_fox");

        //TO DO: AGREGAR TODOS LOS NOMBRES DE ANIMALES 

        init = true;
    }

    public static string GetNombreAnimacion(string animator)
    {
        Init();

        var nombre = "";
        if (mapAnimatorAnimal == null) return nombre;
        
        mapAnimatorAnimal.TryGetValue(animator, out nombre);

        return nombre;
    }

}
