using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CurserHighlight : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Material startingColour;
    public Material highlightColour;
    Renderer rend;

    // Start is called before the first frame update
    void Start()
    { 
        rend = this.GetComponent<Renderer>();
        startingColour = rend.material;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        rend.material = highlightColour;
    }

    //Reset off of temp colour
    public void OnPointerExit(PointerEventData eventData)
    {
        rend.material = startingColour;
    }

}
