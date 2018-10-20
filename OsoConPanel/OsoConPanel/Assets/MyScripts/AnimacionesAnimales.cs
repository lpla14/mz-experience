using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionesAnimales : MonoBehaviour
{
          
    private static Dictionary<string, Dictionary<int, string>> mapAnimaciones;

    public static bool init = false;

    public static int ACCION_COMER           = 0;
    public static int ACCION_ACARICIAR       = 1;
    public static int ACCION_FINGIR_MUERTE   = 2;
    public static int ACCION_DESPERTAR       = 3;
    public static int ACCION_DORMIR          = 4;
    public static int ACCION_CORRER          = 5;
    public static int ACCION_VER_INFO        = 6;
    public static int ACCION_DESELECCIONAR   = 7;
    public static int ACCION_VOLVER_VER_INFO = 8;

    void Start()
    {
        Init();
    }

    public static void Init()
    {
        if (init) return;

        mapAnimaciones    = new Dictionary<string, Dictionary<int, string>>();

        mapAnimaciones.Add("Low_Bear_v01", new Dictionary<int, string>
        {
            { ACCION_COMER,         "Arm_bear|eat"         },
            { ACCION_ACARICIAR,     "Arm_bear|idle_2"      },
            { ACCION_FINGIR_MUERTE, "Arm_bear|dead_1"      },
            { ACCION_DESPERTAR,     "Arm_bear|sleep_end"   },
            { ACCION_DORMIR,        "Arm_bear|sleep_start" },
            { ACCION_CORRER,        "Arm_bear|run"         }
        });

        mapAnimaciones.Add("Low_Fox_v01", new Dictionary<int, string>
        {
            { ACCION_COMER,         "Arm_fox|eat_1"       },
            { ACCION_ACARICIAR,     "Arm_fox|hate"        },
            { ACCION_FINGIR_MUERTE, "Arm_fox|dead"        },
            { ACCION_DESPERTAR,     "Arm_fox|sleep_end"   },
            { ACCION_DORMIR,        "Arm_fox|sleep_start" },
            { ACCION_CORRER,        "Arm_fox|run"         }
        });

        //TO DO: AGREGAR TODOS LOS OTROS ANIMALES!



        // clave: nombre del asset
        // valor: string con el que empiezan los clips de animaciones del animal ej para el oso 
        // (Low_Bear_v01) "Arm_bear|sleep_start"
        // todo ver como se llaman las animaciones de los animales del nuevo paquete de assets. pasarlas a este formato
        //mapAnimatorAnimal.Add("Low_Bear_v01", "Arm_bear");
        //mapAnimatorAnimal.Add("Low_Fox_v01", "Arm_fox");


        init = true;
    }

    public static string GetNombreAnimacion(string animator, int accion)
    {
        Init();

        var nombre = "";

        if (mapAnimaciones == null || animator == null) return nombre;

        // El parametro animator es el nombre del game object completo en unity. Ej "Low_Bear_v01", "Low_Bear_v01 (1)"
        // En las funciones de buscarInfo del animal y GetNombreAnimacion, hay que usar el nombre base (para los dos osos sería "Low_Bear_v01")
        // En esas funciones, hacer un split, usando el espacio como caracter separador

        var nombreBaseAnimator = animator.Split(' ')[0];
        Dictionary<int, string> dict;

        mapAnimaciones.TryGetValue(nombreBaseAnimator, out dict);

        if ( dict != null )
        {
            dict.TryGetValue(accion, out nombre);
        }

        return nombre;
    }

}
