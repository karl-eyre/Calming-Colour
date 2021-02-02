using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwapMosaic : MonoBehaviour, IPointerClickHandler
{
    public int swapIncriment;

    public void OnPointerClick(PointerEventData eventData)
    {
        var controller = GameObject.Find("VRAvatar").GetComponent<PlayerController>();
        controller.GetComponent<PlayerController>().SwapMosaic(swapIncriment);
        controller.GetComponent<PlayerController>().TooltipUpdater(controller.GetComponent<PlayerController>().toolTip_Swap);
    }
}

