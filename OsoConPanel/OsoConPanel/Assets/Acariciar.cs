using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acariciar : MonoBehaviour
{

    private float posInicial;
    private float posFinal;
    private bool adelante = true;
    private bool atras = false;
    private int cont = 0;

    public GameObject mano;

    // Use this for initialization
    void Start()
    {

        mano.SetActive(true);
        posInicial = mano.transform.position.z;
        posFinal = posInicial - 1.43f;

    }

    // Update is called once per frame
    void Update()
    {
        if (cont < 1000)
            StartCoroutine("MoverMano");
        else
            mano.SetActive(false);

    }

    IEnumerator MoverMano()
    {
        for (int f = 0; f < 3; f += 1)
        {
            if (mano.transform.position.z > posFinal && adelante == true)
            {
                mano.transform.position -= new Vector3(0, 0, 0.008f);
            }
            else
            {
                adelante = false;
            }

            if (mano.transform.position.z < posInicial && adelante == false)
            {
                mano.transform.position += new Vector3(0, 0, 0.008f);
            }
            else
                adelante = true;
            cont++;
            yield return null;
        }
    }
}
