using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.SceneManagement;

public class LoaderSettings : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        StartCoroutine(ActivateVR("cardboard", true));
    }

    public IEnumerator ActivateVR(string component, bool enableVR)
    {
        XRSettings.LoadDeviceByName(component);
        yield return null;
        XRSettings.enabled = enableVR;
        SceneManager.LoadScene("MainMenuScene");
        
    }
}
