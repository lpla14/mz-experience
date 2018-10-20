using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveSettingManager : MonoBehaviour {

    public GameObject canvas;
    private string buttonName;
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(Botones.BOTON_R1))
        {
            switch (buttonName)
            {
                case "ButtonPlus":

                    canvas.GetComponent<SettingsManager>().SubirVol();

                    break;

                case "ButtonMinus":

                    canvas.GetComponent<SettingsManager>().BajarVol();

                    break;

                case "ButtonLow":

                    canvas.GetComponent<SettingsManager>().SetQuality(0);

                    break;

                case "ButtonMid":

                    canvas.GetComponent<SettingsManager>().SetQuality(1);

                    break;

                case "ButtonHigh":

                    canvas.GetComponent<SettingsManager>().SetQuality(3);

                    break;

            }

        }
	}

    public void SetButtonName(string button)
    {
        buttonName = button;
    }
}
