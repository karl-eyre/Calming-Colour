using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ColourAdd : MonoBehaviour, IPointerClickHandler
{

    public void OnPointerClick(PointerEventData eventData)
    {
        var raycastResult = eventData.pointerCurrentRaycast;

        var controller = GameObject.Find("VRAvatar").GetComponent<PlayerController>();
        raycastResult.gameObject.GetComponent<Renderer>().material = controller.colourSelection;

        //raycastResult.gameObject.SetActive(false);
    }

}
