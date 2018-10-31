using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoAnimales : MonoBehaviour {

    private Dictionary<string, bool> mapAnimalesDormidos = new Dictionary<string, bool>();

    private void Start()
    {
        // set estado inicial de animales

        //artico
        SetEstadoInicial("Low_PolarBear_v01 (1)", AnimacionesAnimales.ACCION_DORMIR);
        SetEstadoInicial("Low_Moose_bull_v01 (2)", AnimacionesAnimales.ACCION_DORMIR);
        SetEstadoInicial("Low_Wolf_v01 (2)", AnimacionesAnimales.ACCION_DORMIR);
        SetEstadoInicial("Low_Wolf_v01 (1)", AnimacionesAnimales.ACCION_DORMIR);

        //desierto
        SetEstadoInicial("Elephant (1)", AnimacionesAnimales.ACCION_COMER);
        SetEstadoInicial("Low_Coyote_v01 (1)", AnimacionesAnimales.ACCION_DORMIR);

        //bosque

    }
    public void SetDormido(string id, bool dormido)
    {
        if ( string.IsNullOrEmpty( id ) ) return;

        if (!mapAnimalesDormidos.ContainsKey(id))
        {
            mapAnimalesDormidos.Add(id, dormido);
        }
        else
        {
            mapAnimalesDormidos[id] = dormido;
        }

    }

    public bool IsDormido( string id )
    {
        var dormido = false;

        if (string.IsNullOrEmpty(id)) return dormido;

        mapAnimalesDormidos.TryGetValue(id, out dormido);

        return dormido;
    }

    public void SetEstadoInicial(string id, int accion)
    {
        if ( string.IsNullOrEmpty(id) ) return;

        var animal   = GameObject.Find(id);
        var animator = animal != null ? animal.GetComponent<Animator>() : null;

        if (animator != null && accion > -1)
        {
            var nombreAnimacion = AnimacionesAnimales.GetNombreAnimacion(animator.name, accion);

            if (!string.IsNullOrEmpty(nombreAnimacion))
            {
                animator.Play(nombreAnimacion);

                if (accion == AnimacionesAnimales.ACCION_DORMIR)
                {
                    SetDormido(animator.name, true);
                }
            }
        }
    }
}
