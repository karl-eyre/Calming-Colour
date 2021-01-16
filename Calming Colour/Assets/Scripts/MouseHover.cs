using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Material curentColour;

    //Detect if the Cursor starts to pass over the GameObject
    public void OnPointerEnter(PointerEventData eventData)
    {
        var raycastResult = eventData.pointerCurrentRaycast;

        curentColour = raycastResult.gameObject.GetComponent<Renderer>().material;

        var controller = GameObject.Find("VRAvatar").GetComponent<PlayerController>();
        raycastResult.gameObject.GetComponent<Renderer>().material = controller.colourSelection;
    }


    //Detect when Cursor leaves the GameObject
    public void OnPointerExit(PointerEventData eventData)
    {
        this.gameObject.GetComponent<Renderer>().material = curentColour;
    }
}
