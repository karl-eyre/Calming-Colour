using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ColourSelect : MonoBehaviour, IPointerClickHandler
{
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
        var raycastResult = eventData.pointerCurrentRaycast;
        Debug.Log("You have clicked" + raycastResult.gameObject.GetComponent<Renderer>().material);

        var controller = GameObject.Find("VRAvatar").GetComponent<PlayerController>();
        controller.colourSelection = raycastResult.gameObject.GetComponent<Renderer>().material;

        //raycastResult.gameObject.SetActive(false);
    }

}
