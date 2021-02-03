using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClosePanel : MonoBehaviour, IPointerClickHandler
{
    public GameObject playerHead;
    public GameObject followUpTooltip;
    public static event EventHandler ONPanelClose; 
    private void FixedUpdate()
    {
        this.transform.LookAt(playerHead.transform);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        this.gameObject.SetActive(false);
        ONPanelClose?.Invoke(this,EventArgs.Empty);
        if (followUpTooltip != null)
        {
            if (followUpTooltip.activeInHierarchy == false)
            {
                print("activate tooltip");
                followUpTooltip.SetActive(true);
            }     
        }   
    }
}
