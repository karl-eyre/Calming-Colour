using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ColourSelect : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    public GameObject curentHeldColour;
    public GameObject tileHomer;

    public void OnPointerClick(PointerEventData eventData)
    {
        var raycastResult = eventData.pointerCurrentRaycast;
        //Debug.Log("You have clicked" + raycastResult.gameObject.GetComponent<Renderer>().material);

        var controller = GameObject.Find("VRAvatar").GetComponent<PlayerController>();
        controller.colourSelection = raycastResult.gameObject.GetComponent<Renderer>().material;
        curentHeldColour.gameObject.GetComponent<Renderer>().material = raycastResult.gameObject.GetComponent<Renderer>().material;
        tileHomer.gameObject.transform.position = eventData.pointerCurrentRaycast.worldPosition;
    }

    //Detect current clicks on the GameObject (the one with the script attached)
    public void OnPointerDown(PointerEventData eventData)
    {
        //this.gameObject.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
    }

    //Detect if clicks are no longer registering
    public void OnPointerUp(PointerEventData eventData)
    {
        //this.gameObject.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
    }

}
