using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class volverAmbiente : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        var a = FindObjectOfType<LoadScenePausa>();
        Debug.Log(a.ambiente);

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(Botones.BOTON_R1))
        {
            var a = FindObjectOfType<LoadScenePausa>();
            Debug.Log(a.ambiente);
            SceneManager.LoadScene(a.ambiente);
        }

    }
}