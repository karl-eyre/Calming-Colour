using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ColourAdd : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{

    Material curentColour;

    //add new colour
    public void OnPointerClick(PointerEventData eventData)
    {
        var raycastResult = eventData.pointerCurrentRaycast;

        var controller = GameObject.Find("VRAvatar").GetComponent<PlayerController>();
        if (controller.colourSelection != null)
        {
            curentColour = controller.colourSelection;
            raycastResult.gameObject.GetComponent<Renderer>().material = controller.colourSelection;
        }
    }

    //Temporary Colour
    public void OnPointerEnter(PointerEventData eventData)
    {
        var raycastResult = eventData.pointerCurrentRaycast;

        curentColour = raycastResult.gameObject.GetComponent<Renderer>().material;

        var controller = GameObject.Find("VRAvatar").GetComponent<PlayerController>();
        raycastResult.gameObject.GetComponent<Renderer>().material = controller.colourSelection;
    }

    //Reset off of temp colour
    public void OnPointerExit(PointerEventData eventData)
    {
        this.gameObject.GetComponent<Renderer>().material = curentColour;
    }
}
