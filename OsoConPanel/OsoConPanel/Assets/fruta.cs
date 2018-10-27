using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fruta : MonoBehaviour {
    Vector3 escalatemp;
    public GameObject frutas;

    // Use this for initialization
    void Start () {
        frutas.SetActive(true);
        frutas.transform.localPosition = transform.position + new Vector3(0f, 0f, 1.1f);

    }
	
	// Update is called once per frame
	void Update () {
        escalatemp = frutas.transform.localScale;
        StartCoroutine(OcultarFruta());
            escalatemp.x -= 0.003f;
            escalatemp.y -= 0.003f;
            escalatemp.z -= 0.003f;

            frutas.transform.localScale = escalatemp;
    }

    IEnumerator OcultarFruta()
    {
        yield return new WaitForSecondsRealtime(3);
        //frutas.transform.position = new Vector3(0f, 0f, 0f);
        frutas.SetActive(false);
        frutas.transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
    }
}
