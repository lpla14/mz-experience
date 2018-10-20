using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoAnimales : MonoBehaviour {

    private Dictionary<string, bool> mapAnimalesDormidos = new Dictionary<string, bool>();	
    
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
}
