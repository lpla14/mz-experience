using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenePausa : MonoBehaviour
{

    public string sceneName;
    public string ambiente;

    void Start()
    {
        var G = FindObjectOfType<LoadScenePausa>();
        Object.DontDestroyOnLoad(G);
        SceneManager.LoadScene(sceneName);
    }

}