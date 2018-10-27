using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionesAnimales : MonoBehaviour
{
          
    private static Dictionary<string, Dictionary<int, string>> mapAnimaciones;

    public static bool init = false;
    //no poner 0 ya que por algun motivo la animacion no se dispara
    public static int ACCION_COMER           = 9;//0;
    public static int ACCION_ACARICIAR       = 1;
    public static int ACCION_FINGIR_MUERTE   = 2;
    public static int ACCION_DESPERTAR       = 3;
    public static int ACCION_DORMIR          = 4;
    public static int ACCION_CORRER          = 5;
    public static int ACCION_VER_INFO        = 6;
    public static int ACCION_DESELECCIONAR   = 7;
    public static int ACCION_VOLVER_VER_INFO = 8;

    public static string mostrandoInformacionAnimal = "";

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
        mapAnimaciones.Add("Low_Boar_v01", new Dictionary<int, string>
        {
            { ACCION_COMER,         "Arm_boar|eat_2"         },
            { ACCION_ACARICIAR,     "Arm_bear|idle_2"        },
            { ACCION_FINGIR_MUERTE, "Arm_boar|die"           },
            { ACCION_DESPERTAR,     "Arm_boar|up"            },
            { ACCION_DORMIR,        "Arm_boar|down"          },
            { ACCION_CORRER,        "Arm_bear|run"           }
        });
        mapAnimaciones.Add("Low_PolarBear_v01", new Dictionary<int, string>
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
        mapAnimaciones.Add("Low_Coyote_v01", new Dictionary<int, string>
        {
            { ACCION_COMER,         "Arm_fox|eat_1"       },
            { ACCION_ACARICIAR,     "Arm_fox|hate"        },
            { ACCION_FINGIR_MUERTE, "Arm_fox|dead"        },
            { ACCION_DESPERTAR,     "Arm_fox|sleep_end"   },
            { ACCION_DORMIR,        "Arm_fox|sleep_start" },
            { ACCION_CORRER,        "Arm_fox|run"         }
        });

        mapAnimaciones.Add("Low_Hare_v01", new Dictionary<int, string>
        {
            { ACCION_COMER,         "Arm_hare|eat"       },
            { ACCION_ACARICIAR,     "Arm_hare|fear"        },
            { ACCION_FINGIR_MUERTE, "Arm_hare|die"        },
            { ACCION_DESPERTAR,     "Arm_hare|sleep_end"   },
            { ACCION_DORMIR,        "Arm_hare|sleep_start" },
            { ACCION_CORRER,        "Arm_hare|run"         }
        });

        mapAnimaciones.Add("Low_Moose_bull_v01", new Dictionary<int, string>
        {
            { ACCION_COMER,         "Arm_Moose|eat_1"       },
            { ACCION_ACARICIAR,     "Arm_Moose|Hate"        },
            { ACCION_FINGIR_MUERTE, "Arm_Moose|die"        },
            { ACCION_DESPERTAR,     "Arm_Moose|sleep_end"   },
            { ACCION_DORMIR,        "Arm_Moose|sleep_start" },
            { ACCION_CORRER,        "Arm_Moose|run"         }
        });

        mapAnimaciones.Add("Low_Moose_cow_v01", new Dictionary<int, string>
        {
            { ACCION_COMER,         "Arm_Moose|eat_1"       },
            { ACCION_ACARICIAR,     "Arm_Moose|Hate"        },
            { ACCION_FINGIR_MUERTE, "Arm_Moose|die"        },
            { ACCION_DESPERTAR,     "Arm_Moose|sleep_end"   },
            { ACCION_DORMIR,        "Arm_Moose|sleep_start" },
            { ACCION_CORRER,        "Arm_Moose|run"         }
        });

        mapAnimaciones.Add("Low_doe_v01", new Dictionary<int, string>
        {
            { ACCION_COMER,         "eat_1"       },
            { ACCION_ACARICIAR,     "Hate"        },
            { ACCION_FINGIR_MUERTE, "die"        },
            { ACCION_DESPERTAR,     "sleep_end"   },
            { ACCION_DORMIR,        "sleep_start" },
            { ACCION_CORRER,        "run"         }
        });

        mapAnimaciones.Add("Low_Stag_v01", new Dictionary<int, string>
        {
            { ACCION_COMER,         "eat_1"       },
            { ACCION_ACARICIAR,     "Hate"        },
            { ACCION_FINGIR_MUERTE, "die"        },
            { ACCION_DESPERTAR,     "sleep_end"   },
            { ACCION_DORMIR,        "sleep_start" },
            { ACCION_CORRER,        "run"         }
        });
        //ver como reemplazar dormir y despertarse del caballo//done
        mapAnimaciones.Add("Horse", new Dictionary<int, string>
        {
            { ACCION_COMER,         "Horse_Eating"       },
            { ACCION_ACARICIAR,     "Horse_StepBack"        },
            { ACCION_FINGIR_MUERTE, "Horse_Dead"        },
            { ACCION_DESPERTAR,     "Horse_Idle"   },
            { ACCION_DORMIR,        "Horse_sleep" },
            { ACCION_CORRER,        "Horse_Run"         }
        });
        //ver como reemplazar dormir y despertarse del elefante//done but wake up is awful
        mapAnimaciones.Add("Elephant", new Dictionary<int, string>
        {
            { ACCION_COMER,         "Elephant_Water"       },
            { ACCION_ACARICIAR,     "Elephant_Attack"        },
            { ACCION_FINGIR_MUERTE, "Elephant_Death"        },
            { ACCION_DESPERTAR,     "Elephant_wakeup"   },
            { ACCION_DORMIR,        "Elephant_sleep" },
            { ACCION_CORRER,        "Elephant_Run"         }
        });
        //ver como reemplazar dormir, acariciar, y despertarse del giraffe//done but wake up is awful
        mapAnimaciones.Add("Giraffe", new Dictionary<int, string>
        {
            { ACCION_COMER,         "Giraffe_Eating"       },
            { ACCION_ACARICIAR,     "Giraffe_Attack"        },
            { ACCION_FINGIR_MUERTE, "Giraffe_Death"        },
            { ACCION_DESPERTAR,     "Giraffe_sleep_end"   },
            { ACCION_DORMIR,        "Giraffe_sleep_start" },
            { ACCION_CORRER,        "Giraffe_Run"         }
        });
        //lobo del 2 pack, tiene menos acciones, dormir y despertarse faltan
        mapAnimaciones.Add("Wolf", new Dictionary<int, string>
        {
            { ACCION_COMER,         "Wolf_Eat"       },
            { ACCION_ACARICIAR,     "Wolf_Howl"        },
            { ACCION_FINGIR_MUERTE, "Wolf_Death"        },
            { ACCION_DESPERTAR,     "Wolf_sleep_end"   },
            { ACCION_DORMIR,        "Wolf_sleep_start" },
            { ACCION_CORRER,        "Wolf_Run"         }
        });
        //ver como reemplazar dormir, y despertarse del penguin//done
        mapAnimaciones.Add("Penguin", new Dictionary<int, string>
        {
            { ACCION_COMER,         "Penguin_Shake"       },
            { ACCION_ACARICIAR,     "Penguin_Walk2"        },
            { ACCION_FINGIR_MUERTE, "Penguin_Death"        },
            { ACCION_DESPERTAR,     "Penguin_end"   },
            { ACCION_DORMIR,        "Penguin_start" },
            { ACCION_CORRER,        "Penguin_Run"         }
        });

        mapAnimaciones.Add("Spider", new Dictionary<int, string>
        {
            { ACCION_COMER,         "Spider_Attack"       },
            { ACCION_ACARICIAR,     "Spider_Scared"        },
            { ACCION_FINGIR_MUERTE, "Spider_Death 3"        },
            { ACCION_DESPERTAR,     "Spider_Death 1"   },
            { ACCION_DORMIR,        "Spider_Death 2" },
            { ACCION_CORRER,        "Spider_Walk"         }
        });
        //la serpiente no responde, borrar y volver a importar el asset//done
        mapAnimaciones.Add("Snake", new Dictionary<int, string>
        {
            { ACCION_COMER,         "Snake_Attack"       },
            { ACCION_ACARICIAR,     "Snake_Idle"        },
            { ACCION_FINGIR_MUERTE, "Snake_Death"        },
            { ACCION_DESPERTAR,     "Snake_wakeup"   },
            { ACCION_DORMIR,        "Snake_sleep" },
            { ACCION_CORRER,        "Snake_Slither"         }
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
