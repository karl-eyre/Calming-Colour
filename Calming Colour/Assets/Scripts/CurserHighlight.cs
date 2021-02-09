using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CurserHighlight : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    Material startingColour;
    public Material highlightColour;
    public Material PressedColour;
    bool pressed = false;
    bool highlighted = false;
    Renderer rend;

    [SerializeField]
    AudioSource buttonSound;
    [SerializeField]
    AudioClip buttonSoundClip;

    // Start is called before the first frame update
    void Start()
    { 
        rend = this.GetComponent<Renderer>();
        startingColour = rend.material;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        rend.material = highlightColour;
        highlighted = true;
    }

    //Reset off of temp colour
    public void OnPointerExit(PointerEventData eventData)
    {
        if (pressed == false) 
        {
            rend.material = startingColour;
        }

        highlighted = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        rend.material = PressedColour;
        buttonSound.PlayOneShot(buttonSoundClip);        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (highlighted == false)
        {
            rend.material = startingColour;
        }
        else
        {
            rend.material = highlightColour;
        }        
    }
}
