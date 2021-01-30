using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClosePanel : MonoBehaviour, IPointerClickHandler
{
    public GameObject playerHead;

    private void FixedUpdate()
    {
        this.transform.LookAt(playerHead.transform);
    }

    public void OnPointerClick(PointerEventData eventData)
    { 
        this.gameObject.SetActive(false);
    }
}
