using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ResetButton : MonoBehaviour, IPointerClickHandler
{

    public void OnPointerClick(PointerEventData eventData)
    {
        var controller = GameObject.Find("VRAvatar").GetComponent<PlayerController>();
        controller.GetComponent<PlayerController>().resetCanvas();
        controller.GetComponent<PlayerController>().TooltipUpdater(controller.GetComponent<PlayerController>().toolTip_Reset);
    }

}
