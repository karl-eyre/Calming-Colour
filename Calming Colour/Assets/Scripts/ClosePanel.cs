using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClosePanel : MonoBehaviour, IPointerClickHandler
{
    public GameObject playerHead;
    public GameObject followUpTooltip;

    private void FixedUpdate()
    {
        this.transform.LookAt(playerHead.transform);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        DisableTooltip();
    }

    public void DisableTooltip()
    {
        this.gameObject.SetActive(false);

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
