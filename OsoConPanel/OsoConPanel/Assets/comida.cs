using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comida : MonoBehaviour {

    public GameObject cjto_frutas;
    public float shrink_speed = 1f;
    public float food_scale = 1f;
    private bool init = false;

	// Use this for initialization
	void Init () {
       
        cjto_frutas.SetActive(true);
        //cjto_frutas.transform.position = animacion.transform.localPosition + new Vector3(0f, 0.1f, 1.1f);
        StartCoroutine(ChauFruta());

        init = true; 
    }

    // Update is called once per frame
    void Update () {

        if (!init) Init();
        cjto_frutas.transform.localScale -= new Vector3(0.004F, 0.004F, 0.004F) * shrink_speed;
    }

    IEnumerator ChauFruta()
    {
        yield return new WaitForSecondsRealtime(3);
        cjto_frutas.SetActive(false);
        cjto_frutas.transform.localScale = new Vector3(1f, 1f, 1f) * food_scale;
        init = false;
        this.enabled = false;
    }


 
}
