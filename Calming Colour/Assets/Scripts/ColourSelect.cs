using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ColourSelect : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{

    Material curentColour;

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
    }

    //Detect current clicks on the GameObject (the one with the script attached)
    public void OnPointerDown(PointerEventData eventData)
    {
        this.gameObject.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
    }

    //Detect if clicks are no longer registering
    public void OnPointerUp(PointerEventData eventData)
    {
        this.gameObject.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
    }

}
