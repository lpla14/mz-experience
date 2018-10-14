using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class VRSettingsController : MonoBehaviour {

	public string component;
	public bool	  enableVR;
	
	// Use this for initialization
	void Start () {
		StartCoroutine( ActivateVR( component, enableVR ) );
	}
	
	public IEnumerator ActivateVR ( string component, bool enableVR )
	{
        if ( !XRSettings.loadedDeviceName.Equals("cardboard") )
        {
            XRSettings.LoadDeviceByName(component);
            yield return null;
            XRSettings.enabled = enableVR;
        }
	}
	
}
