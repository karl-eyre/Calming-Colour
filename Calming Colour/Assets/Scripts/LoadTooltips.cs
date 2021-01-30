using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LoadTooltips : MonoBehaviour, IPointerClickHandler
{
    public List<GameObject> tooltips;

    // Update is called once per frame
    void Start()
    {
        TooltipSwitch(true);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        TooltipSwitch(true);
    }

    void TooltipSwitch(bool choice)
    {
        for (int i = 0; i < tooltips.Count; i++)
        {
            tooltips[i].SetActive(choice);
        }
    }
}


