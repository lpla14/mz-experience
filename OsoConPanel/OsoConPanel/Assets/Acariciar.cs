using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acariciar : MonoBehaviour
{
    public GameObject mano;
    private bool init = false;

    // Use this for initialization
    void Init()
    {
        mano.SetActive(true);
        FindObjectOfType<Mano>().enabled = true;
        StartCoroutine(ChauMano());

        init = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!init) Init();
    }

    IEnumerator ChauMano()
    {
        yield return new WaitForSecondsRealtime(5);
        FindObjectOfType<Mano>().enabled = false;
        mano.SetActive(false);
        init = false;
        this.enabled = false;
    }
}
