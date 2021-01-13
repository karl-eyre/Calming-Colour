using Liminal.SDK.VR;
using Liminal.SDK.VR.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{

    public GameObject box;

    // Update is called once per frame
    void Update()
    {

        var primaryInput = VRDevice.Device.PrimaryInputDevice;

        if (primaryInput.GetButtonUp(VRButton.One))
        {
            box.SetActive(false);
            //Trigger has been pressed and released
        }

    }
}
