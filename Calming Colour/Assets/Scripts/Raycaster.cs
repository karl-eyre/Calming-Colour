using Liminal.SDK.VR;
using Liminal.SDK.VR.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Liminal.SDK.VR.EventSystems;


public class Raycaster : MonoBehaviour, IPointerClickHandler
{
    public GameObject box;

    /*private void Update()
    {
        var primaryInput = VRDevice.Device.PrimaryInputDevice;

        if (primaryInput.GetButtonUp(VRButton.Trigger))
        {
            box.SetActive(false);
        }
    }*/

    public void OnPointerClick(PointerEventData eventData)
    {
        box.SetActive(false);
        var raycastResult = eventData.pointerCurrentRaycast;
        Debug.Log("The object has been clicked");
    }

}
