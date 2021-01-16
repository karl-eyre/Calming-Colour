using Liminal.SDK.VR;
using Liminal.SDK.VR.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public Material colourSelection;

    // Update is called once per frame
    void Update()
    {

        var primaryInput = VRDevice.Device.PrimaryInputDevice;

        if (primaryInput.GetButtonUp(VRButton.One))
        {
            //Trigger has been pressed and released
        }

    }
}
