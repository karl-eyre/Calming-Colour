using Liminal.SDK.VR;
using Liminal.SDK.VR.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CompleteButton : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        var primaryInput = VRDevice.Device.PrimaryInputDevice;

        var controller = GameObject.Find("VRAvatar").GetComponent<PlayerController>();

        if (primaryInput.GetButtonDown(VRButton.One))
        {
            controller.GetComponent<PlayerController>().completeMosaic = true;
        }

    }

}
